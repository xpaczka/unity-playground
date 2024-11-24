using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAction : MonoBehaviour {
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject teleporationTarget;
    [SerializeField]
    Gameplay gameplayScript;

    Color GetTeleporterColor() {
        return gameplayScript.isTeleporterActive ? new Color(0, 255, 0) : new Color();
    }

    void Update() {
        gameObject.GetComponent<Renderer>().material.color = GetTeleporterColor();

        if (gameplayScript.isChestCollected) {
            gameplayScript.isTeleporterActive = true;
        }

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player.transform.position = teleporationTarget.transform.position;
            gameplayScript.isChestCollected = false;
            gameplayScript.isTeleporterActive = false;
            gameplayScript.currentLevel += 1;
        }
    }
}
