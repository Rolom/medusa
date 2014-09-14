using UnityEngine;
using System.Collections;

public class OnPlay : BasicGUI {
	
	private string myScore="0";
	private GUI score;
	private string bonus="";
	private int bonusCount=0;
	private int saveScore=0;
	private bool bonusFlag=false;
	private int intMyScore=0;

	void OnGUI () {
		intMyScore=ScoreManager.getInstance().getScore();
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(10);

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(10);

		if(GUI.Button(RectAligment.rigthRect(1,20,8),"Pause")){
			GUIManager.getInstance().showPause();
		}

		print (intMyScore-saveScore);
		if(intMyScore-saveScore>1){
			bonus="Bonus +"+(intMyScore-saveScore);
			bonusFlag=true;
		}
		saveScore=intMyScore;
		if(bonusFlag){
			bonusCount++;
			if(bonusCount>400){
				bonusCount=0;
				bonusFlag=false;
				bonus="";
			}
		}

		GUI.Box(RectAligment.leftRect(1,30,10),Constants.SCORE_TEXT+myScore);

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(8);
		GUI.Box(RectAligment.leftRect(8,30,10),bonus);

		//hSliderValue = GUI.HorizontalSlider (RectAligment.centerRect(95, 50, 30), hSliderValue, 0f, 1.0f);

	}
	
	public void setMyScore(string myScore){
		this.myScore=myScore;
	}


	public void resetMyScore(){
		myScore="0";
	}
}
