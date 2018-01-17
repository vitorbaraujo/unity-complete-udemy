using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start() {
		Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
	}

	public void LoadLevel(string game) {
		Debug.Log ("Level requested for " + game);
		Application.LoadLevel (game);
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void QuitRequest() {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
