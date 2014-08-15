using UnityEngine;
using System.Collections;

public class MedusaDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D  other){
		Debug.Log (other.gameObject.name);
			Application.LoadLevel(Application.loadedLevel);

	}
}
