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
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) {
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
		}else{
			if (Input.GetKeyDown (KeyCode.Mouse0)  ) {
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
	
	}

	void playRipleSound ()
	{
		SoundManager.getInstance().RipleSound.play();
	}
}
