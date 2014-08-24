using UnityEngine;
using System.Collections;

public class OnPlay : MonoBehaviour {
	
	private string myScore="";
	
	public GUISkin myGuiSkin;	
	private GUI score;

	void OnGUI () {
		GUI.skin=myGuiSkin;

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(10);

		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(10);

		if(GUI.Button(RectAligment.rigthRect(1,30,10),"Pause")){
			GUIManager.getInstance().showPause();
		}

		GUI.Box(RectAligment.leftRect(1,30,10),Constants.SCORE_TEXT+myScore);
	}

	public void setMyScore(string myScore){
		this.myScore=myScore;
	}
}
