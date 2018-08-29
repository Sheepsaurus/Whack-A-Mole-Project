using UnityEngine;

namespace Assets.Scripts {
    public class Animation : MonoBehaviour {

        private Animator _animator;

        public void Awake() {
            _animator = GetComponent<Animator>();
        
            _animator.Play("WeaponSwing");
        }

        public static int Played;

        public void changePlayed (int value) {
            Played = value;
        }

    }
}
