using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_PickUp_Teleport : Code_PickUp {

    // Checks if the player already possesses has a Teleport
    public override bool CheckPlayerForPickUp(Code_Player player) {
        bool canRTP = !player.didTP;
        return canRTP; // didTP must be false for true for this function to work, so it'll have to be inversed
    }

    // Gives the player a new Teleport
    public override void ActivatePickUpEffect(Code_Player player) {
        player.ResetTelePort();
    }
}
