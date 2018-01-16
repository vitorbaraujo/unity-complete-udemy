using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	public Text text;
	
	void Start () {
		text = GetComponent<Text>();
		text.text = ScoreController.score.ToString();
		ScoreController.Reset();
	}

	void Update () {
	
	}
}
