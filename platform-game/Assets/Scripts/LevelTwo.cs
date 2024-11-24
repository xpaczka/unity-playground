using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwo : Gameplay {
    readonly private int gatesCount = 4;
    public int activeGate = 1;

    void Start() {
        chest.SetActive(false);
    }

    void Update() {
        if (activeGate > gatesCount && !isChestCollected) {
            chest.SetActive(true);
        }
    }
}
