using UnityEngine;
using System.Collections;

public class CurrentForce : MonoBehaviour {

	public float forceVector=1;
	public GameObject particles;
	public int forceDirection=1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		particles.GetComponent<ParticleSystem>().startLifetime=(0.7f*10)/forceVector;
		particles.GetComponent<ParticleSystem>().startSpeed=(forceVector*0.7f)*3;
	}
	
	public void OnTriggerStay2D(Collider2D other){
		if(other.tag.Equals(Constants.JELLYFISH)){
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2(forceVector*0.7f*forceDirection,0));
		}
	}
}
