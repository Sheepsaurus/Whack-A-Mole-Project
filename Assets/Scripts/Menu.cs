using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Menu : MonoBehaviour {

        private float _countdown = OptionStuff.StartTimer;

        public static int HitMouse = 0;

        public GameObject TimeL;

        public GameObject TimeText;

        public void Update() {
            TextChange();
            
            _countdown -= Time.deltaTime;
            
        }

        public void TextChange() {
            if (tag == "Diff") {
                GetComponent<TextMeshProUGUI>().text = "Nuværende sværhedsgrad: " + OptionStuff.OptionDifficulty;
            }
            if (tag == "Counter") {
                GetComponent<TextMeshProUGUI>().text = "Mus ramt: " + HitMouse;
            }
            if (tag == "Start") {

                if (_countdown < 0.2f) {
                    TimeL.SetActive(true);
                    TimeText.SetActive(true);
                    Destroy(gameObject);
                } 
            }
            
            if (tag == "StartText") {
                GetComponentInChildren<TextMeshProUGUI>().text =  "" + Mathf.Floor(_countdown);

                if (_countdown < 0.2f) {
                    PauseMenu.GameIsPaused = false;
                    Destroy(gameObject);
                }

            }
            
            if (tag == "TimeText") {

                if (_countdown < 0.1f) {
                    PauseMenu.GameIsPaused = false;
                    GetComponentInChildren<TextMeshProUGUI>().text =  "" + Math.Ceiling(Modifier.TimeLeft);
                }

            }
        }

        public void StartGame() //Denne funktioner starter den angivne scene
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame() //Denne funktion slukker spillet, og har en Debug.Log til at vise dette i konsollen
        {
            Debug.Log("YOU PRESSED QUIT");
            Application.Quit();
        }

        public void Difficulty(float slideValue) {
            OptionStuff.OptionDifficulty = Math.Abs(slideValue);
        }

        public static class Modifier {
            public static float TimeLeft = 120;
        }
    }
}
