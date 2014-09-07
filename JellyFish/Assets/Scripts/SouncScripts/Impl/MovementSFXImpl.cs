using UnityEngine;
using System.Collections;

public class MovementSFXImpl : SFXObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(float volume)
	{
		if(!audio.isPlaying)
		{
			audio.volume = volume;
			audio.Play();
		}
	}

}
