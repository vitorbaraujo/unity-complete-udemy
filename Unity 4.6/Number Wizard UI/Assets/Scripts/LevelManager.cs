using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string game) {
		Debug.Log ("Level requested for " + game);
		Application.LoadLevel (game);
	}

	public void QuitRequest() {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
