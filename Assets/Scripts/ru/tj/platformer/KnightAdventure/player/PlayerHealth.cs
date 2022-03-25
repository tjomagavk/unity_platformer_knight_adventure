using ru.tj.platformer.KnightAdventure.ui;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerHealth : IHealth {
        private readonly int maxHealth;
        private int currentHealth;
        private bool alive;
        private HealthPanel healthPanel;

        public PlayerHealth(int maxHealth, int currentHealth, HealthPanel healthPanel) {
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
            this.healthPanel = healthPanel;
            alive = true;
            this.healthPanel.SetMaxHealth(this.maxHealth);
            this.healthPanel.SetCurrentHealth(this.currentHealth);
        }

        public int MaxHealth() {
            return maxHealth;
        }

        public int CurrentHealth() {
            return currentHealth;
        }

        public void TakeDamage(int damage) {
            Debug.Log("Damage!!!");
            currentHealth -= damage;
            alive = currentHealth <= 0;
            healthPanel.ChangeHealth(-damage);
        }

        public bool IsAlive() {
            return alive;
        }
    }
}