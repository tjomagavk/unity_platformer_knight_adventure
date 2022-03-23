using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerMovement : IPlayerMovement {
        private readonly float jumpForce;
        private readonly float speed;
        private readonly AnimationCurve speedCurve;

        private bool enableMovement = true;
        private bool grounded;

        [Inject] private IPlayerInput playerInput;

        public PlayerMovement(float speed, AnimationCurve speedCurve, float jumpForce) {
            this.speed = speed;
            this.speedCurve = speedCurve;
            this.jumpForce = jumpForce;
        }

        public void Move(UnitData unitData) {
            Jump(unitData);
            HorizontalMovement(unitData);
            unitData.UnitAnimation.MoveParamsUpdate(grounded,
                                                    Mathf.Abs(unitData.Rb.velocity.x),
                                                    unitData.Rb.velocity.y);
        }

        public void EnableMovement(bool enable) {
            enableMovement = enable;
        }

        private void Jump(UnitData unitData) {
            grounded = unitData.OnGrounded();
            if (enableMovement && playerInput.Jump()) {
                if (grounded) {
                    unitData.Rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }

        private void HorizontalMovement(UnitData unitData) {
            if (enableMovement) {
                var moveX = playerInput.Horizontal();
                // todo разобраться, почему не работает с addForce
                // Vector2 movement = new Vector2(moveX, rigidbody.position.y);
                // rigidbody.AddForce(movement * speed);
                //
                var movement = Vector2.zero;
                movement.x = speedCurve.Evaluate(moveX) * speed;
                movement.y = unitData.Rb.velocity.y;
                unitData.Rb.velocity = movement;
                if (moveX > 0) {
                    unitData.FlipX(false);
                } else if (moveX < 0) {
                    unitData.FlipX(true);
                }
            }
        }
    }
}