using UnityEngine;
using System.Collections;

public class WhaleSound : MonoBehaviour {

	public float soundDelay;
	private bool isPlaying = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(!isPlaying){
			SoundManager.getInstance().WhaleSound.playWithDelay(soundDelay);
			isPlaying = true;
		}
	
	}
}
