using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour {
        private IPlayerMovement playerMovement;

        private Rigidbody2D rigidbody2D;

        [Inject]
        private void Construct(IPlayerMovement playerMovement) {
            this.playerMovement = playerMovement;
        }

        void Awake() {
            rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        void Update() {
            playerMovement.Move(rigidbody2D);
        }
    }
}