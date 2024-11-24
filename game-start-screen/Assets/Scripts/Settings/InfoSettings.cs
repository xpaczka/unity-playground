using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoSettings : MonoBehaviour {
    [SerializeField]
    Button infoButton;
    [SerializeField]
    GameObject infoPanel;

    void Start() {
        infoButton.onClick.AddListener(CloseInfo);
    }

    void CloseInfo() {
        infoPanel.SetActive(false);
    }
}
