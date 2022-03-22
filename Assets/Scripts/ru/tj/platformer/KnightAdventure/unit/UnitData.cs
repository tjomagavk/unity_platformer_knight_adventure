using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    [RequireComponent(typeof(Rigidbody2D))]
    public class UnitData : MonoBehaviour {
        private GroundChecker groundChecker;

        public Rigidbody2D Rb { get; private set; }

        public IUnitAnimation UnitAnimation { get; private set; }

        [Header("Damage areas")]
        [SerializeField]
        private Collider2D damageArea;

        [SerializeField] private Collider2D damageAreaJump;


        [Header("Grounded checker settings")]
        [SerializeField]
        private Transform groundPoint;

        [SerializeField, Range(0, 10)] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayerMask;

        [Header("Other settings")]
        [SerializeField]
        private Animator animator;

        [SerializeField] private SpriteRenderer sprite;

        private void Awake() {
            Rb = GetComponent<Rigidbody2D>();
            groundChecker = new GroundChecker(groundPoint, groundCheckRadius, groundLayerMask);
            UnitAnimation = new UnitAnimation(animator);
        }


        public bool OnGrounded() {
            return groundChecker.IsGrounded();
        }

        public void FlipX(bool flip) {
            if (sprite.flipX != flip) {
                sprite.flipX = flip;
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