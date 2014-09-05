﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageGameManager : MonoBehaviour {

	private static StageGameManager _instance;

	public float scenarioSpeed = -0.9f;
	private static Vector2 scenarioSpeedVector;
	public Transform pointA;
	public Transform pointB;
	public GameObject jellyFish;
	private GameObject currentJellyFish;
	private List<GameObject> currentLevelList = new List<GameObject>();
	private int scenarioChangeCount;
	
	public List<GameObject> level1List = new List<GameObject>();
	public List<GameObject> level2List = new List<GameObject>();
	public List<GameObject> level3List = new List<GameObject>();

	public List<int> scoreThreshold = new List<int>();
	private int scoreThresholdPosition = 0;

	private bool canCreateScenario;
	
	int randomScenario;
	GameObject currentStage;
	GameObject oldScenario;
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
		randomScenario = Random.Range (0, currentLevelList.Count);
		currentLevelList = level1List;
		createJellyFish();
		scenarioChangeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (canCreateScenario) 
		{
			updateScenarioLevel();
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
		saveOldScenario();
		currentStage = Instantiate (currentLevelList [randomScenario], pointA.localPosition, Quaternion.identity) as GameObject;
		BoxCollider2D collider = currentStage.GetComponent<BoxCollider2D> ();
		Vector3 newPosition = currentStage.transform.localPosition;
		newPosition.y += collider.size.y / 2;
		currentStage.transform.localPosition = newPosition;
		randomScenario = Random.Range (0, currentLevelList.Count);
		stageLists.Add(currentStage);
		setCanCreateScenario (false);
		scenarioChangeCount++;
	}

	private void saveOldScenario(){
		if(currentStage!=null){
			oldScenario=currentStage;
		}
	}

	private void deleteOldScenario(){
		if(oldScenario!=null){
			Destroy(oldScenario);
		}
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

	public void createJellyFish(){
		currentJellyFish = (GameObject)(Instantiate(jellyFish));
	}

	public void resetStage(){
		deleteOldScenario();
		Destroy(currentJellyFish);
		createJellyFish();
		Destroy(currentStage);
		canCreateScenario=false;
		resetScenarioSpeed();
		GUIManager.getInstance().onPlay.resetMyScore();
		ScoreManager.getInstance().resetScore();
	}

	private void resetScenarioSpeed(){
		scenarioSpeed = -0.9f;
	}

	public void changeScenariosSpeed(float changedSpeed){
		if(currentStage !=null){
			currentStage.GetComponent<ScenarioMovement>().setScenarioSpeed(new Vector2(0,scenarioSpeed-changedSpeed));
		}
		if(oldScenario !=null){
			oldScenario.GetComponent<ScenarioMovement>().setScenarioSpeed(new Vector2(0,scenarioSpeed-changedSpeed));
		}
	}

	public void moveListToNextLevel()
	{
		if(currentLevelList == level1List)
		{
			currentLevelList = level2List;
			scenarioChangeCount = 0;
			Debug.Log("Cambie de Lista a 2");
		}else if(currentLevelList == level2List)
		{
			currentLevelList = level3List;
			scenarioChangeCount = 0;
			Debug.Log("Cambie de Lista a 3");
		}
	}

	void updateScenarioLevel ()
	{
		if(!isMaxThreshold() && scoreThreshold[scoreThresholdPosition] <= scenarioChangeCount )
		{
			moveListToNextLevel();
		}

	}

	bool isMaxThreshold ()
	{
		if(scoreThresholdPosition > scoreThreshold.Count)
		{
			return true;
		}
		return false;
	}
}
