using UnityEngine;
using System.Collections;

public class LimitSideForce : MonoBehaviour {

	public int forceVector=1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerStay2D(Collider2D other){
		if(other.tag.Equals(Constants.JELLYFISH)){
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceVector*0.7f,0));
		}
	}
}
