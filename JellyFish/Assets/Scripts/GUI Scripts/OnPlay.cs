using UnityEngine;
using System.Collections;

public class OnPlay : MonoBehaviour {

	private float sWidth=Screen.width;
	private float sHeight=Screen.height;
	private string myScore="N/A";
	
	public GUISkin myGuiSkin;	
	private GUI score;

	void OnGUI () {
		GUI.skin=myGuiSkin;

		myGuiSkin.box.fontSize=(int)(sWidth/10);

		GUI.Box(leftRect(1,30,200),Constants.SCORE_TEXT+myScore);
	}

	private Rect leftRect(float y,int w,int h){
		float pW=(sWidth*w)/100;
		float x=sWidth-pW;
		float pH=(sHeight*h)/100;
		float pY=(sHeight*y)/100;
		Rect myRect= new Rect(x,pY,pW,pH);
		
		return myRect;
	}

	public void setMyScore(string myScore){
		this.myScore=myScore;
	}
}
