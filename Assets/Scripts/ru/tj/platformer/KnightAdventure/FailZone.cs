using ru.tj.platformer.KnightAdventure.constant;
using UnityEngine;
using Zenject;

namespace ru.tj.platformer.KnightAdventure {
    public class FailZone : MonoBehaviour {
        [Inject] private SceneController sceneController;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag(TagVars.Player)) {
                sceneController.ReloadScene();
            }
        }
    }
}