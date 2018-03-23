using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Settings : MonoBehaviour {
        #region Initializations
        // REFERENCE TO THE INPUTFIELD IN THE SETTINGS MENU
        public InputField TimeLeft;
        #endregion

        #region Value Modifications

        public void Start() {
            // CARRY THE OBJECT WITH THIS SCRIPT ON, TO THE NEXT SCENE
            DontDestroyOnLoad(transform.gameObject);

            // PARSE THE STRING VALUE TO A FLOAT VALUE
            if (float.TryParse(TimeLeft.text, out OptionStuff.AdjustedValue)) {
                Menu.Modifier.TimeLeft = OptionStuff.AdjustedValue;
            }
        }
        
        // METHOD TO CHANGE THE VALUE OF THE DIFFICULTY
        public void Difficulty(float slideValue) {
            OptionStuff.OptionDifficulty = Math.Abs(slideValue);
        }

        // METHOD TO TOGGLE TimeOn, ON OR OFF
        public void TimeEnabled(bool Checked) {
            OptionStuff.TimeOn = Checked;
        }

        #endregion
    }
    #region Static Values
    public static class OptionStuff {

        // THE DEFAULT DIFFICULTY VALUE
        public static float OptionDifficulty = 10f;

        // THE DEFAULT STARTING TIME
        public static float StartTimer = 5.9f;

        // THE DEFAULT AMOUNT OF MAXIMUM SIMULTANIOUS PREFABS
        public static int Simul = 3;

        // THE PARSED VALUE GIVEN TO TIMELEFT
        public static float AdjustedValue;

        // THE CHECKMARK TO DEFINE IF TIME IS SET TO ON
        public static bool TimeOn = false;
    }
    #endregion
}