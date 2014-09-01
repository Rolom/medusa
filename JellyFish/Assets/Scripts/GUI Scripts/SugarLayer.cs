﻿using UnityEngine;
using System.Collections;

public class SugarLayer : BasicGUI {

	public GUISkin myGuiSkin;	
	private int score;
	public GameObject particles;

	public void OnEnable(){
		score=ScoreManager.getInstance().getScore();
	}

	public void Update(){
		if(!particles.GetComponent<ParticleSystem>().isPlaying){
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
