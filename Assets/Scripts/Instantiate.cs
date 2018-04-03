using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Instantiate : MonoBehaviour {
        #region INITIALIZATION
        // THE SPAWNPOINTS IN AN ARRAY
        public Transform[] SpawnPoints;

        // REFERENCE TO GAME END MENU
        public GameObject GameEnd;

        // THE PREFAB USED AS A REFERENCE TO WHAT TO SPAWN BY THE INSTANTIATE
        public Transform NpcPrefab;

        // THE OFFSET USED TO MAKE SURE THE SPAWNED PREFAB IS POSITIONED CORRECTLY (Y + Z OFFSET)
        public Vector3 Offset;

        // COUNTDOWNS INITIALISED
        private float _countdown = OptionStuff.OptionDifficulty / 2; // HALVED TO OFFSET
        private float _randomCountdown = OptionStuff.OptionDifficulty; 
        private float _startCountdown = OptionStuff.StartTimer;      // 5 SECONDS ON THE START TIMER
        
        // RANDOM GENERATOR VALUE
        private int _newValue; // THIS VALUE IS COMPARED TO THE CURRENT VALUES IN THE LIST OF RANDOM VALUES - IF IT IS NOT ALREADY THERE, IT'S ADDED

        // LIST OF RANDOM VALUES
        public static List<int> RandomValues = new List<int>(); // GIVEN IN INT
        private bool _needToBeFilled;                           // DETERMINES IF THE LIST NEEDS TO BE FILLED UP AGAIN

        #endregion
        
        #region START AND UPDATE

        // IS ALWAYS CALLED AT THE CLICK OF THE PLAY BUTTON
        public void Start() {

            // SET THE _needToBeFilled VALUE TO TRUE, SO IT WILL START TO FILL UP THE LIST
            _needToBeFilled = true;
            
        }

        public void Update() {

            #region COUNTDOWNS

            // A VISUAL COUNTDOWN, THAT SHOWS HOW MANY SECONDS WILL PASS, UNTIL THE GAME STARTS
            if (_startCountdown > 0) {
                _startCountdown -= Time.deltaTime;
            }

            // A COUNTDOWN THAT TELLS THE GAME WHEN TO CREATE NEW RANDOM VALUES
            if (_randomCountdown > 0) {
                _randomCountdown -= Time.deltaTime;
            }

            // A COUNTDOWN THAT TELLS THE GAME WHEN TO MOVE THE SPAWNER
            if (_countdown > 0) {
                _countdown -= Time.deltaTime;
            }

            // A VISUAL COUNTDOWN THAT TELLS THE GAME HOW MANY SECONDS ARE LEFT UNTIL THE GAME IS OVER
            if (OptionStuff.TimeLeft > 0 && _startCountdown < 0.1f && OptionStuff.TimeOn) {
                OptionStuff.TimeLeft -= Time.deltaTime; // REDUCES THE VALUE OF Menu.Modifier.TimeLeft IN REALTIME

                if (OptionStuff.TimeLeft <= 0) {
                    GameEnd.SetActive(true);       // ENABLES THE Game End GAMEOBJECT
                    Time.timeScale = 0f;           // SETS THE SPEED AT WHICH TIME PASSES TO 0
                    PauseMenu.GameIsPaused = true; // SETS GameIsPaused TO TRUE

                }
            }
            #endregion

            // CALLING THE METHODS IN THIS ORDER: FIRST MOVE, THEN SPAWN - OVER AND OVER
            SpawnerMove();
            NpcSpawner();
        }

        #endregion

        #region SPAWNER

        // THIS METHOD SPAWNS THE PREFAB
        private void NpcSpawner() {

            if (_countdown <= 0) { // IF THE COUNTDOWN IS LESS THAN, OR EQUAL TO 0, EXECUTE THE FOLLOWING CODE
                Instantiate(NpcPrefab, transform.position, Quaternion.identity); // SPAWN THE SELECTED PREFAB, AT THE SPECIFIED LOCATION, WITH THE SPECIFIC ROTATION
                
                _countdown = OptionStuff.OptionDifficulty; // RESET THE COOLDOWN, TO ALLOW IT TO LOOP
            }
        }
        
        #endregion

        #region SPAWER MOVE

        // THIS METHOD MOVES THE SPAWNER, AFTER THE SPAWNER HAS SPAWNER
        public void SpawnerMove() {
 
            while (RandomValues.Count < 7 && _needToBeFilled) { // WHILE THE LIST OF RANDOM VALUES HAS LESS THAN 7 VALUES, AND IT NEEDS TO BE FILLED, EXECUTE THE FOLLOWING CODE
                _newValue = Random.Range(0, SpawnPoints.Length); // PROVIDE _newValue WITH A NEW VALUE
                if (!RandomValues.Contains(_newValue)) { // COMPARE THE NEWLY PROVIDED _newValue TO THE LIST - IF THE VALUE IS IN THE LIST, DO NOTHING
                    RandomValues.Add(_newValue); // ADD THE VALUE _newValue TO THE LIST OF RANDOM VALUES
                }
            }
            
            // WHEN THE LIST OF RANDOM VALUES HITS 7, THE ABOVE CODE STOPS RUNNING, AND IT REACHES THIS POINT. THEN IT WILL KNOW THAT IT NO LONGER NEEDS TO BE FILLED.
            _needToBeFilled = false;

            // IF THE _randomCountdown AND _startCountdown HAVE REACHED 0, AND THE LIST OF RANDOM VALUES HAS AT LEAST 1 VALUE IN IT, DO THE FOLLOWING CODE
            if (_randomCountdown <= 0 && RandomValues.Count > 0 && _startCountdown <= 0)
            {
                // CHECK THE NUMBERS 0-6, IN ORDER, TO FIND OUT WHICH OF THOSE 7 NUMBERS ARE THE FIRST NUMBER IN THE LIST OF RANDOM VALUES
                for (int i = 0; i < SpawnPoints.Length; i++) {
                    if (i == RandomValues[0]) {
                        transform.position = SpawnPoints[i].position + Offset; // IF IT MATCHES, MOVE TO THAT POSITION
                    }
                }

                // THEN REMOVE THE FIRST VALUE IN THE LIST OF RANDOM VALUES, AND RESET THE COUNTDOWN SO IT WON'T RUN AGAIN, UNTIL IT NEEDS TO
                RandomValues.RemoveAt(0);
                _randomCountdown = OptionStuff.OptionDifficulty;

            }

            // IF THE LIST OF RANDOM VALUES HAS LESS THAN THE SPECIFIED AMOUNT OF VALUES, SET _needToBeFilled TO TRUE, SO IT WILL GET FILLED UP AGAIN
            if (RandomValues.Count < OptionStuff.Simul + 1) {
                _needToBeFilled = true;
            }
        }
        #endregion
    }
}