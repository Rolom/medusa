using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	private static GUIManager _instance;

	public Main_Menu mainMenu;
	public OnPlay onPlay;
	public EndMenu endMenu;
	public PauseMenu pauseMenu;
	public OptionsMenu optionsMenu;
	public SugarLayer sugarLayer;
	public CreditsMenu creditMenu;
	private bool sugarLayerFlag=false;


	public void Update(){
		showSugaLayer();
	}

	public void showSugaLayer(){
		if(Persistence.getInstance().getHighscore()==0){
			sugarLayerFlag=true;
		}
		if(Persistence.getInstance().isHighscore(ScoreManager.getInstance().getScore()) && !sugarLayerFlag){
			sugarLayer.gameObject.SetActive(true);
			sugarLayerFlag=true;

			SoundManager.getInstance().HighScoreSound.play();
		}
	}

	public static GUIManager getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<GUIManager>();
		}
		return _instance;
	}

	public void showMainMenu(){
		deactivateMenus();
		StageGameManager.getInstance().resetStage();
		resetFlags();
		Time.timeScale=1;
		mainMenu.gameObject.SetActive(true);
		StageGameManager.getInstance().resetJellyFish();
		StageGameManager.getInstance().setOnGameFlag(false);
	}
	
	public void showOnGame(){
		deactivateMenus();
		Time.timeScale=1;
		onPlay.gameObject.SetActive(true);
		StageGameManager.getInstance().setCanCreateScenarioFromGui(true);
	}

	public void showEndGame(){
		deactivateMenus();
		resetFlags();
		endMenu.gameObject.SetActive(true);
	}

	public void replayGame(){
		StageGameManager.getInstance().resetStage();
		resetFlags();
		showOnGame();
	}

	public void showPause(){
		deactivateMenus();
		if(Time.timeScale==1){
			Time.timeScale=0;
			pauseMenu.gameObject.SetActive(true);
		}else{
			Time.timeScale=1;
			deactivateMenus();
			onPlay.gameObject.SetActive(true);
		}
	}

	public void showOptions(){
		deactivateMenus();
		optionsMenu.gameObject.SetActive(true);
	}

	public void closeApp(){
		Application.Quit();
	}

	public void showCreditMenu(){
		deactivateMenus();
		creditMenu.gameObject.SetActive(true);
	}

	private void deactivateMenus(){
		mainMenu.gameObject.SetActive(false);
		onPlay.gameObject.SetActive(false);
		endMenu.gameObject.SetActive(false);
		pauseMenu.gameObject.SetActive(false);
		optionsMenu.gameObject.SetActive(false);
		sugarLayer.gameObject.SetActive(false);
		creditMenu.gameObject.SetActive(false);
	}

	public void resetFlags(){
		sugarLayerFlag=false;
	}

	public Main_Menu getMainMenu()
	{
		return mainMenu;
	}

	public OnPlay getOnPlay()
	{
		return onPlay;
	}

}
