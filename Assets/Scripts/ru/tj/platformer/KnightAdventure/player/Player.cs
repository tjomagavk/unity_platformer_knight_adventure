using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    [RequireComponent(
                         typeof(IHealth)
                     )]
    public class Player : MonoBehaviour {
        private IHealth health;
        [SerializeField] private UnitData unit;

        [Inject] private IPlayerMovement playerMovement;
        [Inject] private IPlayerInput playerInput;
        [Inject] private IPlayerAnimation playerAnimation;

        private void Awake() {
            unit.transform.position = transform.position;
        }

        void Update() {
            playerMovement.Move(unit);
            if (playerInput.SimpleAttack()) {
                playerAnimation.SimpleAttack();
            }
        }
    }
}