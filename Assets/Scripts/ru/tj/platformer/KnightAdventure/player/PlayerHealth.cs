using ru.tj.platformer.KnightAdventure.unit;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerHealth : IHealth {
        private readonly int maxHealth;
        private int currentHealth;
        private bool alive;

        public PlayerHealth(int maxHealth, int currentHealth) {
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
            alive = true;
        }

        public int MaxHealth() {
            return maxHealth;
        }

        public int CurrentHealth() {
            return currentHealth;
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