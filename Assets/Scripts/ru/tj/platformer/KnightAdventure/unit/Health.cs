﻿using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.unit {
    public class Health : MonoBehaviour, IHealth {
        [SerializeField] private int maxHealth;
        private int currentHealth;
        private bool alive;

        private void Awake() {
            currentHealth = maxHealth;
            alive = true;
        }

        public int MaxHealth() {
            return maxHealth;
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