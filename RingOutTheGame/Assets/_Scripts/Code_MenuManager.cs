using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Code_MenuManager : MonoBehaviour {
    #region Variables
    [Header("Menu Buttons")]
    public List<GameObject> playerSelectMenuButtons = new List<GameObject>(); // The list that contains all the buttons in the player select menu.
    public List<GameObject> mainMenuButtons = new List<GameObject>(); // The list that contains all the buttons in the main menu.
    public List<GameObject> settingsButtons = new List<GameObject>(); // The list that contains all the buttons in the settings menu.
    public List<GameObject> controlButtons = new List<GameObject>(); // The list that contains all the buttons in the controls menu.
    public List<GameObject> confirmQuitButtons = new List<GameObject>(); // The list that contains all the buttons in the confirm quit menu.
    public List<GameObject> playAgainButtons = new List<GameObject>(); // The list that contains all the buttons in the play again menu.

    [Header("Menus")]
    public GameObject playerSelectMenu; // The playerSelectMenu in the hieracy needs to be dragged in this variable through the inspector.
    public GameObject mainMenuBorder; // The mainMenuBorder in the hieracy needs to be dragged in this variable through the inspector.
    public GameObject settingsMenu; // settingsMenu in the hieracy needs to be dragged in this variable through the inspector.
    public GameObject controlsMenu; // The controlsMenu in the hieracy needs to be dragged in this variable through the inspector.
    public GameObject confirmQuit; // The confirmQuit in the hieracy needs to be dragged in this variable through the inspector.
    public GameObject playAgain; // The playAgain in the hieracy needs to be dragged in this variable through the inspector.

    public GameObject soundManager; // The soundManager in the hieracy needs to be dragged in this variable through the inspector.

    public EventSystem eventSystem; // The eventSystem in the hieracy needs to be dragged in this variable through the inspector.
    #endregion

    // Use this for initialization.
    public void Start() {
        InitializeMenu();
    }

    // Initializes the game.
    public virtual void InitializeMenu() {
        if (mainMenuBorder != null) { // Check if the mainMenuBorder variable is not null.
            foreach (Transform item in mainMenuBorder.transform) {
                if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                    mainMenuButtons.Add(item.gameObject); // Add all the buttons in the mainmenu to the mainmenu list.
                }
            }
        }
        if (settingsMenu != null) { // Check if the settingsMenu variable is not null.
            foreach (Transform item in settingsMenu.transform) {
                if (item.GetComponent<Button>() != null || item.GetComponent<Toggle>() != null) { // Check if the item has a Button & Toggle component.
                    settingsButtons.Add(item.gameObject); // Only add the buttons and toggles to the settingsButtons list.
                }
            }
        }
        if (controlsMenu != null) { // Check if the controlsMenu variable is not null.
            foreach (Transform item in controlsMenu.transform) {
                if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                    controlButtons.Add(item.gameObject); // Only add the buttons and toggles to the controlButtons list.
                }
            }
        }
        if (confirmQuit != null) { // Check if the confirmQuit variable is not null.
            foreach (Transform item in confirmQuit.transform) {
                if (item.GetComponent<Button>() != null) { // Check if the item has a Button component.
                    confirmQuitButtons.Add(item.gameObject); // Add all the buttons in the confirmquitmenu to the confirmquit list.
                }
            }
        }
        if (mainMenuBorder != null) { // Check if the mainMenuBorder variable is not null.
            if (mainMenuBorder.activeSelf != false) { // Check if the mainMenuBorder variable is active.
                PickFirstButton(mainMenuButtons, mainMenuBorder.activeSelf, 0); // Call the PickFirstButton methode.
            }
        }
    }

    /// <summary>
    /// Toggles the mainmenu border and picks the first button for selection.
    /// </summary>
    /// <param name="number">Give int for switch case</param>
    public void ToggleMenus(int number) {
        mainMenuBorder.SetActive(!mainMenuBorder.activeSelf); // Toggle the local active state of mainMenuBorder.

        switch (number) {
            case 0:
                if (mainMenuBorder.activeInHierarchy) { // If the mainMenuBorder is active in the hieracy.
                    eventSystem.SetSelectedGameObject(mainMenuButtons[0]); // Pick the first button in the mainMenuButtons.
                }
                else { // If the mainMenuBorder is not avtive in the hieracy.
                    eventSystem.SetSelectedGameObject(null); // Clear the SetSelectedGameObject.
                }
                break;
            case 1:
                settingsMenu.SetActive(!settingsMenu.activeSelf); // Toggle the local active state of settingsmen. 
                PickFirstButton(settingsButtons, !settingsMenu.activeSelf, number); // Call the PickFirstButton methode.
                break;
            case 2:
                controlsMenu.SetActive(!controlsMenu.activeSelf); // Toggle the local active state of controlsMenu. 
                PickFirstButton(controlButtons, !controlsMenu.activeSelf, number); // Call the PickFirstButton methode.
                break;
            case 3:
                confirmQuit.SetActive(!confirmQuit.activeSelf); // Toggle the local active state of confirmQuit. 
                PickFirstButton(confirmQuitButtons, !confirmQuit.activeSelf, number); // Call the PickFirstButton methode.
                break;
            case 4:
                playerSelectMenu.SetActive(!playerSelectMenu.activeSelf); // Toggle the local active state of playerSelectMenu. 
                PickFirstButton(playerSelectMenuButtons, !playerSelectMenu.activeSelf, number); // Call the PickFirstButton methode.
                break;
            case 5:
                confirmQuit.SetActive(!confirmQuit.activeSelf); // Toggle the local active state of confirmQuit. 
                PickFirstButton(confirmQuitButtons, !confirmQuit.activeSelf, number); // Call the PickFirstButton methode.
                break;
            case 6:
                mainMenuBorder.SetActive(!mainMenuBorder.activeSelf); // Toggle the local active state of mainMenuBorder.
                playAgain.SetActive(!playAgain.activeSelf); // Toggle the local active state of playAgain. 
                PickFirstButton(playAgainButtons, !playAgain.activeSelf, 6); // Call the PickFirstButton methode.
                break;
            // If non of the above methodes are called break the code.
            default:
                print("Non of the ToggleMenus swtichcase are called, something went wrong"); // Communicate to the developr that somethign went wrong.
                break;
        }
    }

    /// <summary>
    /// Load the scene with the scene index.
    /// </summary>
    /// <param name="scene">Give scene number</param>
    public virtual void LoadGameScene(int scene) {
        SceneManager.LoadScene(scene); // Load the scene with the scene index.
    }

    // Quits the application
    public void QuitGame() {
        Application.Quit(); // Quits the application.
    }

    // Pause or Unpause the game
    public virtual void Pause() {
        if (Time.timeScale == 0) { // Check if the timescale is 0.
            Time.timeScale = 1; // Unpause the game.
        }
        else {  // If timescale is not 0.
            Time.timeScale = 0; // Pause the game.
        }
    }

    /// <summary>
    /// Picks the first button in the list
    /// </summary>
    /// <param name="gameObject">Pass one of the Menus variable in here</param>
    /// <param name="boolean">If you want to select the first Menus[0] give false, else say true</param>
    /// <param name="number">Which button you want to select when returning to the other menu</param>
    public void PickFirstButton(List<GameObject> gameObject, bool boolean, int number) {
        if (boolean) { // If the boolean is true.
            eventSystem.SetSelectedGameObject(mainMenuButtons[number]); // Select the button in the Menus with the index.
        }
        else { // If the boolean is false.
            eventSystem.SetSelectedGameObject(gameObject[0]); // Select the first button in the Menus variable.
        }
    }
}
