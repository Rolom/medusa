using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {
	
	private float sWidth=Screen.width;
	private float sHeight=Screen.height;

	public GUISkin myGuiSkin;

	void OnGUI () {
		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=(int)(sWidth/4);
		myGuiSkin.box.fontSize=(int)(sWidth/10);

		if(GUI.Button(centerRect(20,60,15),"Play")){
			StageGameManager.getInstance().setCanCreateScenario(true);
			gameObject.SetActive(false);
		}

		myGuiSkin.button.fontSize=(int)(sWidth/8);
		if(GUI.Button(centerRect(35,40,15),"Credits")){
			//Application.LoadLevel(1);
		}


		GUI.Box(centerRect(45,100,200),"Touch the screen to play.");
	}

	private Rect centerRect(float y,int w,int h){
		float pW=(sWidth*w)/100;
		float x=sWidth/2-pW/2;
		float pH=(sHeight*h)/100;
		float pY=(sHeight*y)/100;
		Rect myRect= new Rect(x,pY,pW,pH);

		return myRect;
	}
}
