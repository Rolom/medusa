using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StageGameManager : MonoBehaviour {

	private static StageGameManager _instance;

	private float scenarioSpeed = -1.5f;
	public float SCENARIO_ACELERATION=0.35f;
	private static Vector2 scenarioSpeedVector;
	public Transform pointA;
	public Transform pointB;
	public GameObject jellyFish;
	private GameObject currentJellyFish;
	private List<GameObject> currentLevelList = new List<GameObject>();
	private int scenarioChangeCount;

	public List<GameObject> tutorialList = new List<GameObject>();
	public List<GameObject> level1List = new List<GameObject>();
	public List<GameObject> level2List = new List<GameObject>();
	public List<GameObject> level3List = new List<GameObject>();

	public List<int> scenarioChangeThresholds = new List<int>();
	private int scoreThresholdPosition = 0;
	public int planktonCount;

	private bool canCreateScenario;
	private bool canCreateStage;

	private bool onGameFlag=false;
	int randomScenario;
	GameObject currentStage;
	GameObject oldScenario;
	List<GameObject> stageLists = new List<GameObject>();
	private bool tutorialFlag=true;
	private int tutorialCount=0;

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
		setLevelList();
		createJellyFish();
	}

	public void setLevelList(){
		if(tutorialFlag){
			currentLevelList = tutorialList;
		}else{
			currentLevelList = level1List;
			randomScenario = Random.Range (0, currentLevelList.Count);
			scenarioChangeCount = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(canCreateStage){
			if (canCreateScenario && !tutorialFlag) 
			{
				updateScenarioLevel();
				scenarioSpeed-=SCENARIO_ACELERATION;
				setScenarioSpeed(scenarioSpeed);
				setScenarioSpeedToStages();
				createNewScenario ();
			}
			if(canCreateScenario && tutorialFlag){
				setScenarioSpeed(scenarioSpeed);
				createNewScenarioTutorial ();
			}
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
		randomScenario = Random.Range (0, currentLevelList.Count);
		currentStage = Instantiate (currentLevelList [randomScenario], pointA.localPosition, Quaternion.identity) as GameObject;
		BoxCollider2D collider = currentStage.GetComponent<BoxCollider2D> ();
		Vector3 newPosition = currentStage.transform.localPosition;
		newPosition.y += collider.size.y / 2;
		currentStage.transform.localPosition = newPosition;
		stageLists.Add(currentStage);
		setCanCreateScenario (false);
		scenarioChangeCount++;
	}

	void createNewScenarioTutorial ()
	{
		if(tutorialCount>=currentLevelList.Count){
			endTutorial();
		}else{
			currentStage = Instantiate (currentLevelList [tutorialCount], pointA.localPosition, Quaternion.identity) as GameObject;
			BoxCollider2D collider = currentStage.GetComponent<BoxCollider2D> ();
			Vector3 newPosition = currentStage.transform.localPosition;
			newPosition.y += collider.size.y / 2;
			currentStage.transform.localPosition = newPosition;
			stageLists.Add(currentStage);
			setCanCreateScenario (false);
			tutorialCount++;
		}

	}

	private void saveOldScenario(){
		if(currentStage!=null){
			oldScenario=currentStage;
		}
	}

	private void checkJellyFishTentacleState(){
		if(currentJellyFish!=null){
			if(!currentJellyFish.GetComponent<MedusaHealth>().getCompareOfTentacle()){
				resetJellyFish();
			}
		}
	}

	public void resetJellyFish(){
		if(currentJellyFish!=null){
			Destroy(currentJellyFish);
			createJellyFish();
		}else{
			createJellyFish();
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

	public void setCanCreateScenarioFromGui(bool canCreate)
	{
		this.canCreateScenario = canCreate;	
		checkJellyFishTentacleState();
		onGameFlag=true;
	}

	public void createJellyFish(){
		currentJellyFish = (GameObject)(Instantiate(jellyFish));
	}

	public void resetStage(){
		deleteOldScenario();
		resetJellyFish();
		Destroy(currentStage);
		canCreateScenario=false;
		resetScenarioSpeed();
		GUIManager.getInstance().onPlay.resetMyScore();
		ScoreManager.getInstance().resetScore();
		tutorialCount=0;
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
		if(!isMaxThreshold() && scenarioChangeThresholds[scoreThresholdPosition] <= scenarioChangeCount )
		{
			moveListToNextLevel();
		}

	}

	bool isMaxThreshold ()
	{
		if(scoreThresholdPosition > scenarioChangeThresholds.Count)
		{
			return true;
		}
		return false;
	}

	public bool getOnGameFlag(){
		return onGameFlag;
	}

	public void setOnGameFlag(bool flag){
		onGameFlag=false;
	}

	public void resetScenarioLevel()
	{
		scenarioChangeCount = 0;
		planktonCount = 0;
		tutorialFlag=true;
		tutorialCount=0;
		setLevelList();
		Debug.Log("Scenario reseted");
	}

	public bool getCanCreateStage(){
		return canCreateStage;
	}

	public void setCanCreateStage(bool cCS){
		canCreateStage=cCS;
	}

	public void endTutorial() {
		 tutorialFlag=false;
		 currentLevelList = level1List;
	}

	public bool TutorialFlag {
		get {
			return tutorialFlag;
		}
		set {
			tutorialFlag = value;
		}
	}
}
