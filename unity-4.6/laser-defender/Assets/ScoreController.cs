using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	private int currentScore = 0;
	private Text myText;

	void Start() {
		myText = GetComponent<Text>();
		myText.text = "0";
	}

	public void Score(int points) {
		currentScore += points;
		myText.text = currentScore.ToString();
	}

	public void Reset() {
		currentScore = 0;
		myText.text = currentScore.ToString ();
	}
}
