using UnityEngine;
using System.Collections;

public class StageObjectsLimits : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D other) {

		if(other.gameObject.tag.Equals(Constants.STAGE_TAG))
		{
			Destroy (other.gameObject);
		}else if(other.gameObject.tag.Equals(Constants.PLANK)){
			MedusaHealth medusaHealth = GameObject.FindObjectOfType<MedusaHealth>();
			if(medusaHealth != null)
			{
				medusaHealth.detachTentacle();
			}
			Destroy (other.gameObject);
		}
	}
}
