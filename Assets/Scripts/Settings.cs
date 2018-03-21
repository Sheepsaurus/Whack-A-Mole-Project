using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Settings : MonoBehaviour {

        public static InputField TimeLeft;

        void Start() {
            DontDestroyOnLoad(transform.gameObject);
        }
        
        public void Difficulty(float slideValue) {
            OptionStuff.OptionDifficulty = Math.Abs(slideValue);

        }
    }

    public static class OptionStuff {
        public static float OptionDifficulty = 10f;
        public static float StartTimer = 5.9f;
        public static int Simul = 3;
    }
}
