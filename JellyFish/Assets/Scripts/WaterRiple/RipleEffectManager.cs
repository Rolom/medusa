using UnityEngine;
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
			Debug.Log ("Entre");
			if(touchFlag==false){
				Instantiate(ripless);
				touchFlag=true;
				//playRipleSound();
			}
		}else{
			touchFlag=false;
		}
	
	}

	void playRipleSound ()
	{
		SoundManager.getInstance().RipleSound.play();
	}
}
