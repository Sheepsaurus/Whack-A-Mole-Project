using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts { 

    public class Instantiate : MonoBehaviour {

        public Transform[] SpawnPoints;

        public Transform NpcPrefab;

        public Vector3 Offset;

        public float Countdown = OptionStuff.OptionDifficulty, RandomCountdown = OptionStuff.OptionDifficulty, StartCountdown = OptionStuff.StartTimer;

        private int _newValue;

        public static List<int> RandomValues = new List<int>(5);

        public void Update() {
            if (StartCountdown > 0) {
                StartCountdown -= Time.deltaTime;
            }
            
            if (RandomCountdown > 0) {
                RandomCountdown -= Time.deltaTime;
               // Debug.Log("There are " + RandomCountdown + " random seconds left");
            }

            if (Countdown > 0) {
                Countdown -= Time.deltaTime;
               // Debug.Log("There are " + Countdown + " seconds left");
            }
            SpawnerMove();
            NpcSpawner();
        }

        private void NpcSpawner() {

            if (Countdown <= 0.1f) { // If the time is up, and it has not yet "spawned"
                Instantiate(NpcPrefab, transform.position, Quaternion.identity); // Spawn **THIS PREFAB**, at the location of this scripts Transform, with this scripts, locations, rotation
                
                Countdown = OptionStuff.OptionDifficulty; // Reset the countdown, to restart the Spawning process
            }
        }
        
        public void SpawnerMove() { // Use Time.deltaTime to _randomCountdown in Realtime
 
            if (RandomValues.Count < OptionStuff.OptionDifficulty + 4) {
                _newValue = Random.Range(0, SpawnPoints.Length);
                if (!RandomValues.Contains(_newValue)) { //If the new value given, isn't already in the list, add it to the list
                    RandomValues.Add(_newValue);
                    Debug.Log("There are now " + RandomValues.Count + " random values");
                }
            }



            if (RandomCountdown <= 0 && RandomValues.Count > 0 && StartCountdown <= 0){ // If it has recently spawned something, and the _randomCountdown is done,
                                                                                 // and there are values left in your list
                for (int i = 0; i < SpawnPoints.Length; i++) {
                    if (i == RandomValues[0]) {
                        transform.position = SpawnPoints[i].position + Offset;
                    }
                }
                
                
                RandomValues.RemoveAt(0);
                RandomCountdown = OptionStuff.OptionDifficulty;
            }
        }
    }
}
