using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GameObject pointer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		print(other.tag);
		if(other.tag!="Stage" && other.tag!="Limits" && other.tag!="Untagged"){
			if(other.tag=="Plank"){
				pointer.transform.position=new Vector3(-1f*other.transform.position.x,gameObject.transform.parent.transform.position.y,0);
			}
			if(other.tag=="Rock"){
				pointer.transform.position=new Vector3(other.transform.position.x,gameObject.transform.parent.transform.position.y,0);
			}
			Instantiate(pointer);
		}
	}
}
