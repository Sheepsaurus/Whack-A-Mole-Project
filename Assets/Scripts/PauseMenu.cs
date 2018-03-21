using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class PauseMenu : MonoBehaviour {

        public static bool GameIsPaused = false; //bool for checking if the game is paused or not 
        public GameObject PauseMenuUI; //a panel with all the UI buttons on that will activate when the game is paused
        public Button PauseButton; //Reference to the UI Button Pause
        public Button ResumeButton; //Reference to the UI Button Resume
        public Button SettingsButton; //Reference to the UI Button Settings 
        public Button MenuButton; //Reference to the UI Button Main Menu

        void Update() {
            PauseButton.onClick.AddListener(Pause); //If the Pause Button is clicked it will run the Pause method
            ResumeButton.onClick.AddListener(Resume); //If the Resume Button is clicked it will run the Resume method     
        }

        //Pause Method
        private void Pause() { 
            PauseMenuUI.SetActive(true); //Activates the PauseMenuUI so we see the Other UI buttons
            Time.timeScale = 0f; //Stops the time of the game
            GameIsPaused = true; //Sets the GameIsPaused to true 
        }

        //Resume Method
        public void Resume() {
            PauseMenuUI.SetActive(false); //Deactivates the PauseMenuUI so you see the game
            Time.timeScale = 1f; //Sets the time to realtime and lets the game run
            GameIsPaused = false; //Sets the GameIsPaused to false 
        }

        //Menu Method
        public void Menu() {
            Scripts.Menu.HitMouse = 0; //Resets the MouseHit Count
            OptionStuff.OptionDifficulty = 10; //Resets the DifficultySlider to the default value
            SceneManager.LoadScene(0); //Loads the Menu Scene
        }
    }
}
	


