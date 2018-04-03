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
            switch (tag) {
                case "Diff":
                    GetComponent<TextMeshProUGUI>().text = "Nuværende sværhedsgrad: " + OptionStuff.OptionDifficulty;
                    break;

                case "Counter":
                    GetComponent<TextMeshProUGUI>().text = "Mus ramt: " + HitMouse;
                    break;

                case "StartText":
                    GetComponentInChildren<TextMeshProUGUI>().text = "" + Mathf.Floor(_countdown);
                    break;

                case "TimeText":
                    GetComponentInChildren<TextMeshProUGUI>().text = "" + Math.Ceiling(OptionStuff.TimeLeft);
                    break;

                case "Start":
                    PauseMenu.GameIsPaused = false;

                    if (_countdown < 0.9f) {
                        if (OptionStuff.TimeOn && OptionStuff.TimeLeft > 0) {

                            TimeL.SetActive(true);
                            TimeText.SetActive(true);
                        }
                        Destroy(gameObject);
                    }

                    if (OptionStuff.TimeLeft <= 0) {
                        TimeL.SetActive(false);
                        TimeText.SetActive(false);
                    }
                break;
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
    }
}