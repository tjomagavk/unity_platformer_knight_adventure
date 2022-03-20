using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerMovement : IPlayerMovement {
        private readonly GroundChecker groundChecker;
        private readonly float jumpForce;
        private readonly float speed;
        private readonly AnimationCurve speedCurve;

        //todo подумать, куда перенести
        private readonly SpriteRenderer playerSprite;
        private bool enableMovement = true;
        private bool grounded;

        [Inject] private IPlayerAnimation playerAnimation;
        [Inject] private IPlayerInput playerInput;

        public PlayerMovement(float speed,
                              AnimationCurve speedCurve,
                              float jumpForce,
                              GroundChecker groundChecker,
                              SpriteRenderer playerSprite) {
            this.speed = speed;
            this.speedCurve = speedCurve;
            this.jumpForce = jumpForce;
            this.groundChecker = groundChecker;
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
            grounded = groundChecker.IsGrounded();
            if (enableMovement && playerInput.jump()) {
                if (grounded) {
                    rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        private void HorizontalMovement(Rigidbody2D rigidbody) {
            if (enableMovement) {
                var moveX = playerInput.horizontal();
                // todo разобраться, почему не работает с addForce
                // Vector2 movement = new Vector2(moveX, rigidbody.position.y);
                // rigidbody.AddForce(movement * speed);
                //
                var movement = Vector2.zero;
                movement.x = speedCurve.Evaluate(moveX) * speed;
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