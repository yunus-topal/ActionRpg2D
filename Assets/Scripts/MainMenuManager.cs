using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuPanel;
    
    [SerializeField] private Slider soundVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    
    
    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void SetSoundVolume() {
        PlayerPrefs.SetFloat("SoundVolume", soundVolumeSlider.value);
    }
    
    public void SetMusicVolume() {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }
    
    public void OpenSettings() {
        settingsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void OpenMainMenu() {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}