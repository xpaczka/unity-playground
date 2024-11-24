using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThree : Gameplay {
    readonly private int enemiesCount = 3;
    public int enemiesDefeated = 0;

    void Start() {
        chest.SetActive(false);
    }

    void Update() {
        if (enemiesDefeated == enemiesCount && !isChestCollected) {
            chest.SetActive(true);
        }
    }
}
