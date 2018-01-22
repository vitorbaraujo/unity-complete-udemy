﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public LevelManager levelManager;

	private MusicManager musicManager;
	
	void Start () {
		Debug.Log(PlayerPrefsManager.GetDifficulty());
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		Debug.Log (musicManager);

		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}

	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}

	public void SaveAndExit() {
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}

	public void SetDefaults() {
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;

	}
}
