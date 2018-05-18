using UnityEngine;

public class Code_RotateSkyBox : MonoBehaviour {
    #region Variables
    public float rotateSpeed; // Modify the rotation with this value.
    #endregion

    // Update is called once per frame.
    void Update() {
        RotateSkyBox(); // Call the RotateSkyBox Methode.
    }

    // Rotate the Skybox in scene.
    private void RotateSkyBox() {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed); // Rotates the skybox in the scene, you can attach this to any object in the hieracy.
        if (rotateSpeed != 0) { // Check if the rotationspeed is 0.
            print("The speed is 0, the skybox is not rotating"); // Print this message to the console, so other developers know that this methode is currently doing nothing.
        }
    }
}
