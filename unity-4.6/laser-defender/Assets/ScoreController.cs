﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public static int score = 0;
	private Text myText;

	void Start() {
		myText = GetComponent<Text>();
		myText.text = "0";
	}

	public void Score(int points) {
		score += points;
		myText.text = score.ToString();
	}

	public static void Reset() {
		score = 0;
	}
}
