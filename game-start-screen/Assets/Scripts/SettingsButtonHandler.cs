using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonHandler : MonoBehaviour {
    [SerializeField] 
    Button button;
    [SerializeField]
    GameObject settingsScreen;

    void Start() {
        button.onClick.AddListener(TaskOnClick);
        settingsScreen.SetActive(false);
    }

    void TaskOnClick() {
        GameObject[] settingScreens = GameObject.FindGameObjectsWithTag("settings-panel");

        // Hide all other setting screens
        foreach (GameObject settingScreen in settingScreens) {
            settingScreen.SetActive(false);
        }

        settingsScreen.SetActive(true);
    }
}
