using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts {
    
    public class Debugger : MonoBehaviour {

        // Use this for initialization
        void Start () {
        }
	
        // Update is called once per frame
        void Update () {
            if (B.ReqDebug) {
                switch (Scripts.Instantiate.RandomValues.Count) {
                    case 7: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0]
                            + Environment.NewLine + "1: " + Scripts.Instantiate.RandomValues[1]
                            + Environment.NewLine + "2: " + Scripts.Instantiate.RandomValues[2]
                            + Environment.NewLine + "3: " + Scripts.Instantiate.RandomValues[3]
                            + Environment.NewLine + "4: " + Scripts.Instantiate.RandomValues[4]
                            + Environment.NewLine + "5: " + Scripts.Instantiate.RandomValues[5]
                            + Environment.NewLine + "6: " + Scripts.Instantiate.RandomValues[6];
                        break;
                    }
                    case 6: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0]
                            + Environment.NewLine + "1: " + Scripts.Instantiate.RandomValues[1]
                            + Environment.NewLine + "2: " + Scripts.Instantiate.RandomValues[2]
                            + Environment.NewLine + "3: " + Scripts.Instantiate.RandomValues[3]
                            + Environment.NewLine + "4: " + Scripts.Instantiate.RandomValues[4]
                            + Environment.NewLine + "5: " + Scripts.Instantiate.RandomValues[5];
                        break;
                    }
                    case 5: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0]
                            + Environment.NewLine + "1: " + Scripts.Instantiate.RandomValues[1]
                            + Environment.NewLine + "2: " + Scripts.Instantiate.RandomValues[2]
                            + Environment.NewLine + "3: " + Scripts.Instantiate.RandomValues[3]
                            + Environment.NewLine + "4: " + Scripts.Instantiate.RandomValues[4];
                        break;
                    }
                    case 4: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0]
                            + Environment.NewLine + "1: " + Scripts.Instantiate.RandomValues[1]
                            + Environment.NewLine + "2: " + Scripts.Instantiate.RandomValues[2]
                            + Environment.NewLine + "3: " + Scripts.Instantiate.RandomValues[3];
                        break;
                    }
                    case 3: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0]
                            + Environment.NewLine + "1: " + Scripts.Instantiate.RandomValues[1]
                            + Environment.NewLine + "2: " + Scripts.Instantiate.RandomValues[2];
                        break;
                    }
                    case 2: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0]
                            + Environment.NewLine + "1: " + Scripts.Instantiate.RandomValues[1];
                        break;
                    }
                    case 1: {
                        GetComponent<TextMeshProUGUI>().text =
                            "There are currently " + Scripts.Instantiate.RandomValues.Count + " values in the list"
                            + Environment.NewLine + "0: " + Scripts.Instantiate.RandomValues[0];
                        break;
                    }
                }
            }
        }

        public void A(bool toggle) {
            B.ReqDebug = toggle;
        }

        public class B {
            public static bool ReqDebug;
        }
    }
}

