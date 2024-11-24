using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaycastAction : MonoBehaviour {
    protected GameObject player;
    protected int thresholdDistance = 1;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        Initialize();
    }

    protected abstract void OnTargetHit();

    protected virtual void Initialize() {}

    protected void PerformRaycastAction() {
        if (Physics.Raycast(player.transform.position, player.transform.forward, out RaycastHit hit, thresholdDistance)) {
            GameObject target = hit.collider.gameObject;
            Transform currentTarget = target.transform;
            bool isTargetOrChild = false;

            while (currentTarget != null) {
                if (currentTarget.gameObject == gameObject) {
                    isTargetOrChild = true;
                    break;
                }
                currentTarget = currentTarget.parent;
            }

            if (isTargetOrChild) {
                OnTargetHit();
                gameObject.SetActive(false);
            }
        }
    }
}
