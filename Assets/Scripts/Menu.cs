using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class Menu : MonoBehaviour {

        private float _countdown = OptionStuff.StartTimer;

        public static int HitMouse = 0;

        public GameObject TimeL;

        public void Update() {
            Simul();
            TextChange();
            if (_countdown >= 0.1f) {
                _countdown -= Time.deltaTime;
            }
        }

        public void TextChange() {
            switch (tag) {
                case "Diff":
                    GetComponent<TextMeshProUGUI>().text =
                        "Nuværende sværhedsgrad: " + Mathf.Floor(OptionStuff.OptionDifficulty * 100) / 100;
                    break;

                case "MouseText":
                    GetComponent<TextMeshProUGUI>().text = "Nuværende antal Mus: " + OptionStuff.Simul;
                    break;

                case "Counter":
                    GetComponent<TextMeshProUGUI>().text = "Mus ramt: " + HitMouse;
                    break;

                case "StartText":
                    GetComponentInChildren<TextMeshProUGUI>().text = "" + Mathf.Floor(_countdown);
                    break;

                case "TimeText":
                    GetComponent<TextMeshProUGUI>().text = "" + Math.Ceiling(OptionStuff.TimeLeft);
                    break;

                case "Start":
                    PauseMenu.GameIsPaused = false;

                    if (_countdown < 0.9f) {
                        if (OptionStuff.TimeOn && OptionStuff.TimeLeft > 0) {
                            TimeL.SetActive(true);
                        }
                        Destroy(gameObject);
                    }

                    if (OptionStuff.TimeLeft <= 1) {
                        TimeL.SetActive(false);
                    }

                    break;
            }
        }

        public void StartGame() //Denne funktion starter den angivne scene
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

        public void Simul() {
            if (OptionStuff.OptionDifficulty >= 2) {
                OptionStuff.Simul = 1;
            }
            else if (OptionStuff.OptionDifficulty >= 1) {
                OptionStuff.Simul = 2;
            }
            else {
                OptionStuff.Simul = 3;
            }
        }
    }
}