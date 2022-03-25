using ru.tj.platformer.KnightAdventure.ui;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    public class Player : MonoBehaviour {
        [SerializeField] private UnitData unit;
        // [SerializeField] private HealthPanel healthPanel;

        [Inject] private IPlayerMovement playerMovement;
        [Inject] private IPlayerInput playerInput;
        [Inject] private IHealth playerHealth;

        private void Awake() {
            unit.transform.position = transform.position;
            unit.Health = playerHealth;
        }

        void Update() {
            playerMovement.Move(unit);
            if (playerInput.SimpleAttack()) {
                unit.SimpleAttack();
            }
        }
    }
}