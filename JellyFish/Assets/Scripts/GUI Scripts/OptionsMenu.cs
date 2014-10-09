using UnityEngine;
using System.Collections;

public class OptionsMenu : BasicGUI {
		
	private string SOUND_ON="Sound ON";
	private string SOUND_OFF="Sound OFF";
	private string VIBRATION_ON="Vibration ON";
	private string VIBRATION_OFF="Vibration OFF";
	public bool vibrationStateFlag;
	private string vibrateCondition;
	private string resetMessage="Reset Best Score";
	private int resetCount=0;
	private string soundCondition;
	private bool soundStateFlag;

	public void Awake()
	{
	}

	// Use this for initialization
	public void Start()
	{	
	}

	void OnGUI() {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(14);



		if(GUI.Button(RectAligment.centerRect(5,60,20),soundCondition)){
			defineSoundState();
		}

		if(GUI.Button(RectAligment.centerRect(17,60,20),vibrateCondition)){
			defineVibrationState();
		}

		if(GUI.Button(RectAligment.centerRect(29,60,20),"Credits")){
			GUIManager.getInstance().showCreditMenu();
		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(12);
		if(GUI.Button(RectAligment.centerRect(41,90,20),resetMessage)){
			resetCount++;
			switch(resetCount){
				case 1:
					resetMessage="You will Loose your Score";
				break;

				case 2:
					resetMessage="Are you Really Sure?";
				break;
				case 3:
				resetMessage="Reset, the last Warning!!";
				break;
				case 4:
					resetMessage="High Score = 0";
					Persistence.getInstance().resetHighscore();
				break;
			}
		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(13);
		if(GUI.Button(RectAligment.centerRect(53,60,20),"Back")){
			resetScoreMessageCount();
			GUIManager.getInstance().showMainMenu();
		}

	}

	void Update () {
		if(alpha<1){
			alpha+=alphaDrow;
		}
		
		checkBackButton();
		
	}

	public void resetScoreMessageCount(){
		resetMessage="Reset Best Score";
		resetCount=0;
	}

	public void defineSoundState(){
		if(soundStateFlag){
			soundCondition=SOUND_OFF;
			SoundManager.getInstance().pauseAudio();
			soundStateFlag=false;
		}else{
			soundCondition=SOUND_ON;
			SoundManager.getInstance().unPauseAudio();
			soundStateFlag=true;
		}
		Persistence.getInstance().setSound(!soundStateFlag);
	}

	public void defineVibrationState(){
		if(vibrationStateFlag){
			vibrateCondition=VIBRATION_OFF;
			vibrationStateFlag=false;
		}else{
			vibrateCondition=VIBRATION_ON;
			Handheld.Vibrate ();
			vibrationStateFlag=true;
		}
		Persistence.getInstance().setVibrate(!vibrationStateFlag);
	}

	public bool getVibrationState(){
		return vibrationStateFlag;
	}

	void checkBackButton ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GUIManager.getInstance().showMainMenu();
		}
	}

	public bool VibrationStateFlag {
		get {
			return vibrationStateFlag;
		}
		set {
			vibrationStateFlag = value;
		}
	}

	public bool SoundStateFlag {
		get {
			return soundStateFlag;
		}
		set {
			soundStateFlag = value;
		}
	}

	bool getPersistedSoundState ()
	{
		return Persistence.getInstance().isSoundEnable();
	}

	bool getPersistedVibrateState ()
	{
		return Persistence.getInstance().isVibrateEnable();
	}

	public void initSoundState ()
	{
		SoundStateFlag = getPersistedSoundState ();
		Debug.Log("Persisted sound state: " + SoundStateFlag);
		soundCondition = SoundStateFlag ? SOUND_ON : SOUND_OFF;
		defineSoundState();
	}

	public void initVibrationState ()
	{
		VibrationStateFlag = getPersistedVibrateState ();
		Debug.Log("Persisted vibration state: "+ VibrationStateFlag);
		vibrateCondition = VibrationStateFlag ? VIBRATION_ON : VIBRATION_OFF;
		defineVibrationState();
	}
}
