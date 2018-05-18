using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Code_SoundSettings : MonoBehaviour {
    #region Variables
    public List<Toggle> soundToggles = new List<Toggle>(); // This list contains all the toggle component in the SettingsMenu gameobject in the hieracy.
    public List<bool> soundBools = new List<bool>(); // This list contains all the booleans in the settingsmenu gameobject in the hieracy.
    public Transform settingsMenu; // The SettingsMenu in the hieracy needs to be dragged in this variable through the inspector.
    public Scene curScene; // The activescene index.
    public static Code_SoundSettings instance; // Static variable so it is accessible from anywhere.
    #endregion

    private void Awake() {
        DontDestroyOnLoad(this.gameObject); // Don't destroy this gameobject.
        curScene = SceneManager.GetActiveScene(); // Set the curScenes value by checking the sceneindex.
        if (instance == null) { // Check if the instance variable is null.
            instance = this; // Set the instance variable to this script Code_SoundSettings.
            DontDestroyOnLoad(gameObject); // Don't destroy this gameobject. TODO: Check if this really needs to happen for the second time.
        }
        else if (instance != this) { // If the instance variable is not the same as itself.
            GetValuesFromInstance(); // Call the GetValuesFromInstance Methode.
            Destroy(instance.gameObject);// Destroy the instance once all values were transfered.
            instance = this; // Set this gameobject as the new instance value.
        }
    }

    // Loads the next scene.
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded; // Load the next scene.
    }

    // Load the previuos scene.
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Load the previous scene.
    }

    /// <summary>
    /// Set the values when the new scene is loaded.
    /// </summary>
    /// <param name="scene">scene index</param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (curScene == scene) { // Check if curScene is equal to the scene.
            FillSettingMenu(); // Call the FillSettingMenu Methode.
            SetValues(); // Call the SetValues Methode.
            GetValues(); // Call the GetValues Methode.
        }
        else { // If the curScene is not equal to the scene.
            print("curScene is not equal to scene"); // Print this message to the console, so other developers know what the error is.
        }
    }

    // Sets the values of the souboundbools list.
    public void SetValues() {
        for (int i = 0; i < soundToggles.Count; i++) {
            soundBools[i] = soundToggles[i].isOn; // Sets the soundBools to the soundToggles boolean value.
        }
    }

    // Get the isOn values of the sound toggle buttons.
    public void GetValuesFromInstance() {
        soundBools = instance.soundBools; // Set all the boolean values in soundBools to instance.Soundcools.
        GetValues(); // Call the GetValues Methode.
    }

    // Set the soundToggles list to the soundbools list.
    public void GetValues() {
        int i = 0; // Local int variable.
        if (settingsMenu != null) { // Check if the SettingsMenu variable is not null.
            foreach (Transform item in settingsMenu.transform) {
                if (item.GetComponent<Toggle>() != null) { // Check if it has a Toggle component.
                    item.GetComponent<Toggle>().isOn = soundBools[i]; // Get the isOn boolean value and set it in the soundBools list with the current i.
                    i++; // Add 1 to i.
                }
            }
        }
        else { // If settingsMenu variable is null.
            print("Fill the (settingsMenu) in the Variable region"); // Print this message to the console, so other developers know what the error is.
        }
    }

    // Fill the soundToggles list with the toggles of the settingsmenu.
    public void FillSettingMenu() {
        if (settingsMenu != null) { // Check if the SettingsMenu variable is not null.
            foreach (Transform item in settingsMenu.transform) {
                if (item.GetComponent<Toggle>() != null) { // Check if it has a Toggle component.
                    soundToggles.Add(item.GetComponent<Toggle>()); // Make the list larger by adding the item.
                }
            }
            soundBools = new List<bool>(new bool[soundToggles.Count]); // Assign the soundbools list.
        }
        else { // If settingsMenu variable is null. 
            print("Fill the (settingsMenu) in the Variable region"); // Print this message to the console, so other developers know what the error is.
        }
    }
}
