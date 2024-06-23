using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [SerializeField] private GameObject pausePanel;
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                StopGame();
            }
        }

        public void StopGame() {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    
        public void ResumeGame() {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
