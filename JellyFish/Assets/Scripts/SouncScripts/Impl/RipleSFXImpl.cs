using UnityEngine;
using System.Collections;

public class RipleSFXImpl : MonoBehaviour, SFXObject{

	public AudioSource audio;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region SFXObject implementation

	public void play ()
	{
		play (false);
	}

	public void play (bool newInstance)
	{
		if(newInstance)
		{
			audio.Play();
		}else
		{
			audio.Play();
		}
	}

	public void stop ()
	{
		audio.Stop();
	}

	public void pause ()
	{
		audio.Pause();
	}

	public void playWithDelay (float time)
	{
		throw new System.NotImplementedException ();
	}
	#endregion
}
