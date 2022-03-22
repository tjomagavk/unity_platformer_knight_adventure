using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    public class Attack : MonoBehaviour {
        [SerializeField] private float powerAttack;
        [SerializeField] private GameObject damageDealer;
        [SerializeField] private bool isMilliAttack;
        private int currentHealth;
        private bool alive;

        private void Awake() {
            // currentHealth = maxHealth;
            alive = true;
        }

        public void TakeDamage(int damage) {
            currentHealth -= damage;
            alive = currentHealth <= 0;
        }

        public bool IsAlive() {
            return alive;
        }
    }
}