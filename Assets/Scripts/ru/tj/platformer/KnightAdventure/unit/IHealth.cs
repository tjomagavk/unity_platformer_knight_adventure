namespace ru.tj.platformer.KnightAdventure.unit {
    public interface IHealth {
        int MaxHealth();
        int CurrentHealth();

        void TakeDamage(int damage);
        bool IsAlive();
    }
}