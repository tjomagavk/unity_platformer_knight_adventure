using UnityEngine;
using UnityEngine.UI;

namespace ru.tj.platformer.KnightAdventure.ui {
    public class TextPanel : MonoBehaviour {
        [SerializeField] private Text text;

        private void Awake() {
            text.text = "0";
        }

        public void SetValue(int value) {
            text.text = value.ToString();
        }
    }
}