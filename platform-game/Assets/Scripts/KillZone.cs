using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            Application.Quit();
            Destroy(collider.gameObject);
        }
    }
}
