using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public class GroundChecker {
        private readonly Transform groundChecker;
        private readonly float groundCheckRadius;
        private readonly LayerMask groundLayerMask;

        public GroundChecker(Transform groundChecker,
                             float groundCheckRadius,
                             LayerMask groundLayerMask) {
            this.groundChecker = groundChecker;
            this.groundCheckRadius = groundCheckRadius;
            this.groundLayerMask = groundLayerMask;
        }

        public bool IsGrounded() {
            return Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundLayerMask);
        }
    }
}