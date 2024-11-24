using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectChestAction : RaycastAction {
    [SerializeField]
    Gameplay gameplayScript;
    [SerializeField]
    LevelFour levelFourScript;
    [SerializeField]
    int chestIndex = 0;
    bool isCollectible = true;
    bool isActive = true;
    GameObject highlightObject;

    protected override void Initialize() {
        thresholdDistance = 4;

        if (levelFourScript) {
            if (levelFourScript && chestIndex != levelFourScript.winningChestIndex) {
                isCollectible = false;
            }

            Transform highlightTransform = transform.Find("Cylinder");

            if (highlightTransform) {
                highlightObject = highlightTransform.gameObject;
                highlightObject.SetActive(false);
            }
        } else {
            isActive = true;
        }
    }

    protected override void OnTargetHit() {
        gameplayScript.isChestCollected = true;
    }

    void Update() {
        if (!gameplayScript.isChestCollected 
            && isActive 
            && isCollectible 
            && Input.GetKeyDown(KeyCode.R)) {
            PerformRaycastAction();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (!levelFourScript) return;

        if (collision.gameObject.CompareTag("Player") && isCollectible) {
            isActive = true;

            if (highlightObject) {
                highlightObject.SetActive(true);
            }
        }    
    }
}
