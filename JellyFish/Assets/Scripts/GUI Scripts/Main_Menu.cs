using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {
	
	public GUISkin myGuiSkin;

	public void Update(){
		//animatePosY+=Time.deltaTime*10;
	}

	void OnGUI () {
		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(25);
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(9);

		if(GUI.Button(RectAligment.centerRect(15,60,20),"Play")){
			GUIManager.getInstance().showOnGame();
		}

		//myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(15);
		//if(GUI.Button(RectAligment.centerRect(30,40,15),"Credits")){
			//Application.LoadLevel(1);
		//}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(8);
		if(GUI.Button(RectAligment.rigthRect(1,25,8),"EXIT")){
			GUIManager.getInstance().closeApp();	
		}


		GUI.Box(RectAligment.centerRect(62,100,200),"Touch the screen \n to move the Jelly Fish.");
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(18);
		GUI.Box(RectAligment.centerRect(35,100,200),"Best Score \n"+Persistence.getInstance().getHighscore());
	}

}
