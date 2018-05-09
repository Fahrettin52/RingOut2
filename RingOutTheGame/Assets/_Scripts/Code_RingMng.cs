using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_RingMng : MonoBehaviour {
    public bool mayRotate; // Determines whether the ring rotates or not
    public float speed;

    private void Update() {
        if (mayRotate) {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }

    // Destroys the ring when called from the animation after performing some last actions
    public void DestroyRing() {
        GetComponentInParent<Code_Arena>().UpdateCameraBonuses();
        GetComponentInParent<Code_Arena>().StartTimeBetweenActivations();
        Destroy(gameObject);
    }
}
