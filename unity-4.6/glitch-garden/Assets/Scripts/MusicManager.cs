using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	void OnLevelWasLoaded(int level) {
		AudioClip levelMusic = levelMusicChangeArray[level];
		if (levelMusic) {
			audioSource.clip = levelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void SetVolume(float volume) {
		audioSource.volume = volume;
	}
}
