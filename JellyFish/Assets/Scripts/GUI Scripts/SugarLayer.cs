using UnityEngine;
using System.Collections;

public class SugarLayer : BasicGUI {

	private int score;
	public GameObject particles;
	private GameObject currentParticles;

	public void OnEnable(){
		score=ScoreManager.getInstance().getScore();
		currentParticles=(GameObject)Instantiate(particles);
	}

	public void Update(){
		if(currentParticles==null){
				if(alpha>0){
					alpha-=alphaDrow;
				}else{
					gameObject.SetActive(false);
				}
			}else{
				if(alpha<1){
				alpha+=alphaDrow;
				}
			}

	}

	void OnGUI () {
		GUI.color=changeAlphaGui(GUI.color);
		
		GUI.skin=myGuiSkin;
		myGuiSkin.box.fontSize=ProportionFontSize.PorcentageFontSize(15);

		GUI.Box(RectAligment.centerRect(30,80,60),"NEW \n BEST SCORE!!");
		
	}


	
}
