using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour {
    bool isFullScreen;
    string resolution;
    [SerializeField]
    GameObject screenSettingPanel;
    [SerializeField]
    Button saveScreenSettingsButton;
    [SerializeField]
    Button smallResolutionButton;
    [SerializeField]
    Button middleResolutionButton;
    [SerializeField]
    Button largeResolutionButton;
    [SerializeField]
    Button fullScreenButtonOn;
    [SerializeField]
    Button fullScreenButtonOff;

    void Start() {
        LoadScreenSettings();

        saveScreenSettingsButton.onClick.AddListener(SaveScreenSettings);

        smallResolutionButton.onClick.AddListener(() => SetGameResolution("small", isFullScreen));
        middleResolutionButton.onClick.AddListener(() => SetGameResolution("middle", isFullScreen));
        largeResolutionButton.onClick.AddListener(() => SetGameResolution("large", isFullScreen));

        fullScreenButtonOn.onClick.AddListener(() => SetFullScreen(true));
        fullScreenButtonOff.onClick.AddListener(() => SetFullScreen(false));
    }

    void SetGameResolution(string gameResolution, bool isGameFullScreen) {
        resolution = gameResolution;

        switch (resolution) {
            case "small":
                Screen.SetResolution(640, 480, isGameFullScreen);
                break;
            case "middle":
                Screen.SetResolution(1280, 720, isGameFullScreen);
                break;
            case "large":
                Screen.SetResolution(1920, 1080, isGameFullScreen);
                break;
        }

        UpdateResolutionButtons();
    }

    void SetFullScreen(bool isGameFullScreen) {
        isFullScreen = isGameFullScreen;
        
        SetGameResolution(resolution, isGameFullScreen);
        UpdateFullScreenButtons();
    }

    void UpdateResolutionButtons() {
        smallResolutionButton.interactable = resolution != "small";
        middleResolutionButton.interactable = resolution != "middle";
        largeResolutionButton.interactable = resolution != "large";
    }

    void UpdateFullScreenButtons() {
        fullScreenButtonOn.interactable = !isFullScreen;
        fullScreenButtonOff.interactable = isFullScreen;
    }

    void SaveScreenSettings() {
        PlayerPrefs.SetString("Resolution", resolution);
        PlayerPrefs.SetInt("FullScreen", Convert.ToInt16(isFullScreen));

        PlayerPrefs.Save();
        screenSettingPanel.SetActive(false);
    }

    public void LoadScreenSettings() {
        resolution = PlayerPrefs.GetString("Resolution", "large");
        UpdateFullScreenButtons();

        isFullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreen", 1));
        UpdateResolutionButtons();

        SetGameResolution(resolution, isFullScreen);
    }
}
