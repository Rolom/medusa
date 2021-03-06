﻿using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private static ScoreManager _instance;

	private int score = 0;

	public int bonus;

	public static ScoreManager getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<ScoreManager>();
		}
		return _instance;
	}
	void Start () {

	}

	void Update () {

	}

	public void addScore(int scoreToAdd)
	{
		if(!StageGameManager.getInstance().TutorialFlag){
			score += scoreToAdd;
			GUIManager.getInstance ().getOnPlay ().setMyScore (score + "");
		}
	}

	public int getScore(){
		return score;
	}

	public void resetScore(){
		score=0;
	}

	public void addBonusToScore()
	{
		score += bonus;
		GUIManager.getInstance ().getOnPlay ().setMyScore (score + "");
	}
}
