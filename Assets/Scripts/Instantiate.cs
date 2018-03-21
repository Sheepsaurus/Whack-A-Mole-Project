using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Instantiate : MonoBehaviour {

        public Transform[] SpawnPoints;

        public Transform NpcPrefab;

        public Vector3 Offset;

        private float _countdown = OptionStuff.OptionDifficulty/2, _randomCountdown = OptionStuff.OptionDifficulty, _startCountdown = OptionStuff.StartTimer;

        private static float _timeLeft;

        private int _newValue;

        public static List<int> RandomValues = new List<int>();
        private bool _needToBeFilled;

        public void Start() {
            _needToBeFilled = true;
            _timeLeft = float.Parse(Settings.TimeLeft.text);
        }

        public void Update() {
            if (_startCountdown > 0) {
                _startCountdown -= Time.deltaTime;
            }
            
            if (_randomCountdown > 0) {
                _randomCountdown -= Time.deltaTime;
               // Debug.Log("There are " + RandomCountdown + " random seconds left");
            }

            if (_countdown > 0) {
                _countdown -= Time.deltaTime;
               // Debug.Log("There are " + Countdown + " seconds left");
            }

            if (_timeLeft > 0) {
                _timeLeft -= Time.deltaTime;
                if (_timeLeft == 0) {
                    return;
                }
            }


            SpawnerMove();
            NpcSpawner();
        }

        private void NpcSpawner() {

            if (_countdown <= 0) { // If the time is up, and it has not yet "spawned"
                Instantiate(NpcPrefab, transform.position, Quaternion.identity); // Spawn **THIS PREFAB**, at the location of this scripts Transform, with this scripts, locations, rotation
                
                _countdown = OptionStuff.OptionDifficulty; // Reset the countdown, to restart the Spawning process
            }
        }
        
        public void SpawnerMove() { // Use Time.deltaTime to _randomCountdown in Realtime
 
            while (RandomValues.Count < 7 && _needToBeFilled) {
                _newValue = Random.Range(0, SpawnPoints.Length);
                if (!RandomValues.Contains(_newValue)) { //If the new value given, isn't already in the list, add it to the list
                    RandomValues.Add(_newValue);
                    Debug.Log("There are now " + RandomValues.Count + " random values");
                }
            }
            
            _needToBeFilled = false;

            if (_randomCountdown <= 0 && RandomValues.Count > 0 && _startCountdown <= 0) // If it has recently spawned something, and the _randomCountdown is done,
            {                                                                     // and there are values left in your list
                for (int i = 0; i < SpawnPoints.Length; i++) {
                    if (i == RandomValues[0]) {
                        transform.position = SpawnPoints[i].position + Offset;
                    }
                }

                RandomValues.RemoveAt(0);
                //Debug.Log("There are now " + RandomValues.Count + " random values");
                _randomCountdown = OptionStuff.OptionDifficulty;

            }

            if (RandomValues.Count < OptionStuff.Simul + 1) {
                _needToBeFilled = true;
            }
        }
    }
}
