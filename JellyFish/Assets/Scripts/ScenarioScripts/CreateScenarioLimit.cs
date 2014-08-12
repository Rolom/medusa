using UnityEngine;
using System.Collections;

public class CreateScenarioLimit : MonoBehaviour {

	public StageGameManager stageGameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D other) {
		
		if(other.gameObject.tag.Equals(Constants.STAGE_TAG))
		{
			stageGameManager.setCanCreateScenario(true);
		}
	}
}
