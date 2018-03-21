using UnityEngine;


namespace Assets.Scripts
{
    public class MouseMovement : MonoBehaviour {

        private float _timer = OptionStuff.OptionDifficulty, _maxY, _originalY;

        private const float SpeedAdjustDown = 4;

        public Sprite[] Mouse;

        private bool _hasBeenClicked;
        
        private void Awake() {
            _originalY = transform.position.y;
            _maxY = _originalY + 3.4f;
            _timer = OptionStuff.OptionDifficulty * OptionStuff.Simul;
            _hasBeenClicked = false;
            Simul();
        }
	
        // Update is called once per frame
        private void Update () {
            _timer -= Time.deltaTime;
            MouseBehaviour(12 - OptionStuff.OptionDifficulty);
        }

        public void MouseBehaviour(float speedAdjustUp) {

            if (!_hasBeenClicked) {
               
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
                    Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    Vector2 touchPos = new Vector2(wp.x, wp.y);

                    if (GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos)) {
                        if (!PauseMenu.GameIsPaused)
                        {
                            _hasBeenClicked = true;
                            Menu.HitMouse++;
                            gameObject.GetComponent<BoxCollider2D>().enabled = false;
                            gameObject.GetComponent<SpriteRenderer>().sprite = Mouse[2];
                            InvokeRepeating("Clicked", 0.5f, 0.00002f);
                        }
                        //Destroy(gameObject);
                    }
                }
                else if (_timer < (OptionStuff.OptionDifficulty * OptionStuff.Simul)/2) {
                    gameObject.GetComponent<SpriteRenderer>().sprite = Mouse[1];

                    if (_timer < 0) {
                    transform.Translate(0, -(SpeedAdjustDown * Time.deltaTime), 0);
                    }

                    if (transform.position.y < _originalY) {
                        Destroy(gameObject);
                    }
                }
                else if (transform.position.y < _maxY) {
                    transform.Translate(0, speedAdjustUp * Time.deltaTime, 0);
                }
            }
        }

        private void Clicked() {
            if (_hasBeenClicked) {
                transform.Translate(0, -(SpeedAdjustDown/2 * Time.deltaTime), 0);

                if (transform.position.y < _originalY) {
                    Destroy(gameObject);
                }
            }
        }

         private void OnMouseDown() {
             if (!PauseMenu.GameIsPaused) {
                 _hasBeenClicked = true;
                 Menu.HitMouse++;
                 gameObject.GetComponent<BoxCollider2D>().enabled = false; 
                 gameObject.GetComponent<SpriteRenderer>().sprite = Mouse[2];
                 InvokeRepeating("Clicked", 0.5f, 0.00002f);
             }
         }

        public void Simul() {
            if (OptionStuff.OptionDifficulty >= 7) {
                OptionStuff.Simul = 2;
            } else if (OptionStuff.OptionDifficulty >= 4) {
                OptionStuff.Simul = 3;
            } else {
                OptionStuff.Simul = 4;
            }
        }
    }
}
