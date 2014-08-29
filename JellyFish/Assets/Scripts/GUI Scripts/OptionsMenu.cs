using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {

	public GUISkin myGuiSkin;	
	private string SOUND_ON="Sounds ON";
	private string SOUND_OFF="Sounds OFF";
	private string resetMessage="Reset Best Score";
	private int resetCount=0;
	private string soundCondition;
	private bool soundState=true;

	// Use this for initialization
	public void Start(){
		soundCondition=SOUND_ON;
	}

	void OnGUI() {

		GUI.skin=myGuiSkin;

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(14);
		if(GUI.Button(RectAligment.centerRect(15,60,20),soundCondition)){
			defineSoundState();
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
		if(soundState){
			soundCondition=SOUND_OFF;
			soundState=false;
		}else{
			soundCondition=SOUND_ON;
			soundState=true;
		}
	}
	

}
