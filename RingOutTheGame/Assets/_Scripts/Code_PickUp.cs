using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_PickUp : MonoBehaviour {
    [HideInInspector]
    public Code_PickUpManager pickUpMng; // The Code_PickUpManager in the scene
    [HideInInspector]
    public bool isUnpooled; // Keeps track whether the pickup is pooled or not
    public float timer; // How long the box stays
    private Coroutine repool;

    // Unpools the pickup object into the level
    public void Unpool(Vector3 dropPos) {
        isUnpooled = true;
        transform.position = dropPos;
        gameObject.SetActive(true);
        repool = StartCoroutine(RepoolCountdown());
    }

    // Repool itself after a specific time
    private IEnumerator RepoolCountdown() {
        yield return new WaitForSeconds(timer);
        PoolPickUp();
    }

    // When it's hit by a player
    public void PickedUp(Code_Player player) {
        if (!CheckPlayerForPickUp(player)) {
            ActivatePickUpEffect(player);            
        }
        PoolPickUp();
    }

    // Pools the pickup and stores it once more
    public void PoolPickUp() {
        if (repool != null) {
            StopCoroutine(repool);
        }
        isUnpooled = false;
        pickUpMng.ChangePooledCount(1);
        gameObject.SetActive(false);
    }

    // Checks if the player already possess the same pickup
    public virtual bool CheckPlayerForPickUp(Code_Player player) {
        print("Tell what to do when the player has the same pickup activated already"); // For when a dev made a child but did not override this function
        // Return a bool based on the results of the check above
        return false; // False means that the player does not possess the same pickup effect
    }

    // Overidable function for it's children
    public virtual void ActivatePickUpEffect(Code_Player player) {
        print("Activated by player"); // For when a dev made a child but did not override this function
    }

    public void OnTriggerEnter(Collider col) {
        if (col.transform.tag == "Player") {
            PickedUp(col.GetComponent<Code_Player>());
        }
    }
}
