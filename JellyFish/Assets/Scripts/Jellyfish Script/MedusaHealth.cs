using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedusaHealth : MonoBehaviour {

	private List<Transform> tentacleList= new List<Transform>();
	private DistanceJoint2D sTentacle;
	private Rigidbody2D rTentacle;
	public GameObject jellyFishDieParticle;
	private bool touchJellyFlag;

	// Use this for initialization
	void Start () {
		foreach(Transform child in this.transform){
			tentacleList.Add(child);
		}
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
		print(other.gameObject.tag);
		deadState();
		//GUIManager.getInstance().showEndGame();
	}

	void calculateLoose(){
		if(tentacleList.Count==0){
			//GUIManager.getInstance().showEndGame();
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
		jellyFishDieParticle.transform.position=(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y));
		Instantiate(jellyFishDieParticle);
		Destroy(gameObject);
		playDeathSound();
		GUIManager.getInstance().showEndGame();
	}

	public void phoneVibration(){
		if(GUIManager.getInstance().optionsMenu.getVibrationState()){
			Handheld.Vibrate ();
		}
	}
	
}
