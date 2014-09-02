using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanktonDeathSFXImpl : SFXObject {

	public List<AudioSource> sounds;
	private int randomCount;
	// Use this for initialization
	void Start () {
		randomCount = Random.Range (0, sounds.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play()
	{
		sounds [randomCount].Play ();
		randomCount = Random.Range (0, sounds.Count);
	}

	public void stop()
	{
		sounds [randomCount].Stop ();
	}

	public void pause()
	{
		sounds [randomCount].Pause ();
	}
}
