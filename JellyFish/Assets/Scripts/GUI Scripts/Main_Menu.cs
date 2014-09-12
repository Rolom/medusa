using UnityEngine;
using System.Collections;

public class Main_Menu : BasicGUI{

	private ArrayList instructions;
	private int instructionsCount=0;

	public void addInstructions(){
		instructions=new ArrayList();
		instructions.Add("TAP the screen \n to SCARE the Jellyfish.");
		instructions.Add("TAP CLOSER to the jelly \n to MOVE it FASTER.");
		instructions.Add("Avoid the ROCK \n EAT the PLACKTOM.");
		instructions.Add("DON'T TAP on the JELLY \n you hurt his SOUL.");
		instructions.Add("RELAX, have FUN \n and SHARE your EXPERIENCE.");
	}
		
	void OnGUI () {
		if(instructions==null){
			addInstructions();
		}

		GUI.color=changeAlphaGui(GUI.color);
		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(25);
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(8);

		if(GUI.Button(RectAligment.centerRect(18	,60,20),"Play")){
			GUIManager.getInstance().showOnGame();
		}

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(8);
		if(GUI.Button(RectAligment.leftRect(1,25,6),"OPTIONS")){
			GUIManager.getInstance().showOptions();	
		}
		if(GUI.Button(RectAligment.rigthRect(1,25,8),"EXIT")){
			GUIManager.getInstance().closeApp();	
		}

		if(instructions.Count<=instructionsCount){
			instructionsCount=0;
		}
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(10);
		if(GUI.Button(RectAligment.centerRect(45,100,20),""+instructions[instructionsCount])){
			instructionsCount++;

		}

		GUI.Box(RectAligment.centerRect(90,100,10),"BEST SCORE "+Persistence.getInstance().getHighscore());
	}

	void Update () {
		if(alpha<1){
			alpha+=alphaDrow;
		}

		checkBackButton();

	}

	void checkBackButton ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			GUIManager.getInstance().closeApp();
		}
	}
}
