using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {
    bool isInventoryActive;
    [SerializeField]
    Game gameScript;
    [SerializeField]
    GameObject inventory;

    void Start() {
        inventory.SetActive(false);
        isInventoryActive = false;
        gameScript.isHUDActive = true;
    }

    void ToggleInventory(bool isOpen) {
        isInventoryActive = isOpen;
        inventory.SetActive(isInventoryActive);
    }

    void Update() {
        if (gameScript.isHUDActive && Input.GetKeyDown(KeyCode.E)) {
            ToggleInventory(!isInventoryActive);
        }

        if (gameScript.isHUDActive && Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
            gameScript.isHUDActive = false;
        }

        if (gameScript.isHUDActive && Input.GetKeyDown(KeyCode.M)) {
            ToggleInventory(false);
            gameScript.OpenStartScreen();
            gameScript.isHUDActive = false;
        }
    }
}
