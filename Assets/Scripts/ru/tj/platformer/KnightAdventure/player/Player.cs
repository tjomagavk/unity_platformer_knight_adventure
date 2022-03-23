using ru.tj.platformer.KnightAdventure.ui;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    [RequireComponent(typeof(IHealth))]
    public class Player : MonoBehaviour {
        private IHealth health;
        [SerializeField] private UnitData unit;
        [SerializeField] private HealthPanel healthPanel;

        [Inject] private IPlayerMovement playerMovement;
        [Inject] private IPlayerInput playerInput;

        private void Awake() {
            unit.transform.position = transform.position;
            health = GetComponent<IHealth>();
            healthPanel.SetMaxHealth(health.MaxHealth());
        }

        void Update() {
            playerMovement.Move(unit);
            if (playerInput.SimpleAttack()) {
                unit.SimpleAttack();
            }
        }
    }
}