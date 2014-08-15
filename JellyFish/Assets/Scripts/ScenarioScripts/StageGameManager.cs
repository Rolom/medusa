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
		scenarioSpeedVector = new Vector2 (0, scenarioSpeed);
		randomScenario = Random.Range (0, stageObjects.Count);
	}
	
	// Update is called once per frame
	void Update () {

		if (canCreateScenario) 
		{
			currentStage = Instantiate(stageObjects[randomScenario],pointA.localPosition, Quaternion.identity) as GameObject;
			randomScenario = Random.Range (0, stageObjects.Count);
			setCanCreateScenario(false);
			scenarioSpeed+=0.4f;
		}
	}

	public static Vector2 getScenarioSpeed()
	{
		return scenarioSpeedVector;
	}

	public void setCanCreateScenario(bool canCreate)
	{
		this.canCreateScenario = canCreate;	
	}

}
