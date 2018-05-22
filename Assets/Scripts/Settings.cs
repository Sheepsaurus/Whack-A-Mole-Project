using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Settings : MonoBehaviour {
        #region Value Modifications

        public void Start() {
            // CARRY THE OBJECT WITH THIS SCRIPT ON, TO THE NEXT SCENE
            DontDestroyOnLoad(transform.gameObject);
        }

        public void Update() {
            Simul();
            Debug.Log(OptionStuff.WeaponSelect);
        }

        // METHOD TO CHANGE THE VALUE OF THE DIFFICULTY
        public void Difficulty(float slideValue) {
            OptionStuff.OptionDifficulty = Math.Abs(slideValue);
        }
        
        // METHOD TO CHANGE THE VALUE OF THE DIFFICULTY
        public void WeaponSelect(int WeaponSprite) {
            OptionStuff.WeaponSelect = WeaponSprite;
        }

        // METHOD TO TOGGLE TimeOn, ON OR OFF
        public void TimeEnabled(bool Checked) {
            OptionStuff.TimeOn = Checked;
        }

        public void Simul() {
            if (OptionStuff.OptionDifficulty >= 2) {
                OptionStuff.Simul = 4;
            }
            else if (OptionStuff.OptionDifficulty >= 1) {
                OptionStuff.Simul = 3;
            }
            else {
                OptionStuff.Simul = 2;
            }
        }

        #endregion
    }
    #region Static Values
    public static class OptionStuff {

        // THE DEFAULT DIFFICULTY VALUE
        public static float OptionDifficulty = 2.5f;

        // THE DEFAULT STARTING TIME
        public static float StartTimer = 5.9f;

        // THE PARSED VALUE GIVEN TO TIMELEFT
        public static float AdjustedValue;

        //
        public static float TimeLeft;

        // THE DEFAULT AMOUNT OF MAXIMUM SIMULTANIOUS PREFABS
        public static int Simul = 3;

        // THE CHECKMARK TO DEFINE IF TIME IS SET TO ON
        public static bool TimeOn = false;

        public static int WeaponSelect;
    }
    #endregion
}