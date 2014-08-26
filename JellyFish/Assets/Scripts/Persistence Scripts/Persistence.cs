using UnityEngine;
using System.Collections;

public class Persistence : MonoBehaviour {

	private static Persistence _instance;

	public static Persistence getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<Persistence>();
		}
		return _instance;
	}

	public int getHighscore()
	{
		int highScore = PlayerPrefs.GetInt(Constants.HIGHSCORE);
		return highScore;
	}

	private void setHighscore(int newHighscore)
	{
		PlayerPrefs.SetInt(Constants.HIGHSCORE, newHighscore);
	}

	public void replaceHighScore(int newHighscore)
	{
		int actualHighscore = getHighscore();
		if(actualHighscore != null)
		{
			if(actualHighscore < newHighscore)
			{
				setHighscore(newHighscore);
				PlayerPrefs.Save();
			}
		}
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Highscore is: " + getHighscore());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
