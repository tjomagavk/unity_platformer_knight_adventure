﻿namespace ru.tj.platformer.KnightAdventure.unit {
    public interface IHealth {
        int MaxHealth();

        void TakeDamage(int damage);
        bool IsAlive();
    }
}