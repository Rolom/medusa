﻿using UnityEngine;
using System.Collections;

public class OptionsMenu : BasicGUI {

	public GUISkin myGuiSkin;	
	private string SOUND_ON="Sounds ON";
	private string SOUND_OFF="Sounds OFF";
	private string VIBRATION_ON="Vibration ON";
	private string VIBRATION_OFF="Vibration OFF";
	private bool vibrationStateFlag=true;
	private string resetMessage="Reset Best Score";
	private int resetCount=0;
	private string soundCondition;
	private bool soundStateFlag=true;
	public GameObject camera;

	// Use this for initialization
	public void Start(){
		soundCondition=SOUND_ON;
	}

	void OnGUI() {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(14);
		if(GUI.Button(RectAligment.centerRect(15,60,20),soundCondition)){

		}

		if(GUI.Button(RectAligment.centerRect(15,60,20),soundCondition)){
			defineSoundState();
			camera.GetComponent<AudioListener>().enabled=(soundStateFlag);
		}

		if(GUI.Button(RectAligment.centerRect(30,60,20),"Credits")){

		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(12);
		if(GUI.Button(RectAligment.centerRect(42,90,20),resetMessage)){
			resetCount++;
			switch(resetCount){
				case 1:
					resetMessage="You will Loose your Score";
				break;

				case 2:
					resetMessage="Really Sure?";
				break;
				case 3:
				resetMessage="Reset last Warning!!";
				break;
				case 4:
					resetMessage="High Score = 0";
					Persistence.getInstance().resetHighscore();
				break;
			}
		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(13);
		if(GUI.Button(RectAligment.centerRect(55,60,20),"Back")){
			resetScoreMessageCount();
			GUIManager.getInstance().showMainMenu();
		}

	}

	public void resetScoreMessageCount(){
		resetMessage="Reset Best Score";
		resetCount=0;
	}

	public void defineSoundState(){
		if(soundStateFlag){
			soundCondition=SOUND_OFF;
			soundStateFlag=false;
		}else{
			soundCondition=SOUND_ON;
			soundStateFlag=true;
		}
	}
	

}
