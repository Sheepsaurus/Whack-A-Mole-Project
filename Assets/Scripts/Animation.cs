using UnityEngine;

namespace Assets.Scripts {
    public class Animation : MonoBehaviour {

        private Animator animator;

        public void Awake() {
            animator = GetComponent<Animator>();
        
            animator.Play("WeaponSwing");
            
        }

        public static int played = 0;

        public void changePlayed (int value) {
            Animation.played = value;
        }

    }
}
