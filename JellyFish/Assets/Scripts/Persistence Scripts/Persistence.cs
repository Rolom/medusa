	using UnityEngine;
using System.Collections;

public class Persistence : MonoBehaviour {

	private static Persistence _instance;
	private static string TRUE = "true";
	private static string FALSE = "false";
	private int actualHighscore = -1;

	private bool soundEnable;
	private bool vibrateEnable;
	private bool tutorialEnable;

	public static Persistence getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<Persistence>();
		}
		return _instance;
	}

	public bool isSoundEnable()
	{
		soundEnable = false;
		string soundEnableValue = PlayerPrefs.GetString(Constants.IS_SOUND_ENABLE);
		if(TRUE.Equals(soundEnableValue) || soundEnableValue == null)
		{
			soundEnable = true;
		}

		return soundEnable;
	}

	public void setSound(bool soundOption)
	{
		soundEnable = soundOption;
		PlayerPrefs.SetString(Constants.IS_SOUND_ENABLE, soundEnable ? TRUE : FALSE);
	}

	public bool isVibrateEnable()
	{
		vibrateEnable = false;
		string vibrateEnableValue = PlayerPrefs.GetString(Constants.IS_VIBRATE_ENABLE);
		if(TRUE.Equals(vibrateEnableValue) || vibrateEnableValue == null)
		{
			vibrateEnable = true;
		}
		return vibrateEnable;
	}

	public void setVibrate(bool vibrateOption)
	{
		vibrateEnable = vibrateOption;
		PlayerPrefs.SetString(Constants.IS_VIBRATE_ENABLE, vibrateEnable ? TRUE : FALSE);
	}

	public void setTutorialCompleted(bool tutorialNewValue)
	{
		tutorialEnable = tutorialNewValue;
		print ("Tutorial SAVING tutorial:"+tutorialEnable);
		PlayerPrefs.SetString(Constants.IS_TUTORIAL_ENABLE, tutorialEnable ? TRUE : FALSE);
	}

	public bool isTutorialComplete()
	{
		tutorialEnable = true;
		string tutorialEnableValue = PlayerPrefs.GetString(Constants.IS_TUTORIAL_ENABLE);
		if(FALSE.Equals(tutorialEnableValue) || tutorialEnableValue == null)
		{
			tutorialEnable = false;
		}
		print ("Tutorial is tutorial COMPLETE:"+tutorialEnable);
		return tutorialEnable;
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
		//Debug.Log("Highscore is: "+ actualHighscore);
	}

	public void resetHighscore(){
		setHighscore(0);
		actualHighscore = 0;
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
