using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	static float LINEAR_VELOCITY = 20.0f;
	static float MAXIMUM_ROTATION_ANGLE = 60.0f;	//in degrees.

	Vector2 moveLeft;
	Vector2 moveRight;
	
	// Use this for initialization
	void Start () {
		moveLeft = new Vector2 (-1, 0);
		moveRight = new Vector2 (1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		removeVerticalVelocity ();

		if (Application.platform == RuntimePlatform.Android) {
			if (Input.touchCount > 0) {
				if(Input.GetTouch(0).phase == TouchPhase.Began) {
					AnimateCharacter (Input.GetTouch(0).position);
				}
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				print ("mouse key is held down");
				AnimateCharacter(Input.mousePosition);
			} else {
				//TODO agregar equilibrio de medusa.
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
	}

	void AnimateCharacter(Vector3 position) {
		Vector2 mouseVector = Camera.main.ScreenToWorldPoint(position);
		Vector2 characterVector = transform.position;
		Vector2 newDirection = characterVector - mouseVector;

		rigidbody2D.AddForce( moveLinearMedusa(newDirection) );

		rigidbody2D.AddTorque( addTorqueForMedusa(newDirection) );
		//rigidbody2D.AddTorque (0.75f);

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
		float vectorMagnitud = inverseVectorMagnitude(newDirection.magnitude);

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

	float inverseVectorMagnitude( float magnitude ){
		return 1 / Mathf.Pow (magnitude, 2) * LINEAR_VELOCITY;
	}

	float addTorqueForMedusa( Vector2 newDirection ){

		float torque = 1.0f * inverseVectorMagnitude(newDirection.magnitude);

		if (newDirection.x < 0) {
			// do nothing

		} else if (newDirection.x > 0) {
			//directionVector.Set(vectorMagnitud, 0);
			torque *= -1;

		} else {
			//directionVector.Set(0,0);
			torque *= 0;
		}

		print ("magnitud torque: " + torque);
		return torque;
	}

	void removeVerticalVelocity(){

		float Xaxisvelocity = rigidbody2D.velocity.x;
		Vector2 newLinearDirection = new Vector2 (Xaxisvelocity, 0);

		if (rigidbody2D.velocity.y != 0 || transform.position.y != 0) {
			print("Entered remove vertical velocity");
			float x = transform.position.x;
			transform.localPosition.Set(x, 0, 0);
		}
	}
}
