using UnityEngine;
using System.Collections;

public class CurrentForce : MonoBehaviour {

	public int forceVector=1;
	public GameObject particles;
	public int forceDirection=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		particles.GetComponent<ParticleSystem>().startSize=forceVector*0.7f;
	}
	
	public void OnTriggerStay2D(Collider2D other){
		if(other.tag.Equals(Constants.JELLYFISH)){
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceVector*0.7f*forceDirection,0));
		}
	}
}
