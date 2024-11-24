using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {
    [SerializeField]
    protected GameObject chest;
    protected GameObject player;
    protected Vector3 startPosition;
    public bool isTeleporterActive = false;
    public bool isChestCollected = false;
    public int currentLevel = 1;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = player.transform.position;
    }

    public void ResetLevel() {
        isTeleporterActive = false;
        isChestCollected = false;
        player.transform.position = startPosition;

        if (chest != null) {
            chest.SetActive(true);
        }
    }
}
