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

        private bool active = true;
        private float nextDamageTime = 0;

        private void FixedUpdate() {
            if (!active) {
                nextDamageTime -= Time.deltaTime;
                if (nextDamageTime <= 0) {
                    active = true;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            Damage(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            Damage(col.gameObject);
        }

        private bool IsNeedDamage(GameObject gObject) {
            if (active) {
                foreach (string damageTag in damageTags) {
                    if (gObject.CompareTag(damageTag)) {
                        return true;
                    }
                }
            }

            return false;
        }

        private void Damage(GameObject gObject) {
            if (IsNeedDamage(gObject)) {
                if (gObject.TryGetComponent<UnitData>(out var unitData)) {
                    active = false;
                    nextDamageTime = 1;
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