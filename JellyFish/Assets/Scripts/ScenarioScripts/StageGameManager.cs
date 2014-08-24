using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageGameManager : MonoBehaviour {

	private static StageGameManager _instance;

	public float scenarioSpeed = -0.9f;
	private static Vector2 scenarioSpeedVector;
	public Transform pointA;
	public Transform pointB;
	public List<GameObject> stageObjects = new List<GameObject>();
	private bool canCreateScenario;
	
	int randomScenario;
	GameObject currentStage;
	List<GameObject> stageLists = new List<GameObject>();

	public static StageGameManager getInstance()
	{
		if (_instance == null) 
		{
			_instance = GameObject.FindObjectOfType<StageGameManager> ();
		}
		return _instance;
	}

	void Start () {
		canCreateScenario = false;
		setScenarioSpeed(scenarioSpeed);
		randomScenario = Random.Range (0, stageObjects.Count);
	}
	
	// Update is called once per frame
	void Update () {

		if (canCreateScenario) 
		{
			scenarioSpeed-=0.4f;
			setScenarioSpeed(scenarioSpeed);
			setScenarioSpeedToStages();
			createNewScenario ();
		}
	}

	public Vector2 getScenarioSpeed()
	{
		return scenarioSpeedVector;
	}

	public void setScenarioSpeed(float speed){
		scenarioSpeedVector = new Vector2 (0, speed);
	}

	void createNewScenario ()
	{
		currentStage = Instantiate (stageObjects [randomScenario], pointA.localPosition, Quaternion.identity) as GameObject;
		BoxCollider2D collider = currentStage.GetComponent<BoxCollider2D> ();
		Vector3 newPosition = currentStage.transform.localPosition;
		newPosition.y += collider.size.y / 2;
		currentStage.transform.localPosition = newPosition;
		randomScenario = Random.Range (0, stageObjects.Count);
		stageLists.Add(currentStage);
		setCanCreateScenario (false);
	}

	void setScenarioSpeedToStages ()
	{
		foreach(GameObject stage in stageLists.ToArray())
		{
			if(stage != null)
			{
				ScenarioMovement scenarioMovement = stage.GetComponent<ScenarioMovement>();
				scenarioMovement.setScenarioSpeed(getScenarioSpeed());
			}else
			{
				stageLists.Remove(stage);
			}
		}
	}

	public void setCanCreateScenario(bool canCreate)
	{
		this.canCreateScenario = canCreate;	
	}

	public void resetStage(){
		Destroy(currentStage);
		canCreateScenario=false;
		scenarioSpeed = -0.9f;
	}

}
