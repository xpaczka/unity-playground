using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    Gameplay gameplayScript;
    readonly private float ballSpeed = 0.05f;
    private Vector3 direction;

    void Start() {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        direction = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
    }

    void Update() {
        if (gameplayScript.currentLevel > 1) return;

        transform.position += direction * ballSpeed;
    }

    void OnWallCollision(Collision collision) {
        if (gameplayScript.currentLevel > 1) return;

        ContactPoint contact = collision.contacts[0];
        Vector3 normal = contact.normal;
        direction = Vector3.Reflect(direction, normal);
    }

    void OnCollisionEnter(Collision collision) {
        if (gameplayScript.currentLevel > 1) return;

        if (collision.gameObject.CompareTag("level-1-wall")) {
            OnWallCollision(collision);
        }

        if (collision.gameObject.CompareTag("Player")) {
            gameplayScript.ResetLevel();
        }
    }
}
