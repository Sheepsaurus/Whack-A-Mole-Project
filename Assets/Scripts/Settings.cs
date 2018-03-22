using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Settings : MonoBehaviour {

        public InputField TimeLeft;

        void Start() {
            DontDestroyOnLoad(transform.gameObject);

            if (float.TryParse(TimeLeft.text, out OptionStuff.AdjustedValue)) {
                Menu.Modifier.TimeLeft = OptionStuff.AdjustedValue;
            }
        }
        
        public void Difficulty(float slideValue) {
            OptionStuff.OptionDifficulty = Math.Abs(slideValue);
        }
    }

    public static class OptionStuff {
        public static float OptionDifficulty = 10f;
        public static float StartTimer = 5.9f;
        public static int Simul = 3;
        public static float AdjustedValue;
    }
}
