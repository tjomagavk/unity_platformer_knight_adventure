using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerAnimation : IPlayerAnimation {
        private Animator animator;
        private bool attackLeft;

        public PlayerAnimation(Animator animator) {
            this.animator = animator;
        }

        public void MoveParamsUpdate(bool grounded, float velocityX, float velocityY) {
            animator.SetBool(PlayerAnimationVars.Grounded, grounded);
            animator.SetFloat(PlayerAnimationVars.VelocityX, velocityX);
            animator.SetFloat(PlayerAnimationVars.VelocityY, velocityY);
        }

        public void SimpleAttack() {
            animator.SetTrigger(PlayerAnimationVars.AttackTrigger);
            animator.SetTrigger(PlayerAnimationVars.AttackSimple);
            animator.SetBool(PlayerAnimationVars.AttackLeft, attackLeft);
            attackLeft = !attackLeft;
        }
    }
}