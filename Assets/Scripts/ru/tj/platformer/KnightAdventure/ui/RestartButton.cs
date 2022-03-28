using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ru.tj.platformer.KnightAdventure.ui {
    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour {
        private void Awake() {
            GetComponent<Button>().onClick.AddListener(SceneController.ReloadScene);
        }
    }
}