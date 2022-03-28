using ru.tj.platformer.KnightAdventure.ui;
using ru.tj.platformer.KnightAdventure.unit;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.player {
    public class Player : MonoBehaviour {
        [SerializeField] private UnitData unit;

        [Inject] private IPlayerMovement playerMovement;
        [Inject] private IPlayerInput playerInput;
        [Inject] private IHealth playerHealth;
        [Inject] private WindowManager windowManager;
        private bool deathWorkedOut;

        private void Awake() {
            unit.transform.position = transform.position;
            unit.Health = playerHealth;
        }

        void Update() {
            if (playerHealth.IsAlive()) {
                playerMovement.Move(unit);
                if (playerInput.SimpleAttack()) {
                    unit.SimpleAttack();
                }
            } else {
                if (!deathWorkedOut) {
                    deathWorkedOut = true;
                    playerMovement.EnableMovement(false);
                    StartCoroutine(windowManager.DeathWindowActivate(1));
                    unit.Rb.simulated = false;
                }
            }
        }
    }
}