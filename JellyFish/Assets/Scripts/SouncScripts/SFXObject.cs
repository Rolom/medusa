using UnityEngine;
using System.Collections;

public abstract class SFXObject : MonoBehaviour {

	public AudioSource audio;

	void Start () {
		
	}

	void Update () {

	}

	public void play()
	{
		play (false);
	}

	public void play(bool newInstance)
	{
		if(newInstance)
		{
			audio.Play();
		}else
		{
			audio.Play();
		}
	}

	public void playWithDelay(float time)
	{
		audio.PlayDelayed(time);
	}

	public void stop()
	{
		audio.Stop();
	}

	public void pause()
	{
		audio.Pause();
	}


	
}
