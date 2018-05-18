using UnityEngine;

public class Code_CharacterCanvas : MonoBehaviour {
    #region Variables
    public GameObject sceneCamera; // The main camera in the hieracy needs to be dragged in this variable through the inspector.
    #endregion

    // Update is called once per frame.
    void Update() {
        LookAtCamera(); // Call the LookAtCamera methode.
    }

    // Makes the characters canvas look at the camera.
    private void LookAtCamera() {
        if (sceneCamera != null) { // Check if the sceneCamera variable is not null.
            transform.LookAt(sceneCamera.transform); // Rotate the transform of this object towards the camera transform.
        }
        else { // If sceneCamera variable is null.
            print("Fill the (sceneCamera) in the Variable region"); // Print this message to the console, so other developers know what the error is.
        }
    }
}
