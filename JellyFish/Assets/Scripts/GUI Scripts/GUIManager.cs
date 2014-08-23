using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

	private static GUIManager _instance;

	public Main_Menu mainMenu;
	public OnPlay onPlay;


	public static GUIManager getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<GUIManager>();
		}
		return _instance;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
