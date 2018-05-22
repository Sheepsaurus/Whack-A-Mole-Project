using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class TimeLeft : MonoBehaviour {
        public InputField TimeLeftValue;

        public void Update() {
            Parsing();
        }

        public void Parsing() {
            // PARSE THE STRING VALUE TO A FLOAT VALUE
            if (float.TryParse(TimeLeftValue.text, out OptionStuff.AdjustedValue)) {
                OptionStuff.TimeLeft = OptionStuff.AdjustedValue;
            }
        }

        public void WeaponSelect(int WeaponSprite)
        {
            OptionStuff.WeaponSelect = WeaponSprite;
        }
    }
}
