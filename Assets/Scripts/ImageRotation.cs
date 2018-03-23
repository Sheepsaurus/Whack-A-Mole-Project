using UnityEngine;

namespace Assets.Scripts
{
    public class ImageRotation : MonoBehaviour
    {
        public float RotationSpeed;

        public void Update () {
            transform.Rotate(0, 0, RotationSpeed); // ROTATE THE GAMEOBJECT ON THE Z AXIS
        }
    }
}