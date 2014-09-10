using UnityEngine;
using System.Collections;

public class CreditsMenu : BasicGUI {

	private ArrayList credits;
	private float yPosition=-20f;
	private float yVelocity=0.25f;
	private int creditCount=0;
	private float OUT_OF_SCREEN=110f;
	private float BEGINING_POSITION=-20f;

	void OnEnable(){
		yPosition=BEGINING_POSITION;
		creditCount=0;
	}

	// Use this for initialization
	private void addCredits () {
		credits = new ArrayList();
		credits.Add("QuantumVaccum\nStudio");
		credits.Add("Rolando Martinez\n (Sound FX, Dev, CM)");
		credits.Add("Hector Poblete\n (Dev, CM)");
		credits.Add("Fernanda De La Hoz\n (Artist, Dev, \nLevel Designer)");
	    credits.Add("Nolberto Luengo\n (Dev, Marketing)");
		credits.Add("Gabriel De Ioannes\n (Game Designer, Dev,\n Artis, UX)");
	    credits.Add("Mauricio Castro\n (Architec, Dev)");
		credits.Add("Pablo Alvarez\n (Music, Dev, \nLevel Designer)");

		credits.Add("QuantumVaccum\nStudio");

	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);
		if(credits==null){
			addCredits();
		}
		
		GUI.skin=myGuiSkin;

		if(GUI.Button(RectAligment.rigthRect(1,25,8),"Back")){
			GUIManager.getInstance().showOptions();
		}

		yPosition+=yVelocity;
		if(yPosition>OUT_OF_SCREEN){
			creditCount++;
			yPosition=BEGINING_POSITION;
		}

		if(creditCount>=credits.Count){
			creditCount=1;
		}

		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(14);
		GUI.Box(RectAligment.centerRect(yPosition,100,100),""+credits[creditCount]);
		
	}
}
