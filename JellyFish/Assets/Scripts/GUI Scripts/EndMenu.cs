using UnityEngine;
using System.Collections;

public class EndMenu : BasicGUI {
	
	public GUISkin myGuiSkin;
	private ArrayList phrasesList;
	private string currentPhrace;

	public void addPhraces(){
		phrasesList=new ArrayList();
		phrasesList.Add("A jelly fish is 96% water.... \n but a 100% deepnes.");
		phrasesList.Add("Somethimes, you just \n have to let go... and flow.");
		phrasesList.Add("Can be the soul \n so deep?.");
		phrasesList.Add("Your mind and body are only\n a illusions that hide the truth.");
		phrasesList.Add("Stop Thinking, \n Start experiencing.");
	}

	public void OnEnable(){
		if(phrasesList==null){
			addPhraces();
		}
		choosePhrase();
	}
	
	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);

		GUI.skin=myGuiSkin;
		
		myGuiSkin.button.fontSize=ProportionFontSize.PorcentageFontSize(15);

		
		if(GUI.Button(RectAligment.centerRect(15,40,15),"Replay")){
			GUIManager.getInstance().replayGame();
		}

		if(GUI.Button(RectAligment.centerRect(30,50,15),"Main Menu")){
			GUIManager.getInstance().showMainMenu();
		}

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(10);
		GUI.Box(RectAligment.centerRect(46,100,100),currentPhrace);

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(15);
		GUI.Box(RectAligment.centerRect(65,100,100),"Final Score: "+ScoreManager.getInstance().getScore());
	}

	private void choosePhrase(){
		int randomPhraseSelector=Random.Range(1,phrasesList.Count);
		currentPhrace=""+phrasesList[randomPhraseSelector];
	}
	

}