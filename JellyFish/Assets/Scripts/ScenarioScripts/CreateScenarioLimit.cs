using UnityEngine;
using System.Collections;

public class CreateScenarioLimit : MonoBehaviour {

	//public StageGameManager stageGameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D other) {
		
		if(other.gameObject.tag.Equals(Constants.STAGE_TAG))
		{
			//stageGameManager.setCanCreateScenario(true);
			StageGameManager.getInstance().setCanCreateScenario(true);
		}
		else if(other.gameObject.tag.Equals(Constants.PLANK))
		{
			Debug.Log ("Getting BH Script");
			BehaviourPlanck bhPlanck = other.GetComponent<BehaviourPlanck>();
			bhPlanck.setId(StageGameManager.getInstance ().planktonCount ++);
		}
	}
}
