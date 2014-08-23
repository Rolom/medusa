using UnityEngine;
using System.Collections;

public class ScenarioMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = StageGameManager.getInstance().getScenarioSpeed ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void setScenarioSpeed(Vector2 newSpeed)
	{
		rigidbody2D.velocity = newSpeed;
	}

}
