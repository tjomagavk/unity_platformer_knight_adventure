using System;
using System.Collections.Generic;
using ru.tj.platformer.KnightAdventure.constant;
using ru.tj.platformer.KnightAdventure.player;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    [RequireComponent(typeof(Collider2D))]
    public class CollisionDamage : MonoBehaviour {
        [SerializeField] private List<String> damageTags = new List<string> { TagVars.Player };
        [SerializeField] private int damagePower = 1;
        [SerializeField] private GameObject pushAfterCollisionPrefab;

        private void OnCollisionEnter2D(Collision2D other) {
            bool needDamage = false;
            foreach (string damageTag in damageTags) {
                if (other.gameObject.CompareTag(damageTag)) {
                    needDamage = true;
                    break;
                }
            }

            if (needDamage) {
                if (other.gameObject.TryGetComponent<UnitData>(out var unitData)) {
                    unitData.TakeDamage(damagePower);
                    if (pushAfterCollisionPrefab != null) {
                        GameObject push = Instantiate(pushAfterCollisionPrefab, gameObject.transform);
                        Destroy(push, 0.5f);
                    }
                }
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]
        public void ResetValues() {
            damageTags = new List<string> { TagVars.Player };
            damagePower = 1;
        }
#endif
    }
}