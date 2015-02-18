using UnityEngine;
using System.Collections;

public class RipleEffectManager : MonoBehaviour {

	private static RipleEffectManager _instance;
	public GameObject ripless;
	private bool touchFlag=false;
	private Vector3 riplePosition;

	// Use this for initialization
	public static RipleEffectManager getInstance()
	{
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<RipleEffectManager>();
		}
		return _instance;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) {
		if (Input.touchCount > 0) {
			if(touchFlag==false){
				makeRiple(Input.touches[0].position);
				touchFlag=true;
				//playRipleSound();
			}
		}else{
			touchFlag=false;
		}
		}else{
			if (Input.GetKeyDown (KeyCode.Mouse0)  ) {
				//Debug.Log ("Entre");
				if(touchFlag==false){
					makeRiple(Input.mousePosition);
					touchFlag=true;
					//playRipleSound();
				}
			}else{
				touchFlag=false;
			}
		}
	
	}

	public void makeRiple(Vector3 riplepos){
		ripless.GetComponent<RipleEffect>().createRiples(riplepos);
		Instantiate(ripless);
	}

	
	public Vector3 RiplePosition{
		get{return riplePosition;}
		set{ riplePosition=value;}
	}

	void playRipleSound ()
	{
		SoundManager.getInstance().RipleSound.play();
	}
}
