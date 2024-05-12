using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Slider soundVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            StopGame();
        }
    }
    
    public void SetSoundVolume() {
        PlayerPrefs.SetFloat("SoundVolume", soundVolumeSlider.value);
    }
    
    public void SetMusicVolume() {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void StopGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    
    public void ResumeGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
