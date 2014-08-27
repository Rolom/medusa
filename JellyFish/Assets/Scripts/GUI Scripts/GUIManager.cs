using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	private static GUIManager _instance;

	public Main_Menu mainMenu;
	public OnPlay onPlay;
	public EndMenu endMenu;
	public PauseMenu pauseMenu;


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
		Time.timeScale=1;
		mainMenu.gameObject.SetActive(true);
	}
	
	public void showOnGame(){
		deactivateMenus();
		Time.timeScale=1;
		onPlay.gameObject.SetActive(true);
		StageGameManager.getInstance().setCanCreateScenario(true);
	}

	public void showEndGame(){
		deactivateMenus();
		endMenu.gameObject.SetActive(true);
	}

	public void replayGame(){
		StageGameManager.getInstance().resetStage();
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

	public void closeApp(){
		Application.Quit();
	}

	private void deactivateMenus(){
		mainMenu.gameObject.SetActive(false);
		onPlay.gameObject.SetActive(false);
		endMenu.gameObject.SetActive(false);
		pauseMenu.gameObject.SetActive(false);
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
