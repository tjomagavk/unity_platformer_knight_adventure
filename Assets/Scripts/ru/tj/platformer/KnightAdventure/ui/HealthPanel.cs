using System.Collections.Generic;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.ui {
    public class HealthPanel : MonoBehaviour {
        [SerializeField] private HealthIcon heathPrefab;

        private List<HealthIcon> icons = new List<HealthIcon>();

        public void SetMaxHealth(int count) {
            foreach (HealthIcon icon in icons) {
                Destroy(icon.gameObject);
            }

            icons.Clear();
            AddMaxHealth(count);
        }

        public void SetCurrentHealth(int count) {
            if (count >= 0) {
                for (int i = icons.Count - 1; i >= 0; i--) {
                    if (count == 0) {
                        icons[i].Disable();
                    } else {
                        icons[i].Enable();
                        count--;
                    }
                }
            }
        }

        public void AddMaxHealth(int count) {
            for (int i = 0; i < count; i++) {
                icons.Add(Instantiate(heathPrefab, gameObject.transform));
            }
        }

        public void ChangeHealth(int count) {
            if (count < 0) {
                for (int i = 0; i < icons.Count; i++) {
                    if (icons[i].IsEnable()) {
                        icons[i].Disable();
                        count++;
                    }

                    if (count == 0) {
                        break;
                    }
                }
            }

            if (count > 0) {
                for (int i = icons.Count - 1; i >= 0; i--) {
                    if (!icons[i].IsEnable()) {
                        icons[i].Enable();
                        count--;
                    }

                    if (count == 0) {
                        break;
                    }
                }
            }
        }
    }
}