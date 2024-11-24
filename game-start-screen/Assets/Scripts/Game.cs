using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public bool isHUDActive;
    [SerializeField]
    ScreenSettings screenSettings;
    [SerializeField]
    SoundSettings soundSettings;
    [SerializeField]
    Button quitGameButton;
    [SerializeField]
    Button startGameButton;
    [SerializeField]
    Button continueGameButton;
    [SerializeField]
    GameObject startGameScreen;
    [SerializeField]
    GameObject HUDScreen;

    void Start() {
        screenSettings.LoadScreenSettings();
        soundSettings.LoadSoundSettings();

        HUDScreen.SetActive(false);
        isHUDActive = false;

        quitGameButton.onClick.AddListener(QuitGame);
        startGameButton.onClick.AddListener(StartGame);
        continueGameButton.onClick.AddListener(StartGame);
    }

    void QuitGame() {
        Application.Quit();
        PlayerPrefs.Save();
    }

    void StartGame() {
        startGameScreen.SetActive(false);
        HUDScreen.SetActive(true);
        isHUDActive = true;
        continueGameButton.interactable = true;
    }

    public void OpenStartScreen() {
        startGameScreen.SetActive(true);
        HUDScreen.SetActive(false);
    }
}
