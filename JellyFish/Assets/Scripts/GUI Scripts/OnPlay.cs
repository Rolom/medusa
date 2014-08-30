﻿using UnityEngine;
using System.Collections;

public class OnPlay : MonoBehaviour {
	
	private string myScore="0";
	
	public GUISkin myGuiSkin;	
	private GUI score;

	void OnGUI () {

		GUI.skin=myGuiSkin;

		Color myColor =GUI.color;
		myColor.a=1f;
		GUI.color=myColor;

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(10);

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(10);

		if(GUI.Button(RectAligment.rigthRect(1,20,8),"Pause")){
			GUIManager.getInstance().showPause();
		}

		GUI.Box(RectAligment.leftRect(1,30,10),Constants.SCORE_TEXT+myScore);


		//hSliderValue = GUI.HorizontalSlider (RectAligment.centerRect(95, 50, 30), hSliderValue, 0f, 1.0f);

	}
	
	public void setMyScore(string myScore){
		this.myScore=myScore;
	}


	public void resetMyScore(){
		myScore="0";
	}
}
