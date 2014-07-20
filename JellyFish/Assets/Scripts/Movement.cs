using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.AddForce (new Vector2 (-1, 0));
	}


	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log("HOli");
		Destroy (gameObject);
	}
}
