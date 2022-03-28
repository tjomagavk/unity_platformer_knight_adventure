using UnityEngine;
using UnityEngine.UI;

namespace ru.tj.platformer.KnightAdventure.ui {
    [RequireComponent(typeof(Image))]
    public class HealthIcon : MonoBehaviour {
        private Image image;
        private bool isActive;

        private void Awake() {
            isActive = true;
            image = GetComponent<Image>();
        }

        public bool IsEnable() {
            return isActive;
        }

        public void Enable() {
            isActive = true;
            image.color = Color.white;
        }

        public void Disable() {
            isActive = false;
            image.color = Color.black;
        }
    }
}