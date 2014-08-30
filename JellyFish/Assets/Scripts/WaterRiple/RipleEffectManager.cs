﻿using UnityEngine;
using System.Collections;

public class RipleEffectManager : MonoBehaviour {

	public GameObject ripless;
	private bool touchFlag=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			if(touchFlag==false){
				Instantiate(ripless);
				touchFlag=true;
			}
		}else{
			touchFlag=false;
		}
	
	}
}