using ru.tj.platformer.KnightAdventure.constant;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.trap {
    [RequireComponent(typeof(Collider2D))]
    public class Bonus : MonoBehaviour {
        private const string TakeTrigger = "TakeTrigger";
        [SerializeField] private Animator animator;
        [SerializeField] private Bonuses bonus;
        [SerializeField] private int count;
        private bool active = true;

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.gameObject.CompareTag(TagVars.Player)) {
                if (col.gameObject.TryGetComponent<UnitData>(out var unitData)) {
                    unitData.TakeBonus(bonus, count);
                    active = false;
                    animator.SetTrigger(TakeTrigger);
                    Destroy(gameObject, 0.5f);
                }
            }
        }
    }
}