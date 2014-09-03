using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanktonDeathSFXImpl : SFXObject {

	public List<AudioSource> sounds;
	private int count = 0;
	// Use this for initialization
	void Start () {
		//count = Random.Range (0, sounds.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play()
	{
		if (count >= sounds.Count) {
			count = 0;
		}
		sounds [count].Play ();
		count++;
	}

	public void stop()
	{
		sounds [count].Stop ();
	}

	public void pause()
	{
		sounds [count].Pause ();
	}
}
