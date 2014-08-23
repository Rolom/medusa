using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

	private float sWidth=Screen.width;
	private float sHeight=Screen.height;
	public StageGameManager stageGameManager;

	public GUISkin myGuiSkin;

	void OnGUI () {
		GUI.skin=myGuiSkin;

		// Make a background box
		//GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		myGuiSkin.button.fontSize=(int)(sWidth/4);
		myGuiSkin.box.fontSize=(int)(sWidth/10);
		if(GUI.Button(makeXCenterRect((sWidth/5)*2,200,90),"Play")){
			stageGameManager.setCanCreateScenario(true);
			gameObject.SetActive(false);
		}

		myGuiSkin.button.fontSize=(int)(sWidth/8);
		if(GUI.Button(makeXCenterRect((sWidth/5)*3,200,90),"Credits")){
			//Application.LoadLevel(1);
		}


		GUI.Box(makeXCenterRect((sWidth/5)*4,400,200),"Touch the screen to play.");
	}

	private Rect makeXCenterRect(float y,int w,int h){
		float x=sWidth/2-w/2;
		Rect myRect= new Rect(x,y,w,h);

		return myRect;
	}
}
