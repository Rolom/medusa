﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedusaHealth : MonoBehaviour {

	private List<Transform> tentacleList= new List<Transform>();
	private DistanceJoint2D sTentacle;
	private Rigidbody2D rTentacle;
	public GameObject jellyFishDieParticle;
	private bool touchJellyFlag;
	private int numberOfTentacles;


	// Use this for initialization
	void Start () {
		foreach(Transform child in this.transform){
			if(child.name=="Tentacle"){
				tentacleList.Add(child);
			}
		}
		numberOfTentacles=tentacleList.Count;

	}

	// Update is called once per frame
	void Update () {
		calculateLoose();
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) {
			if (Input.touchCount > 0) {
				if(collider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position)) && !touchJellyFlag){
					gameObject.GetComponent<MedusaHealth>().detachTentacle();
					touchJellyFlag=true;
					phoneVibration();
				}
			}else{
				touchJellyFlag=false;
			}
		}else{
			if (Input.GetKeyDown (KeyCode.Mouse0)  ) {
			if (collider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) ) {
				gameObject.GetComponent<MedusaHealth>().detachTentacle();
				touchJellyFlag=true;
			}
			}else{
				touchJellyFlag=false;
			}

		}
	}

	void OnCollisionEnter2D(Collision2D  other)
	{
		print(other.gameObject.name);
		deadState();
	}

	void calculateLoose(){
		if(tentacleList.Count== 0 ){
			deadState();
		}
	}

	public void detachTentacle(){
		if(tentacleList.Count>=1){
			Transform selectedTentacle=tentacleList[Random.Range(0,tentacleList.Count)];
			sTentacle=selectedTentacle.GetComponent<DistanceJoint2D>();
			sTentacle.enabled=false;
			rTentacle=selectedTentacle.GetComponent<Rigidbody2D>();
			rTentacle.mass=1;
			rTentacle.gravityScale=2;
			tentacleList.Remove(selectedTentacle);
			gameObject.GetComponent<MedusaAnimation>().setDamageFlag(true);
		}
	}

	void playDeathSound ()
	{
		SoundManager.getInstance().JellyDeathSound.play();
	}

	public void deadState(){
		phoneVibration();
		Persistence.getInstance().replaceHighScore(ScoreManager.getInstance().getScore());
		collider2D.enabled=false;
		jellyFishDieParticle.transform.position=(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-8f));
		Instantiate(jellyFishDieParticle);
		Destroy(gameObject);
		playDeathSound();
		if(StageGameManager.getInstance().getOnGameFlag()){
			GUIManager.getInstance().showEndGame();
		}else{
			StageGameManager.getInstance().resetJellyFish();
		}
	}

	public void phoneVibration(){
		if(GUIManager.getInstance().optionsMenu.getVibrationState()){
			Handheld.Vibrate ();
		}
	}

	public bool getCompareOfTentacle(){
		return tentacleList.Count==numberOfTentacles;
	}

	public List<Transform> getTentacleList(){
		return tentacleList;
	}
	
}
