using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_PickUp_IncreaseDamage : Code_PickUp {

    public float multiplierIncremental; // With how much it has to increase the value of damageMultiplier

    // Checks if the player already possess the same pickup
    public override bool CheckPlayerForPickUp(Code_Player player) {
        return false; // This must always be false since it does not have to check for anything, the player itself will do this later on
    }

    // Overidable function for it's children
    public override void ActivatePickUpEffect(Code_Player player) {
        player.IncreaseDamageMultiplier(multiplierIncremental);
    }
}
