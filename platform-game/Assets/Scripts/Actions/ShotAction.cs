using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAction : RaycastAction {
    [SerializeField]
    private LevelThree gameplayScript;

    protected override void Initialize() {
        thresholdDistance = 10;
    }

    protected override void OnTargetHit() {
        gameplayScript.enemiesDefeated += 1;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            PerformRaycastAction();
        }
    }
}