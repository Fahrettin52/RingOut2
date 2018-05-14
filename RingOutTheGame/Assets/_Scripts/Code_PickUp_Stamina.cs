using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_PickUp_Stamina : Code_PickUp {
    public float staminaAmount; // Amount with which the stamina will be increased by once picked up

    // Checks if the player already possess the same pickup
    public override bool CheckPlayerForPickUp(Code_Player player) {        
        return false; // must always be false because the player itself checks the effect
    }

    // Overidable function for it's children
    public override void ActivatePickUpEffect(Code_Player player) {
        player.IncreaseStamina(staminaAmount); // For when a dev made a child but did not override this function
    }
}
