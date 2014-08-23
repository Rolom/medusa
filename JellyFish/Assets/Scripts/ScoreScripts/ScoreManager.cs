using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private static ScoreManager _instance;

	private int score = 0;
	public Transform scoreTextPosition;
	private GUIText scoreText;

	public static ScoreManager getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<ScoreManager>();
		}
		return _instance;
	}
	void Start () {
		scoreText = GetComponent<GUIText> ();
		scoreText.transform.localPosition = scoreTextPosition.localPosition;
	}

	void Update () {
		scoreText.text = Constants.SCORE_TEXT + score;
	}

	public void addScore(int scoreToAdd)
	{
		score += scoreToAdd;
		Debug.Log ("Score at: " + score);
	}
}
