using ru.tj.platformer.KnightAdventure.ui;
using ru.tj.platformer.KnightAdventure.unit;

namespace ru.tj.platformer.KnightAdventure.player {
    public class PlayerHealth : BaseHealth {
        private readonly HealthPanel healthPanel;

        public PlayerHealth(int maxHealth, int currentHealth, HealthPanel healthPanel) :
            base(maxHealth, currentHealth) {
            this.healthPanel = healthPanel;
            this.healthPanel.SetMaxHealth(MaxHealth());
            this.healthPanel.SetCurrentHealth(CurrentHealth());
        }

        public override void AddMaxHealth(int count) {
            base.AddMaxHealth(count);
            healthPanel.AddMaxHealth(count);
        }

        public override void TakeDamage(int damage) {
            base.TakeDamage(damage);
            healthPanel.ChangeHealth(-damage);
        }
    }
}