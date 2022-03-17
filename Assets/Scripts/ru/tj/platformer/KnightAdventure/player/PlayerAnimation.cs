using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerAnimation : IPlayerAnimation {
        private Animator animator;

        public PlayerAnimation(Animator animator) {
            this.animator = animator;
        }

        public void MoveParamsUpdate(bool grounded, float velocityX, float velocityY) {
            animator.SetBool("Grounded", grounded);
            animator.SetFloat("VelocityX", velocityX);
            animator.SetFloat("VelocityY", velocityY);
        }

        public void ChangeDirection() {
            animator.SetTrigger("ChangeDirection");
        }
    }
}