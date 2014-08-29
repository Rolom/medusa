using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	static float LINEAR_VELOCITY = 25.0f;
	static float MAXIMUM_ROTATION_ANGLE = 60.0f;	//in degrees.
	static float MAXIMUM_VECTOR_VELOCITY=300.0f;
	private float verticalPosition;
	public GameObject verticalToken;
	private float forceMultiplier=1.3f;


	Vector2 moveLeft;
	Vector2 moveRight;
	
	// Use this for initialization
	void Start () {
		moveLeft = new Vector2 (-1, 0);
		moveRight = new Vector2 (1, 0);
		verticalPosition=verticalToken.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		setMedusaStraight();
		removeVerticalVelocity ();

		CircleCollider2D circleCollider2D = (CircleCollider2D)collider2D;
		if (Application.platform == RuntimePlatform.Android) {

			if (Input.touchCount > 0) {

				if(Input.GetTouch(0).phase == TouchPhase.Began && !circleCollider2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) ) ) {
					AnimateCharacter (Input.GetTouch(0).position);

				}
			}

		} else {

			if (Input.GetKeyDown (KeyCode.Mouse0) && !circleCollider2D.OverlapPoint( Camera.main.ScreenToWorldPoint(Input.mousePosition) ) ) {
				AnimateCharacter(Input.mousePosition);
			}
		}

	}

	void FixedUpdate(){
		float range = 1.0f/3.0f;
		float currentRotation = transform.rotation.z;

		//print (" preangular: " + transform.rotation.z);
		//print("Angular position: " + currentRotation);

		if( currentRotation < -range || currentRotation > range){
			rigidbody2D.angularVelocity = 0.0f;
		}
		rigidbody2D.AddForce( returnToVerticalPosition() );
	}

	void AnimateCharacter(Vector3 position) {
		Vector2 mouseVector = Camera.main.ScreenToWorldPoint(position);
		Vector2 characterVector = transform.position;
		Vector2 newDirection = characterVector - mouseVector;

		rigidbody2D.AddForce( moveLinearMedusa(newDirection) );

		rigidbody2D.AddTorque( addTorqueForMedusa(newDirection) );

		//print ("Local Rotation " + (transform.localRotation.z) * (180/Mathf.PI));
	}

	float getAngle( Transform transform)
	{
		float localAngle = transform.localRotation.z * ( 180/Mathf.PI);

		localAngle = 90 + localAngle;
		print ("Local angle: " + (localAngle) );
		return localAngle;
	}

	Vector2 moveLinearMedusa (Vector2 newDirection)
	{
		float vectorMagnitud = inverseVectorMagnitude(newDirection.magnitude)*forceMultiplier;

		if(vectorMagnitud>MAXIMUM_VECTOR_VELOCITY){
			vectorMagnitud=MAXIMUM_VECTOR_VELOCITY;
		}

		Vector2 directionVector = new Vector2();

		print ("Vector Magnitude: " + vectorMagnitud);

		if (newDirection.x < 0) {
			directionVector.Set(-1 * vectorMagnitud, 0);
		} else if (newDirection.x > 0) {
			directionVector.Set(vectorMagnitud, 0);
		} else {
			directionVector.Set(0,0);
		}

		return directionVector;
	}

	Vector2 returnToVerticalPosition(){
		float upForce=0.4f;
		float verticalPositionOffset=0.2f;
		float minimunVerticalPosition=verticalPosition-verticalPositionOffset;

		Vector2 upVector = new Vector2();

		if(transform.position.y<minimunVerticalPosition){
			upVector.Set(0, upForce);
		}else{
			upVector.Set(0, 0);
		}

		return upVector;

	}

	float inverseVectorMagnitude( float magnitude ){
		return 1 / Mathf.Pow (magnitude, 2) * LINEAR_VELOCITY;
	}

	float addTorqueForMedusa( Vector2 newDirection ){

		float torqueFromClick = 1.0f * inverseVectorMagnitude(newDirection.magnitude);

		if (newDirection.x < 0) {
			// do nothing

		} else if (newDirection.x > 0) {
			//directionVector.Set(vectorMagnitud, 0);
			torqueFromClick *= -1;

		} else {
			//directionVector.Set(0,0);
			torqueFromClick *= 0;
		}

		//print ("magnitud torque: " + torqueFromClick);
		return torqueFromClick;
	}

	void removeVerticalVelocity(){

		float Xaxisvelocity = rigidbody2D.velocity.x;
		Vector2 newLinearDirection = new Vector2 (Xaxisvelocity, 0);

		if (rigidbody2D.velocity.y != 0 || transform.position.y != 0) {
			//print("Entered remove vertical velocity");
			float x = transform.position.x;
			transform.localPosition.Set(x, 0, 0);
		}
	}

	void setMedusaStraight(){
		float straightTorque = 3.0f;
	
		float currentRotation = transform.rotation.z;
		float netTorque = straightTorque * -1 * currentRotation ;
		rigidbody2D.AddTorque(netTorque);
	}

	Vector2 convertFromVector3( Vector3 vector3){
		return new Vector2 (vector3.x, vector3.y);
	}

	public void setForceMultiplier(float fm){
		forceMultiplier=fm;
	}
}
