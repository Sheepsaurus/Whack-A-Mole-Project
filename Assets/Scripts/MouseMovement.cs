using UnityEngine;

namespace Assets.Scripts {
    public class MouseMovement : MonoBehaviour {
        #region Initializations

        private float _timer = OptionStuff.OptionDifficulty, // A TIMER
                      _maxY, // THE MAXIMUM Y POSITION THE MICE CAN MOVE TO
                      _originalY, // THE ORIGINAL Y POSITION OF THE MICE, UPON SPAWNING
                      _randomizer;

        private const float SpeedAdjustDown = 3; // VALUE THAT DETERMINES THE SPEED AT WHICH THE MICE GO DOWNWARDS

        public Sprite[] Mouse; // REFERENCE TO THE SPRITES

        private bool _hasBeenClicked; // BOOL TO DETERMINE IF THE MOUSE HAS BEEN CLICKED

        // AWAKE IS USED TO SET INITIAL VALUES, UPON BEING SPAWNED. WHERE DOES IT SPAWN, WHERE CAN IT GO TO, HOW LONG CAN IT LIVE
        // IT HAS NOT YET BEEN CLICKED, AND THERE CAN ONLY BE "SO MANY" ALIVE
        private void Awake() {
            _originalY = transform.position.y;
            _maxY = _originalY + 3.4f;
            _timer = OptionStuff.OptionDifficulty * OptionStuff.Simul + 1;
            _hasBeenClicked = false;
            Simul();
            _randomizer = float.Parse(Random.Range(1, 9).ToString())/10;
        }

        #endregion

        #region Methods

        // Update is called once per frame
        private void Update() {
            _timer -= Time.deltaTime; // INTERNAL TIMER, THAT GOES DOWN IN REALTIME

            Invoke("MouseBehaviour", _randomizer); // THE DIFFICULTY SLIDER HAS VALUES 5 -> 1, THIS INVERTS IT
            
        }
            #region Mouse Behaviour
            public void MouseBehaviour() {
            #region CLICK
                // IF THE MOUSE HAS NOT YET BEEN CLICKED
                if (!_hasBeenClicked) {
                    // IF THE USER HAS CLICKED, AND ENDED THEIR CLICK
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
                        Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); // CREATE A Vector3 BASED ON THE POSITION
                        // OF THE TOUCH

                        Vector2 touchPos = new Vector2(wp.x, wp.y); // CREATE A NEW Vector2 VALUE, WITH THE X
                        // AND Y VALUES OF OUR NEWLY CREATED Vector3

                        // IF THE BOX COLLIDER OF OUR MOUSE OVERLAPS WITH THE X AND Y OF THE TOUCH POSITION
                        if (GetComponent<BoxCollider2D>() == Physics2D.OverlapPoint(touchPos)) {
                            // IF THE GAME IS NOT CURRENTLY PAUSED
                            if (!PauseMenu.GameIsPaused) {
                                _hasBeenClicked = true; // THE MOUSE HAS NOW BEEN CLICKED
                                Menu.HitMouse++; // THE TOTAL AMOUNT OF MICE HIT, GOES UP BY 1

                                gameObject.GetComponent<BoxCollider2D>().enabled = false; // DISABLES THE BOXCOLLIDER OF OUR MOUSE
                                gameObject.GetComponent<SpriteRenderer>().sprite = Mouse[2]; // CHANGES THE SPRITE OF OUR GAMEOBJECT

                                InvokeRepeating("Clicked", 0.5f, 0.00002f); // INVOKES THE METHOD "CLICKED", AFTER 0.5
                                                                            // SECONDS AND EVERY 0.00002 SECONDS (CONSTANT)
                            }
                        }
                    }
                    #endregion

                    // OTHERWISE, IF THE INTERNAL TIMER REACHES HALF OF THE LIFESPAN OF THE MOUSE
                    else if (_timer < (OptionStuff.OptionDifficulty * OptionStuff.Simul) / 2) {
                        gameObject.GetComponent<SpriteRenderer>().sprite = Mouse[1]; // CHANGES THE SPRITE OF OUR MOUSE

                        // IF THE INTERNAL TIMER HAS REACHED 0
                        if (_timer < 0) {
                            transform.Translate(0, -((16 - OptionStuff.OptionDifficulty) * Time.deltaTime), 0); // MOVE GAMEOBJECT DOWNWARDS ON THE Y AXIS
                        }

                        // IF THE GAMEOBJECT REACHES A LOWER Y-POSITION THAN IT ORIGINALLY SPAWNED AT
                        if (transform.position.y < _originalY) {
                            Destroy(gameObject); // DESTROY THE GAMEOBJECT
                        }
                    }

                    // OTHERWISE, IF THE CURRENT POSITION ON THE Y AXIS IS LOWER THAN THE _maxY VALUE
                    else if (transform.position.y < _maxY) {
                        transform.Translate(0, (16 - OptionStuff.OptionDifficulty) * Time.deltaTime, 0); // MOVE GAMEOBJECT UPWARDS ON THE Y AXIS
                    }
                }
            }
            #endregion
        
        private void Clicked() {
            // IF _hasBeenClicked IS TRUE
            if (_hasBeenClicked) {
                transform.Translate(0, -(SpeedAdjustDown / 2 * Time.deltaTime), 0); // MOVE THE GAMEOBJECT DOWNWARDS ON THE Y AXIS
            }
            if (transform.position.y < _originalY) {
                Destroy(gameObject); // DESTROY THE GAMEOBJECT
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
            if (OptionStuff.OptionDifficulty >= 2) {
                OptionStuff.Simul = 4;
            }
            else if (OptionStuff.OptionDifficulty >= 1) {
                OptionStuff.Simul = 3;
            }
            else {
                OptionStuff.Simul = 2;
            }
        }
        #endregion
    }
}