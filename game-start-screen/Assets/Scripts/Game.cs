using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    [SerializeField]
    ScreenSettings screenSettings;
    [SerializeField]
    SoundSettings soundSettings;
    [SerializeField]
    Button quitGameButton;

    void Start() {
        screenSettings.LoadScreenSettings();
        soundSettings.LoadSoundSettings();

        quitGameButton.onClick.AddListener(QuitGame);
    }

    void QuitGame() {
        Application.Quit();
        PlayerPrefs.Save();
    }
}
