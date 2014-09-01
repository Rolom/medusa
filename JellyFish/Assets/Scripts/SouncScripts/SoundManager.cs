using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance;

	public RipleSFXImpl ripleSound;
	public JellyDeathSFXImpl jellyDeathSound;
	public WhaleSFXImpl whaleSound;

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

	public SFXObject RipleSound {
		get {
			return ripleSound;
		}
	}

	public JellyDeathSFXImpl JellyDeathSound {
		get {
			return jellyDeathSound;
		}
	}

	public WhaleSFXImpl WhaleSound {
		get {
			return whaleSound;
		}
	}
}
