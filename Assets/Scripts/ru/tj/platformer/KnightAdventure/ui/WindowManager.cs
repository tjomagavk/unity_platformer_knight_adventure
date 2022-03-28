using System.Collections;
using UnityEngine;

namespace ru.tj.platformer.KnightAdventure.ui {
    public class WindowManager {
        private Canvas canvas;
        private GameObject deathWindow;

        public WindowManager(Canvas canvas, GameObject deathWindow) {
            this.canvas = canvas;
            this.deathWindow = deathWindow;
        }

        public IEnumerator DeathWindowActivate(float seconds) {
            yield return new WaitForSeconds(seconds);
            GameObject.Instantiate(deathWindow, canvas.transform, false);
        }
    }
}