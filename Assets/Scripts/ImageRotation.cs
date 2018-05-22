using NUnit.Framework.Constraints;
using UnityEngine;

namespace Assets.Scripts
{
    public class ImageRotation : MonoBehaviour {

        public float rotationSpeed;
        private float rotationValue;

        public void Update() {
            rotationValue = Mathf.LerpAngle(10, -10, rotationSpeed);
            transform.rotation = Quaternion.Euler(0, 0, rotationValue);
        }

    }
}