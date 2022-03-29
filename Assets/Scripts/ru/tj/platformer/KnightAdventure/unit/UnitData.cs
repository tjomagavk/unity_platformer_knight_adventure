using ru.tj.platformer.KnightAdventure.constant;
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
        private bool attackInProgress;

        [Header("Attacks")] [SerializeField] private DamageObject simpleAttack;

        [SerializeField] private DamageObject jumpAttack;
        [SerializeField] private DamageObject specialAttack;

        private DamageObject currentAttack;

        [Header("Grounded checker settings")]
        [SerializeField]
        private Transform groundPoint;

        [SerializeField, Range(0, 10)] private float groundCheckRadius = 0.1f;
        [SerializeField] private LayerMask groundLayerMask;

        [Header("Other settings")]
        [SerializeField]
        private SpriteRenderer sprite;

        [SerializeField] private bool destroyWithParent;

        private void Awake() {
            Rb = GetComponent<Rigidbody2D>();
            if (Health == null) {
                Health = GetComponent<IHealth>();
            }

            if (groundPoint != null) {
                groundChecker = new GroundChecker(groundPoint, groundCheckRadius, groundLayerMask);
            }

            UnitAnimation = new UnitAnimation(GetComponent<Animator>());
            attackLeft = false;
        }

        private void FixedUpdate() {
            if (attackInProgress) {
                attackInProgress = UnitAnimation.AttackInProgress();
                if (!attackInProgress && currentAttack != null && !currentAttack.IsRangeAttack()) {
                    Destroy(currentAttack.gameObject);
                }
            }
        }

        public bool OnGrounded() {
            if (groundChecker != null) {
                return groundChecker.IsGrounded();
            }

            return false;
        }

        public void FlipX(bool flip) {
            if (sprite.flipX != flip) {
                sprite.flipX = flip;
                if (currentAttack != null) {
                    currentAttack.FlipX(sprite.flipX);
                }

                UnitAnimation.ChangeDirection();
            }
        }

        public void SimpleAttack() {
            if (!attackInProgress) {
                attackInProgress = true;
                if (OnGrounded()) {
                    currentAttack = Instantiate(simpleAttack, gameObject.transform, false);
                } else {
                    currentAttack = Instantiate(jumpAttack, gameObject.transform, false);
                }

                currentAttack.Run(sprite.flipX);
                UnitAnimation.SimpleAttack(attackLeft);
                attackLeft = !attackLeft;
            }
        }

        public void TakeDamage(int damage) {
            Health.TakeDamage(damage);
            if (Health.IsAlive()) {
                UnitAnimation.TakeDamage();
            } else {
                UnitAnimation.Death();
            }
        }

        public void TakeBonus(Bonuses bonus, int count) {
            if (Bonuses.ChangeMaxHealth == bonus) {
                Health.AddMaxHealth(count);
            } else if (Bonuses.ChangeCurrentHealth == bonus) {
                Health.TakeDamage(-count);
            }
        }

        public void Destroy() {
            if (destroyWithParent) {
                Destroy(gameObject.transform.parent.gameObject);
            } else {
                Destroy(gameObject);
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