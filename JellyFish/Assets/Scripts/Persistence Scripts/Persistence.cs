	using UnityEngine;
using System.Collections;

public class Persistence : MonoBehaviour {

	private static Persistence _instance;
	private int actualHighscore = -1;

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
		if(actualHighscore == -1)
		{
			actualHighscore = PlayerPrefs.GetInt(Constants.HIGHSCORE);
		}
		return actualHighscore;
	}

	private void setHighscore(int newHighscore)
	{
		PlayerPrefs.SetInt(Constants.HIGHSCORE, newHighscore);
	}

	public void replaceHighScore(int newHighscore)
	{
		if(getHighscore() < newHighscore)
		{
			setHighscore(newHighscore);
			actualHighscore = newHighscore;
			PlayerPrefs.Save();
		}
	}

	public bool isHighscore(int posibbleHighscore)
	{
		if(posibbleHighscore > getHighscore())
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	// Use this for initialization
	void Start () {
		actualHighscore = getHighscore();
		Debug.Log("Highscore is: "+ actualHighscore);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
