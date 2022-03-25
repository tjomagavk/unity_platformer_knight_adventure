using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    public class Health : MonoBehaviour, IHealth {
        [SerializeField] private int maxHealth;
        private BaseHealth baseHealth;

        private void Awake() {
            baseHealth = new BaseHealth(maxHealth, maxHealth);
        }

        public int MaxHealth() {
            return baseHealth.MaxHealth();
        }

        public void AddMaxHealth(int count) {
            baseHealth.AddMaxHealth(count);
        }

        public int CurrentHealth() {
            return baseHealth.CurrentHealth();
        }

        public void TakeDamage(int damage) {
            baseHealth.TakeDamage(damage);
        }

        public bool IsAlive() {
            return baseHealth.IsAlive();
        }
    }
}