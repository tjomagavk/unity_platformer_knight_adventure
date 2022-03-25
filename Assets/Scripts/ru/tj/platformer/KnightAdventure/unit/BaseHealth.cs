using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    public class BaseHealth : IHealth {
        private int maxHealth;
        private int currentHealth;
        private bool alive = true;

        public BaseHealth(int maxHealth, int currentHealth) {
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
        }

        public int MaxHealth() {
            return maxHealth;
        }

        public virtual void AddMaxHealth(int count) {
            maxHealth += count;
        }

        public int CurrentHealth() {
            return currentHealth;
        }

        public virtual void TakeDamage(int damage) {
            currentHealth -= damage;
            alive = currentHealth <= 0;
        }

        public bool IsAlive() {
            return alive;
        }
    }
}