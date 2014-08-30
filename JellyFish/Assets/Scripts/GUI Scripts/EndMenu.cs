using UnityEngine;
using System.Collections;

public class EndMenu : BasicGUI {
	
	public GUISkin myGuiSkin;
	
	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(15);
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(20);
		
		if(GUI.Button(RectAligment.centerRect(20,40,15),"Replay")){
			GUIManager.getInstance().replayGame();
		}

		if(GUI.Button(RectAligment.centerRect(30,50,15),"Main Menu")){
			GUIManager.getInstance().showMainMenu();
		}
		
		GUI.Box(RectAligment.centerRect(55,100,100),"Final Score \n"+ScoreManager.getInstance().getScore());
	}
	

}