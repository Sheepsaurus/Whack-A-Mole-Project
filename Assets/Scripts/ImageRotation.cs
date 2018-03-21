using UnityEngine;

namespace Assets.Scripts
{
    public class ImageRotation : MonoBehaviour
    {

        public float RotationSpeed;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
            transform.Rotate(0, 0, RotationSpeed); //Rotér billedet, baseret på "rotationSpeed"
        }
    }
}
