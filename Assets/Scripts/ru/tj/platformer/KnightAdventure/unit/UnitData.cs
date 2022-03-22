using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    [RequireComponent(typeof(Rigidbody2D))]
    public class UnitData : MonoBehaviour {
        private const string ChangeDirectionAnim = "ChangeDirection";
        private Rigidbody2D rb;
        private GroundChecker groundChecker;

        [Header("Grounded checker settings")]
        [SerializeField]
        private Transform groundPoint;

        [SerializeField, Range(0, 10)] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayerMask;

        [Header("Other settings")]
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private SpriteRenderer sprite;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            groundChecker = new GroundChecker(groundPoint, groundCheckRadius, groundLayerMask);
        }

        public Rigidbody2D Rb => rb;

        public bool OnGrounded() {
            return groundChecker.IsGrounded();
        }

        public void FlipX(bool flip) {
            if (sprite.flipX != flip) {
                sprite.flipX = flip;
                animator.SetTrigger(ChangeDirectionAnim);
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            groundCheckRadius = 0.1f;
        }
#endif
    }
}