using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageGameManager : MonoBehaviour {

	public float scenarioSpeed = -0.9f;
	private static Vector2 scenarioSpeedVector;
	public Transform pointA;
	public Transform pointB;
	public List<GameObject> stageObjects = new List<GameObject>();
	private bool canCreateScenario;
	
	int randomScenario;
	GameObject currentStage;


	void Start () {
		canCreateScenario = true;
		setScenarioSpeed(scenarioSpeed);
		randomScenario = Random.Range (0, stageObjects.Count);
	}
	
	// Update is called once per frame
	void Update () {

		if (canCreateScenario) 
		{
			scenarioSpeed-=0.2f;
			setScenarioSpeed(scenarioSpeed);
			currentStage = Instantiate(stageObjects[randomScenario],pointA.localPosition, Quaternion.identity) as GameObject;
			randomScenario = Random.Range (0, stageObjects.Count);
			setCanCreateScenario(false);
		}
	}

	public static Vector2 getScenarioSpeed()
	{
		return scenarioSpeedVector;
	}

	public void setScenarioSpeed(float speed){
		scenarioSpeedVector = new Vector2 (0, speed);
	}

	public void setCanCreateScenario(bool canCreate)
	{
		this.canCreateScenario = canCreate;	
	}

}
