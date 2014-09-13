using UnityEngine;
using System.Collections;

public class BehaviourPlanck : MonoBehaviour {
	public float velocityCircleMovement = 0.01f;
	public float velocityHorizontalMovement = 0.01f;
	public int limitCircleMovement = 10;
	public int limitHorizontalMovement = 100;
	public bool horizontalMovementAllowed = false;
	public bool randomInitialHorizontalMovement = false;

	private bool rightHorizontalMovement = true;
	private int quantityHorizontalMovement = 0;
	private float sizeChangedX, sizeChangedY;
	private float velocityChangeSize= 0;
	private float factorVelocityChangeSize = 0.3f;
	private int movementAxisX;
	private int movementAxisY;
	private bool orientationRight;
	private bool dieFlag=false;
	private float scaleX;
	private float scaleY;

	public  GameObject dieParticles;
	private Vector3 dieParticlePos;

	public int score = 1;
	public int id;

	// Use this for initialization
	void Start () {
		scaleX=gameObject.transform.localScale.x;
		scaleY=gameObject.transform.localScale.y;
		movementAxisX = getRandomMovement (limitCircleMovement);
		movementAxisY = getRandomMovement (limitCircleMovement);

		orientationRight = getRandomOrientation ();
		checkAndDoHorizontalMovement ();

		initialRotation ();
	}

	void OnBecameVisible() {
		//id = StageGameManager.getInstance ().planktonCount ++;
	}

	public void setId(int id)
	{
		this.id = id;
	}

	private void checkAndDoHorizontalMovement(){
		if (randomInitialHorizontalMovement) {
			rightHorizontalMovement = getRandomOrientation();
		}
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
			circleMovementToRight();
		} else {
			circleMovementToLeft();
		}
	}

	private void horizontalMovement(){

		if (horizontalMovementAllowed) {

			doHorizontalMovement();
			countMovementAndChangeHorizontalMovement();
		}
	}

	private void doHorizontalMovement(){

		if (rightHorizontalMovement) {
			quantityHorizontalMovement++;
			gameObject.transform.Translate (velocityHorizontalMovement, 0, 0, Camera.main.transform);
		} else {
			quantityHorizontalMovement--;
			gameObject.transform.Translate (-velocityHorizontalMovement, 0, 0, Camera.main.transform);
		}
	}

	private void countMovementAndChangeHorizontalMovement(){
		if (quantityHorizontalMovement >= limitHorizontalMovement) {
			rightHorizontalMovement = false;
		}
		if (quantityHorizontalMovement <= -limitHorizontalMovement) {
			rightHorizontalMovement = true;
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
		var angle = getRandomMovement (360);
		gameObject.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

	private bool getRandomOrientation(){
		if ((10/2) > getRandomMovement (10)) {
			return true;
		} else {
			return false;
		}
	}
	
	private int getRandomMovement(int limit){
		return Random.Range (0, limit);
	}
	
	private void changeSize(float factorChange){
		sizeChangedX = gameObject.transform.localScale.x + factorChange * Mathf.Cos(velocityChangeSize);
		sizeChangedY = gameObject.transform.localScale.y + factorChange * Mathf.Cos(velocityChangeSize);
		
		//Debug.Log(sizeChangedX);
		gameObject.transform.localScale = new Vector3(sizeChangedX, sizeChangedY, 0);
	}

	private void circleMovementToRight(){
		if (movementAxisX < limitCircleMovement && movementAxisY == 0) {
			gameObject.transform.Translate (velocityCircleMovement, 0, 0);
			movementAxisX++;
		} else if (movementAxisX == limitCircleMovement && movementAxisY < limitCircleMovement) {
			gameObject.transform.Translate (0, velocityCircleMovement, 0);
			movementAxisY++;
		} else if (movementAxisX > -1 && movementAxisY == limitCircleMovement) {
			gameObject.transform.Translate (-velocityCircleMovement, 0, 0);
			movementAxisX--;
		} else {
			gameObject.transform.Translate (0, -velocityCircleMovement, 0);
			movementAxisY--;
		}
		
	}
	
	private void circleMovementToLeft(){
		if (movementAxisX > 0 && movementAxisY == limitCircleMovement) {
			gameObject.transform.Translate (-velocityCircleMovement, 0, 0);
			movementAxisX--;
		} else if (movementAxisX == 0 && movementAxisY > 0) {
			gameObject.transform.Translate (0, velocityCircleMovement, 0);
			movementAxisY--;
		} else if (movementAxisX < limitCircleMovement && movementAxisY == 0) {
			gameObject.transform.Translate (velocityCircleMovement, 0, 0);
			movementAxisX++;
		} else {
			gameObject.transform.Translate (0, -velocityCircleMovement, 0);
			movementAxisY++;
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
				print ("dead " + id);
			}
	}

	void playDeathSound ()
	{
		SoundManager.getInstance().PlanktonDeathSound.play(this);
	}

	public int getScoreToAdd()
	{
		return score;
	}

	public void playPlanktonAchivment(){
		GameObject prefab = Resources.Load ("PlactomAchievementParticle") as GameObject;
		Vector3 position=(new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,2f));
		GameObject plactomAchievementParticle = Instantiate(prefab, position, Quaternion.identity) as GameObject;
	}
}

