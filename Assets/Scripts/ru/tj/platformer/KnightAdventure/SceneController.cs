using UnityEngine;
using UnityEngine.SceneManagement;

namespace ru.tj.platformer.KnightAdventure {
    public class SceneController {
        private static bool isPause;

        public void LoadScene(int index) {
            SceneManager.LoadScene(index);
        }

        public void LoadMainMenu() {
            SceneManager.LoadScene(0);
            Play();
        }

        public void LoadNextScene() {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeScene + 1);
        }

        public void ReloadScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Play();
        }

        public void ChangePlayPause() {
            if (isPause) {
                Time.timeScale = 1f;
            } else {
                Time.timeScale = 0;
            }

            isPause = !isPause;
        }


        private void Play() {
            Time.timeScale = 1f;
            isPause = false;
        }
    }
}