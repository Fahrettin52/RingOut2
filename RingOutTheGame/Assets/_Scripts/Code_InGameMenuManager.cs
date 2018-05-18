using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Code_InGameMenuManager : Code_MenuManager {
    #region Variables
    public Code_GameManager gameMng; // The gameMng in the hieracy needs to be dragged in this variable through the inspector.
    public Code_SoundManager soundMng; // The SoundManager in the hieracy needs to be dragged in this variable through the inspector.

    public bool allowStart; // Boolean to check if you may pause the game.
    #endregion

    // Update is called once per frame.
    void Update() {
        if (Input.GetButtonDown("StartButton") && !playerSelectMenu.activeSelf && allowStart) { // Check if you pressed the start input & if the playerselect menu is not active & allowstart is true.
            if (!CheckMenuElements()) { // Check if the methode is false.
                Pause(); // Call the Pause methode.
                ToggleMenus(0); // Call the ToggleMenus methode.
            }
        }
    }
    
    // Checks if any menu is open except for the mainmenu.
    public bool CheckMenuElements() {
        return settingsMenu.activeInHierarchy || controlsMenu.activeInHierarchy || confirmQuit.activeInHierarchy; // Return true if one of the menus are open, else return false.
    }
    
    // Initializes the game.
    public override void InitializeMenu() {
        foreach (Transform item in playerSelectMenu.transform) {
            if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                playerSelectMenuButtons.Add(item.gameObject); // Add all the buttons in the playerSelectMenu to the playerSelectMenuButtons.
            }
        }
        foreach (Transform item in mainMenuBorder.transform) {
            if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                mainMenuButtons.Add(item.gameObject); // Add all the buttons in the mainMenuBorder to the mainMenuButtons list.
            }
        }
        foreach (Transform item in settingsMenu.transform) { 
            if (item.GetComponent<Button>() != null || item.GetComponent<Toggle>() != null) { // Check if the item has a Button component & // Check if the item has a Toggle component.
                settingsButtons.Add(item.gameObject); // Add all the buttons in the settingsMenu to the settingsButtons list.
            }
        }
        foreach (Transform item in controlsMenu.transform) {
            if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                controlButtons.Add(item.gameObject); // Add all the buttons in the controlsMenu to the controlButtons list.
            }
        }
        foreach (Transform item in confirmQuit.transform) {
            if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                confirmQuitButtons.Add(item.gameObject); // Add all the buttons in the confirmQuit to the confirmQuitButtons list.
            }
        }
        foreach (Transform item in playAgain.transform) {
            if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                playAgainButtons.Add(item.gameObject); // Add all the buttons in the playAgain to the playAgainButtons list.
            }
        }
        PickFirstButton(playerSelectMenuButtons, !playerSelectMenu.activeSelf, 0); // Call the PickFirstButton methode.
    }

    /// <summary>
    /// Load the scene with the scene index.
    /// </summary>
    /// <param name="scene">Give scene number</param>
    public override void LoadGameScene(int scene) {
        SceneManager.LoadScene(scene); // Load the scene with the scene index.
        Pause(); // Call the Pause methode.
    }
    
    // Pause or Unpause the game.
    public override void Pause() {
        if (Time.timeScale == 0) { // Check if the timescale is 0.
            if (soundMng.volumeChecks[0].isOn && soundMng.volumeChecks[1].isOn) { // Check if volumeChecks[0].isOn & soundMng.volumeChecks[1].isOn.
                soundMng.musicAudioSource[0].mute = true; // Mute the musicAudioSource[0].
                soundMng.musicAudioSource[1].mute = false; // UnMute musicAudioSource[1].
                soundMng.PlayGameMusic(); // Call the PlayGameMusic.
            }
        }
        else { // If timescale is not 0.
            Time.timeScale = 0;  // Pause the game.
            allowStart = false; // Set allowStart boolean to false.

            // Play the mainmenu music
            if (soundMng.volumeChecks[0].isOn && soundMng.volumeChecks[1].isOn) { // Check if volumeChecks[0].isOn & soundMng.volumeChecks[1].isOn.
                soundMng.musicAudioSource[0].mute = false; // UnMute the musicAudioSource[0].
                soundMng.musicAudioSource[1].mute = true; // Mute the musicAudioSource[0].
                soundMng.PlayMainMenuMusic(); // Call the PlayGameMusic.
            }
        }
    }
}
