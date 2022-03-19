using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    public class KeyboardPlayerMovement : IPlayerMovement {
        private readonly Transform groundChecker;
        private readonly float groundCheckRadius;
        private readonly LayerMask groundLayerMask;
        private readonly float jumpForce;

        //todo подумать, куда перенести
        private readonly SpriteRenderer playerSprite;
        private readonly float speed;
        private bool enableMovement = true;
        private bool grounded;

        [Inject] private IPlayerAnimation playerAnimation;

        public KeyboardPlayerMovement(float speed,
                                      float jumpForce,
                                      Transform groundChecker,
                                      float groundCheckRadius,
                                      LayerMask groundLayerMask,
                                      SpriteRenderer playerSprite) {
            this.speed = speed;
            this.jumpForce = jumpForce;
            this.groundChecker = groundChecker;
            this.groundCheckRadius = groundCheckRadius;
            this.groundLayerMask = groundLayerMask;
            this.playerSprite = playerSprite;
        }

        public void Move(Rigidbody2D rigidbody) {
            Jump(rigidbody);
            HorizontalMovement(rigidbody);
            playerAnimation.MoveParamsUpdate(grounded, Mathf.Abs(rigidbody.velocity.x), rigidbody.velocity.y);
        }

        public void EnableMovement(bool enable) {
            enableMovement = enable;
        }

        private void Jump(Rigidbody2D rigidbody) {
            grounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundLayerMask);
            if (enableMovement && Input.GetButtonDown(AxisVars.Jump)) {
                if (grounded) {
                    rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        private void HorizontalMovement(Rigidbody2D rigidbody) {
            if (enableMovement) {
                var moveX = Input.GetAxis(AxisVars.Horizontal);
                // todo разобраться, почему не работает с addForce
                // Vector2 movement = new Vector2(moveX, rigidbody.position.y);
                // rigidbody.AddForce(movement * speed);
                //
                var movement = Vector2.zero;
                movement.x = moveX * speed;
                movement.y = rigidbody.velocity.y;
                rigidbody.velocity = movement;
                if (moveX > 0) {
                    if (playerSprite.flipX) {
                        playerSprite.flipX = false;
                        playerAnimation.ChangeDirection();
                    }
                } else if (moveX < 0) {
                    if (!playerSprite.flipX) {
                        playerSprite.flipX = true;
                        playerAnimation.ChangeDirection();
                    }
                }
            }
        }
    }
}