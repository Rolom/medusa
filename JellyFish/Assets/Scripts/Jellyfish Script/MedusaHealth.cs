using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedusaHealth : MonoBehaviour {

	private List<Transform> tentacleList= new List<Transform>();
	private DistanceJoint2D sTentacle;
	private Rigidbody2D rTentacle;

	// Use this for initialization
	void Start () {
		foreach(Transform child in this.transform){
			tentacleList.Add(child);
		}
	}
	
	// Update is called once per frame
	void Update () {
		calculateLoose();
	}

	void OnCollisionEnter2D(Collision2D  other){
		print(other.gameObject.tag);
		detachTentacle();
		Application.LoadLevel(Application.loadedLevel);
	}

	void calculateLoose(){
		if(tentacleList.Count==0){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void detachTentacle(){
		Transform selectedTentacle=tentacleList[Random.Range(0,tentacleList.Count)];
		sTentacle=selectedTentacle.GetComponent<DistanceJoint2D>();
		sTentacle.enabled=false;

		rTentacle=selectedTentacle.GetComponent<Rigidbody2D>();
		rTentacle.mass=1;
		rTentacle.gravityScale=2;
		tentacleList.Remove(selectedTentacle);
	}
}
