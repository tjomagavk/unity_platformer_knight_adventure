using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class UnitData : MonoBehaviour {
        private GroundChecker groundChecker;

        public IHealth Health { get; set; }
        public Rigidbody2D Rb { get; private set; }
        public IUnitAnimation UnitAnimation { get; private set; }
        private bool attackLeft;

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
        private SpriteRenderer sprite;

        private void Awake() {
            Rb = GetComponent<Rigidbody2D>();
            groundChecker = new GroundChecker(groundPoint, groundCheckRadius, groundLayerMask);
            UnitAnimation = new UnitAnimation(GetComponent<Animator>());
            attackLeft = false;
        }


        public bool OnGrounded() {
            return groundChecker.IsGrounded();
        }

        public void FlipX(bool flip) {
            if (sprite.flipX != flip) {
                sprite.flipX = flip;
                UnitAnimation.ChangeDirection();
            }
        }

        public void SimpleAttack() {
            UnitAnimation.SimpleAttack(attackLeft);
            attackLeft = !attackLeft;
        }

        public void TakeDamage(int damage) {
            Health.TakeDamage(damage);
            UnitAnimation.TakeDamage();
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            groundCheckRadius = 0.1f;
        }
#endif
    }
}