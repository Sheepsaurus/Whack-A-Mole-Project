using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MainMenu : MonoBehaviour {

        void Update() {
            TextChange();
        }

        public void TextChange() {
            if (tag == "Mutable") {
                GetComponent<TextMeshProUGUI>().text = "Nuværende sværhedsgrad: " + OptionStuff.OptionDifficulty;
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

    }
}
