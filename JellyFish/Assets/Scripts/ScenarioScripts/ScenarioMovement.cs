﻿using UnityEngine;
using System.Collections;

public class ScenarioMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = StageGameManager.getScenarioSpeed ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
