using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAction : MonoBehaviour {
    [SerializeField]
    GameObject activeIndicator;
    [SerializeField]
    LevelTwo levelTwoGameplayScript;
    [SerializeField]
    int gateNumber;

    void Update() {
        activeIndicator.GetComponent<Renderer>().material.color = 
            levelTwoGameplayScript.activeGate == gateNumber ? Color.green :Color.red;
    }

    void OnTriggerExit() {
        levelTwoGameplayScript.activeGate = gateNumber + 1;
    }
}
