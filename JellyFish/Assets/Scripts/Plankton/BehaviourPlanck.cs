using UnityEngine;
using System.Collections;

public class BehaviourPlanck : MonoBehaviour {
	public float velocityCircleMoviment = 0.01f;
	public int limitCircleMoviment = 10;
	public int limitHorizontalMoviment = 100;
	public bool horizontalMovementAllowed = false;

	private bool rightHorizontalMoviment = true;
	private int quantityHorizontalMoviment = 0;
	private float sizeChangedX, sizeChangedY;
	private float velocityChangeSize= 0;
	private float factorVelocityChangeSize = 0.3f;
	private int movimentAxisX;
	private int movimentAxisY;
	private bool orientationRight;
	private bool dieFlag=false;
	private float scaleX;
	private float scaleY;

	public  GameObject dieParticles;
	private Vector3 dieParticlePos;

	public int score = 1;

	// Use this for initialization
	void Start () {
		scaleX=gameObject.transform.localScale.x;
		scaleY=gameObject.transform.localScale.y;
		movimentAxisX = getRandomMoviment (limitCircleMoviment);
		movimentAxisY = getRandomMoviment (limitCircleMoviment);

		orientationRight = getRandomOrientation ();

		initialRotation ();
	}
	
	// Update is called once per frame
	void Update () {
		horizontalMovement();
		circleMovement();
		
		velocityChangeSize += factorVelocityChangeSize;
		sizeChangedX = gameObject.transform.localScale.x + 0.01f * Mathf.Cos(velocityChangeSize);
		sizeChangedY = gameObject.transform.localScale.y + 0.01f * Mathf.Cos(velocityChangeSize);
		
		//Debug.Log(sizeChangedX);
		if(!dieFlag){
			gameObject.transform.localScale = new Vector3(sizeChangedX, sizeChangedY, 0);
		}else{
			dieAnimation();
		}

	}

	private void circleMovement(){
		if (orientationRight) {
			circleMovimentToRight();
		} else {
			circleMovimentToLeft();
		}
	}

	private void horizontalMovement(){

		if (horizontalMovementAllowed) {

			doHorizontalMovement();
			countMovimentAndChangeHorizontalMovement();
		}
	}

	private void doHorizontalMovement(){

		if (rightHorizontalMoviment) {
			quantityHorizontalMoviment++;
			gameObject.transform.Translate (velocityCircleMoviment, 0, 0);
		} else {
			quantityHorizontalMoviment--;
			gameObject.transform.Translate (-velocityCircleMoviment, 0, 0);
		}
	}

	private void countMovimentAndChangeHorizontalMovement(){
		if (quantityHorizontalMoviment >= limitHorizontalMoviment) {
			rightHorizontalMoviment = false;
		}
		if (quantityHorizontalMoviment <= -limitHorizontalMoviment) {
			rightHorizontalMoviment = true;
		}
	}


	void OnTriggerEnter2D(Collider2D col){ 
		if(col.gameObject.tag.Equals(Constants.JELLYFISH)){
			dieParticlePos=gameObject.transform.position;
			dieParticles.transform.position=dieParticlePos;
			Instantiate(dieParticles);
			ScoreManager.getInstance().addScore(getScoreToAdd());
			collider2D.enabled=false;
			dieFlag=true;
		}
	}

	private void initialRotation(){
		var angle = getRandomMoviment (360);
		gameObject.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	private bool getRandomOrientation(){
		if ((10/2) > getRandomMoviment (10)) {
			return true;
		} else {
			return false;
		}
	}
	
	private int getRandomMoviment(int limit){
		return Random.Range (0, limit);
	}
	
	private void changeSize(float factorChange){
		sizeChangedX = gameObject.transform.localScale.x + factorChange * Mathf.Cos(velocityChangeSize);
		sizeChangedY = gameObject.transform.localScale.y + factorChange * Mathf.Cos(velocityChangeSize);
		
		//Debug.Log(sizeChangedX);
		gameObject.transform.localScale = new Vector3(sizeChangedX, sizeChangedY, 0);
	}

	private void circleMovimentToRight(){
		if (movimentAxisX < limitCircleMoviment && movimentAxisY == 0) {
			gameObject.transform.Translate (velocityCircleMoviment, 0, 0);
			movimentAxisX++;
		} else if (movimentAxisX == limitCircleMoviment && movimentAxisY < limitCircleMoviment) {
			gameObject.transform.Translate (0, velocityCircleMoviment, 0);
			movimentAxisY++;
		} else if (movimentAxisX > -1 && movimentAxisY == limitCircleMoviment) {
			gameObject.transform.Translate (-velocityCircleMoviment, 0, 0);
			movimentAxisX--;
		} else {
			gameObject.transform.Translate (0, -velocityCircleMoviment, 0);
			movimentAxisY--;
		}
		
	}
	
	private void circleMovimentToLeft(){
		if (movimentAxisX > 0 && movimentAxisY == limitCircleMoviment) {
			gameObject.transform.Translate (-velocityCircleMoviment, 0, 0);
			movimentAxisX--;
		} else if (movimentAxisX == 0 && movimentAxisY > 0) {
			gameObject.transform.Translate (0, velocityCircleMoviment, 0);
			movimentAxisY--;
		} else if (movimentAxisX < limitCircleMoviment && movimentAxisY == 0) {
			gameObject.transform.Translate (velocityCircleMoviment, 0, 0);
			movimentAxisX++;
		} else {
			gameObject.transform.Translate (0, -velocityCircleMoviment, 0);
			movimentAxisY++;
		}
		
	}

	private void dieAnimation(){
		float decreaseVelocity=0.04f;
		scaleX-=decreaseVelocity;
		scaleY-=decreaseVelocity;
			gameObject.transform.localScale=new Vector2(scaleX,scaleY);
			if(gameObject.transform.localScale.x<0){
				Destroy(gameObject);
				playDeathSound();
			}
	}

	void playDeathSound ()
	{
		SoundManager.getInstance().PlanktonDeathSound.play();
	}

	public int getScoreToAdd()
	{
		return score;
	}
}

