using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance;

	public static SoundManager getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<SoundManager>();
		}
		return _instance;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
