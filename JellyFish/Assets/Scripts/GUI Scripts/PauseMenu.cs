using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUISkin myGuiSkin;	
	
	void OnGUI () {
		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(20);

		if(GUI.Button(RectAligment.centerRect(25,50,20),"Resume")){
			GUIManager.getInstance().showPause();
		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(10);
		if(GUI.Button(RectAligment.centerRect(45,30,10),"Restart")){
			GUIManager.getInstance().replayGame();
		}

		if(GUI.Button(RectAligment.centerRect(55,30,10),"Main Menu")){
			GUIManager.getInstance().showMainMenu();
		}

	}

}
