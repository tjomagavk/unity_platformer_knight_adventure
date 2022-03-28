using UnityEngine;
using UnityEngine.SceneManagement;

namespace ru.tj.platformer.KnightAdventure {
    public class SceneController {
        private static bool isPause;

        public static void LoadScene(int index) {
            SceneManager.LoadScene(index);
        }

        public static void LoadMainMenu() {
            SceneManager.LoadScene(0);
            Play();
        }

        public static void LoadNextScene() {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeScene + 1);
        }

        public static void ReloadScene() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Play();
        }

        public static void ChangePlayPause() {
            if (isPause) {
                Time.timeScale = 1f;
            } else {
                Time.timeScale = 0;
            }

            isPause = !isPause;
        }


        private static void Play() {
            Time.timeScale = 1f;
            isPause = false;
        }
    }
}