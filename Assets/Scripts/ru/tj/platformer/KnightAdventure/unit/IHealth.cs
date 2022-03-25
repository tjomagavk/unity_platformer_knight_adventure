namespace ru.tj.platformer.KnightAdventure.unit {
    public interface IHealth {
        int MaxHealth();

        void AddMaxHealth(int count);

        int CurrentHealth();

        void TakeDamage(int damage);
        bool IsAlive();
    }
}