using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Vector2 moveLeft;
	Vector2 moveRight;
	
	// Use this for initialization
	void Start () {
		moveLeft = new Vector2 (-1, 0);
		moveRight = new Vector2 (1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
						//print ("a key is held down");
						rigidbody2D.AddForce (moveLeft);
						transform.Rotate (Vector3.forward);
				} else if (Input.GetKey (KeyCode.D)) {
						//print ("k key is held down");
						rigidbody2D.AddForce (moveRight);
						transform.Rotate (Vector3.back);
				} else {
						rigidbody2D.AddForce (new Vector2 (0, 0));
				}

	}


	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("HOli");
		Destroy (gameObject);
	}
}
