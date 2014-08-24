using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	
	public GUISkin myGuiSkin;	
	
	void OnGUI () {
		GUI.skin=myGuiSkin;
		
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(10);
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(10);
		
		if(GUI.Button(RectAligment.centerRect(30,30,10),"Restart")){
			GUIManager.getInstance().replayGame();
		}
		if(GUI.Button(RectAligment.centerRect(40,30,10),"Main Menu")){
			GUIManager.getInstance().showMainMenu();
		}
		if(GUI.Button(RectAligment.centerRect(50,30,10),"Resume")){
			GUIManager.getInstance().showPause();
		}

	}

}
