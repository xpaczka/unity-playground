using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour {
    float gameVolume;
    bool musicEnabled;
    bool soundEffectsEnabled;
    [SerializeField]
    Slider gameVolumeSlider;
    [SerializeField]
    Button soundButtonOn;
    [SerializeField]
    Button soundButtonOff;
    [SerializeField]
    Button soundEffectsButtonOn;
    [SerializeField]
    Button soundEffectsButtonOff;
    [SerializeField]
    Button saveSettingsButton;
    [SerializeField]
    GameObject settingPanel;

    void Start() {
        LoadSoundSettings();

        gameVolumeSlider.onValueChanged.AddListener(delegate { SetGameVolume(); });

        soundButtonOn.onClick.AddListener(() => SetMusicEnabled(true));
        soundButtonOff.onClick.AddListener(() => SetMusicEnabled(false));

        soundEffectsButtonOn.onClick.AddListener(() => SetEffectEnabled(true));
        soundEffectsButtonOff.onClick.AddListener(() => SetEffectEnabled(false));

        saveSettingsButton.onClick.AddListener(SaveSoundSettings);
    }

    void SetGameVolume() {
        gameVolume = gameVolumeSlider.value;
    }

    void SetMusicEnabled(bool enabled) {
        musicEnabled = enabled;
        UpdateMusicEnabledButtons();
    }

    void SetEffectEnabled(bool enabled) {
        soundEffectsEnabled = enabled;
        UpdateSoundEffectsEnabledButtons();
    }

    void UpdateMusicEnabledButtons() {
        soundButtonOn.interactable = !musicEnabled;
        soundButtonOff.interactable = musicEnabled;
    }

    void UpdateSoundEffectsEnabledButtons() {
        soundEffectsButtonOn.interactable = !soundEffectsEnabled;
        soundEffectsButtonOff.interactable = soundEffectsEnabled;
    }

    void SaveSoundSettings() {
        PlayerPrefs.SetFloat("GameVolume", gameVolume);
        PlayerPrefs.SetInt("MusicEnabled", Convert.ToInt16(musicEnabled));
        PlayerPrefs.SetInt("SoundEffectsEnabled", Convert.ToInt16(soundEffectsEnabled));

        PlayerPrefs.Save();
        settingPanel.SetActive(false);
    }

    public void LoadSoundSettings() {
        gameVolume = PlayerPrefs.GetFloat("GameVolume", 100f);
        gameVolumeSlider.value = gameVolume;

        musicEnabled = Convert.ToBoolean(PlayerPrefs.GetInt("MusicEnabled", 1));
        UpdateMusicEnabledButtons();

        soundEffectsEnabled = Convert.ToBoolean(PlayerPrefs.GetInt("SoundEffectsEnabled", 1));
        UpdateSoundEffectsEnabledButtons();
    }
}
