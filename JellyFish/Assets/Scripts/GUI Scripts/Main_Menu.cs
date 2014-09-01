using UnityEngine;
using System.Collections;

public class Main_Menu : BasicGUI{
	
	public GUISkin myGuiSkin;
	
	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(25);
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(9);

		if(GUI.Button(RectAligment.centerRect(15,60,20),"Play")){
			GUIManager.getInstance().showOnGame();
		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(8);
		if(GUI.Button(RectAligment.leftRect(1,25,6),"Options")){
			GUIManager.getInstance().showOptions();	
		}
		if(GUI.Button(RectAligment.rigthRect(1,25,8),"EXIT")){
			GUIManager.getInstance().closeApp();	
		}


		GUI.Box(RectAligment.centerRect(62,100,200),"TAP the screen \n to SCARE the Jelly Fish.");
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(18);
		GUI.Box(RectAligment.centerRect(35,100,200),"Best Score \n"+Persistence.getInstance().getHighscore());
	}

}
