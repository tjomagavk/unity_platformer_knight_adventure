using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    public class UnitAnimation : IUnitAnimation {
        private Animator animator;

        public UnitAnimation(Animator animator) {
            this.animator = animator;
        }

        public void MoveParamsUpdate(bool grounded, float velocityX, float velocityY) {
            animator.SetBool(UnitAnimationVars.Grounded, grounded);
            animator.SetFloat(UnitAnimationVars.VelocityX, velocityX);
            animator.SetFloat(UnitAnimationVars.VelocityY, velocityY);
        }

        public void ChangeDirection() {
            animator.SetTrigger(UnitAnimationVars.ChangeDirection);
        }

        public void SimpleAttack(bool attackLeft) {
            animator.SetTrigger(UnitAnimationVars.AttackTrigger);
            animator.SetTrigger(UnitAnimationVars.AttackSimple);
            animator.SetBool(UnitAnimationVars.AttackLeft, attackLeft);
        }

        public void TakeDamage() {
            animator.SetTrigger(UnitAnimationVars.DamageTrigger);
        }
    }
}