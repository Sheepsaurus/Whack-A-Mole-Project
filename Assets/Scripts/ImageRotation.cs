using NUnit.Framework.Constraints;
using UnityEngine;

namespace Assets.Scripts
{
    public class ImageRotation : MonoBehaviour {
        private bool goClockwise = true;

        public float RotationSpeed;

        public void Update () {
            if (goClockwise) {
                transform.Rotate(0, 0, RotationSpeed * Time.deltaTime); // ROTATE THE GAMEOBJECT ON THE Z AXIS
                if (transform.eulerAngles.z >= 10) {
                    goClockwise = false;
                }
            }
            else {
                transform.Rotate(0, 0, -RotationSpeed * Time.deltaTime); // ROTATE THE GAMEOBJECT ON THE Z AXIS
                if (transform.eulerAngles.z <= -10) {
                    goClockwise = false;
                }
            }
        }
    }
}