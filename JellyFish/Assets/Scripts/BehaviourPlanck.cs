using UnityEngine;
using System.Collections;

public class BehaviourPlanck : MonoBehaviour {
	public float velocityCircleMoviment = 0.01f;
	public int limitCircleMoviment = 10;

	private float sizeChangedX, sizeChangedY;
	private float velocityChangeSize= 0;
	private float factorVelocityChangeSize = 0.3f;
	private int movimentAxisX;
	private int movimentAxisY;
	private bool orientationRight;

	public  GameObject dieParticles;
	private Vector3 dieParticlePos;

	// Use this for initialization
	void Start () {
		movimentAxisX = getRandomMoviment (limitCircleMoviment);
		movimentAxisY = getRandomMoviment (limitCircleMoviment);

		orientationRight = getRandomOrientation ();
	}
	
	// Update is called once per frame
	void Update () {
		if (orientationRight) {
			circleMovimentToRight();
		} else {
			circleMovimentToLeft();
		}
		
		velocityChangeSize += factorVelocityChangeSize;
		sizeChangedX = gameObject.transform.localScale.x + 0.01f * Mathf.Cos(velocityChangeSize);
		sizeChangedY = gameObject.transform.localScale.y + 0.01f * Mathf.Cos(velocityChangeSize);
		
		//Debug.Log(sizeChangedX);
		gameObject.transform.localScale = new Vector3(sizeChangedX, sizeChangedY, 0);

	}

	void OnTriggerEnter2D(Collider2D col){ 
		if(col.gameObject.tag.Equals(Constants.JELLYFISH)){
			changeSize(1);

			Instantiate(dieParticles);
			dieParticlePos=gameObject.transform.position;
			dieParticles.transform.position=dieParticlePos;
			Destroy (gameObject);
		}
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
}

