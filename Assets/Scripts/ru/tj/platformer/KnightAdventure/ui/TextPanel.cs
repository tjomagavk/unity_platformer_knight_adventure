using TMPro;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.ui {
    public class TextPanel : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI text;

        private void Awake() {
            text.SetText("0");
        }

        public void SetValue(int value) {
            text.SetText(value.ToString());
        }
    }
}