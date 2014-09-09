using UnityEngine;
using System.Collections;

public class PauseMenu : BasicGUI {

	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(15);

		if(GUI.Button(RectAligment.centerRect(25,50,20),"Resume")){
			GUIManager.getInstance().showPause();
		}

	
		if(GUI.Button(RectAligment.centerRect(42,50,10),"Restart")){
			GUIManager.getInstance().replayGame();
		}

		if(GUI.Button(RectAligment.centerRect(55,50,10),"Main Menu")){
			GUIManager.getInstance().showMainMenu();
		}

	}

}
