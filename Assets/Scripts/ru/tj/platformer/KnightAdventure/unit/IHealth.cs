namespace ru.tj.platformer.KnightAdventure.unit {
    public interface IHealth {
        void TakeDamage(int damage);
        bool IsAlive();
    }
}