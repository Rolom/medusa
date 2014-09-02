using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RipleSFXImpl : SFXObject{

	public List<AudioSource> sounds;
	private int audioPosition = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void play()
	{
		if (audioPosition < sounds.Count) 
		{
			sounds [audioPosition].Play ();
			audioPosition++;
		} else
		{
			audioPosition = 0;
			sounds [audioPosition].Play ();
		}
	}

	public void stop()
	{
		sounds [audioPosition].Stop ();
	}

	public void pause()
	{
		sounds [audioPosition].Pause ();
	}
	
}
