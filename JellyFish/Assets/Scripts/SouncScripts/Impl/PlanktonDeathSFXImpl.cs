using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanktonDeathSFXImpl : SFXObject {

	public List<AudioSource> sounds;
	private int count = 0;
	private int nextPlankton;
	// Use this for initialization
	void Start () {
		//count = Random.Range (0, sounds.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(BehaviourPlanck plankton)
	{
		int id = plankton.id;
		if (id != nextPlankton) {
			count = 0;
			print ("miss");
		}
		if (count >= sounds.Count) {
			count = 0;
		}
		sounds [count].Play ();
		if (count == 14) {
			plankton.playPlanktonAchivment();
		}
		count++;
		nextPlankton = id + 1;
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
