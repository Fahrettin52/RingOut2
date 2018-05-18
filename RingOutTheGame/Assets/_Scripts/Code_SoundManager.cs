using UnityEngine;
using UnityEngine.UI;

public class Code_SoundManager : MonoBehaviour {
    #region Variables
    [Header("AudioSources Buttons")]
    public AudioSource[] musicAudioSource; // Audiosource that controls the music sounds.
    public AudioSource[] sFXAudioSource; // Audiosource that controls the sfx sounds.
    public AudioSource[] characterAudioSource; // Audiosource that controls the character sounds.

    [Header("AudioClips")]
    public AudioClip[] musicAudioClip; // The music sounds.
    public AudioClip[] sFXAudioClip; // The SFX sounds.
    public AudioClip[] characterAudioClip; // The character sounds.

    public Toggle[] volumeChecks; // An array that contains all the music toggles in the settings menu.
    #endregion

    // Use this for initialization.
    void Start() {
        for (int i = 0; i < musicAudioSource.Length; i++) { // Forloop, checking the musicAudioSource count as lenght.
            musicAudioSource[i].clip = musicAudioClip[i]; // Store each music audioclip in the music audiosource.
        }
        for (int i = 0; i < sFXAudioSource.Length; i++) { // Forloop, checking the sFXAudioSource count as lenght.
            sFXAudioSource[i].clip = sFXAudioClip[i]; // Store each sfx audioclip in the sfx audiosource.
        }
        for (int i = 0; i < characterAudioSource.Length; i++) { // Forloop, checking the characterAudioSource count as lenght.
            characterAudioSource[i].clip = characterAudioClip[i]; // Store each character audioclip in the character audiosource.
        }
        PlayMainMenuMusic(); // Call the PlayMainMenuMusic methode.
        PlayRainMusic(); // Call the PlayRainMusic methode.
    }

    // Play the mainmenu music.
    public void PlayMainMenuMusic() {
        musicAudioSource[0].Play(); // Play the first audio in musicAudioSource.
    }

    // Play the in game ambient music.
    public void PlayGameMusic() {
        if (volumeChecks[1].isOn) { // Check if the MusicSoundButton toggle is on.
            musicAudioSource[1].Play(); // Play the second audio in musicAudioSource.
        }
        else { // If the MusicSoundButton toggle is not on.
            print("MusicSoundButton toggle is not on, this should be on"); // Print this message to the console, so other developers know what the error is.
        }
    }

    // Play the in rain music.
    public void PlayRainMusic() {
        if (volumeChecks[2].isOn) { // Check if the SFXSoundButton toggle is on.
            musicAudioSource[2].Play(); // Play the third audio in musicAudioSource.
        }
        else { // If the SFXSoundButton toggle is not on.
            print("SFXSoundButton toggle is not on, this should be on"); // Print this message to the console, so other developers know what the error is.
        }
    }

    // Play the hover over button sound.
    public void PlayButtonHover() {
        sFXAudioSource[0].Play(); // Play the first audio in sFXAudioSource.
    }

    // Play the confirmation sound.
    public void PlayUIConfirmation() {
        sFXAudioSource[1].Play(); // Play the second audio in sFXAudioSource.
    }

    // Play the checkmark sound.
    public void PlayToggleSetting() {
        sFXAudioSource[2].Play(); // Play the third audio in sFXAudioSource.
    }

    /// <summary>
    /// Mute or unmute the the chosen audiosource.
    /// </summary>
    /// <param name="index">Give int value for the switcase</param>
    public void ToggleSelectedSound(int index) {
        if (volumeChecks[0].isOn) { // Check if the mastervolumes boolean is true.
            switch (index) { // Give int value for the switchcase.
                case 0:
                    foreach (AudioSource item in musicAudioSource) { // For each AudioSource in musicAudioSource.
                        if (item != musicAudioSource[1]) { // If item is not the same as musicAudioSource 1.
                            item.mute = !volumeChecks[1].isOn; // Item.Mute is not the value of volumeChecks 1.
                        }
                    }
                    break;
                case 1:
                    foreach (AudioSource item in sFXAudioSource) { // For each AudioSource in sFXAudioSource.
                        item.mute = !volumeChecks[2].isOn; // Item.Mute is not the value of volumeChecks 2.
                    }
                    break;
                case 2:
                    foreach (AudioSource item in characterAudioSource) { // For each AudioSource in characterAudioSource.
                        item.mute = !volumeChecks[3].isOn; // Item.Mute is not the value of volumeChecks 3.
                    }
                    break;
                // If non of the above methodes are called break the code.
                default:
                    print("Non of the ToggleSelectedSound swtichcase are called, something went wrong"); // Communicate to the developr that somethign went wrong.
                    break;
            }
        }
    }

    // Turn off all the sounds in game
    public void TurnOffAllSounds() {
        if (!volumeChecks[0].isOn) { // Check if the mastervolumes boolean is true.
            for (int i = 0; i < musicAudioSource.Length; i++) {
                musicAudioSource[i].mute = true; // Mute all the music sounds.
            }
            for (int i = 0; i < sFXAudioSource.Length; i++) {
                sFXAudioSource[i].mute = true; // Mute all the sfx sounds.
            }
            for (int i = 0; i < characterAudioSource.Length; i++) {
                characterAudioSource[i].mute = true; // Mute all the character sounds.
            }
        }
        else { // If the mastervolumes boolean is not true.
            for (int i = 0; i < musicAudioSource.Length; i++) {
                if (musicAudioSource[i] != musicAudioSource[1]) { // If the musicAudioSource[i] is not the same as musicAudioSource 1.
                    musicAudioSource[i].mute = !volumeChecks[1].isOn; // Mute or unmute the music audiosource depending on the current state of the corresponding volumecheck item.
                }
            }
            for (int i = 0; i < sFXAudioSource.Length; i++) {
                sFXAudioSource[i].mute = !volumeChecks[2].isOn; // Mute or unmute the sfx audiosource depending on the current state of the corresponding volumecheck item.
            }
            for (int i = 0; i < characterAudioSource.Length; i++) {
                characterAudioSource[i].mute = !volumeChecks[3].isOn; // Mute or unmute the character audiosource depending on the current state of the corresponding volumecheck item.
            }
        }
    }
}
