using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    [RequireComponent(
                         typeof(Rigidbody2D),
                         typeof(IHealth)
                     )]
    public class Player : MonoBehaviour {
        private IHealth health;
        private IPlayerMovement playerMovement;

        private Rigidbody2D rb;

        [Inject]
        private void Construct(IPlayerMovement playerMovement) {
            this.playerMovement = playerMovement;
        }

        void Awake() {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update() {
            playerMovement.Move(rb);
        }
    }
}