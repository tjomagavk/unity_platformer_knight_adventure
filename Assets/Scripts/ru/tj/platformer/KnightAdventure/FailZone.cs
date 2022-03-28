using ru.tj.platformer.KnightAdventure.constant;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure {
    public class FailZone : MonoBehaviour {
        [Inject] private IHealth playerHealth;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag(TagVars.Player)) {
                playerHealth.TakeDamage(playerHealth.CurrentHealth());
            } else {
                Destroy(other.gameObject);
            }
        }
    }
}