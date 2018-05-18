using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Code_SplashScreen : MonoBehaviour {
    #region Variables
    [SerializeField] private Image logo; // The logo in the hieracy needs to be dragged in this variable through the inspector.
    #endregion

    // Use this for initialization.
    void Start() {
        StartCoroutine(SplashScreenAnimation()); // Call the SplashScreenAnimation methode.
    }

    // Plays the SplashScreen animation.
    IEnumerator SplashScreenAnimation() {
        if (logo != null) { // Check if the logo variable is not null.
            Animation animation = logo.GetComponent<Animation>(); // Store the Animation component in a temporarily variable for better performance (called 2x).
            animation.Play(); // Play the Logo animation.        
            yield return new WaitForSeconds(animation.clip.length); // Wait for the Logo animation clips length.  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Go to the next scene.
        }
        else { // If logo variable is null.
            print("Fill the (logo) in the Variable region"); // Print this message to the console, so other developers know what the error is.
        }
    }
}
