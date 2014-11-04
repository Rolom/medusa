using UnityEngine;
using System.Collections;

public class PointerAnimation : MonoBehaviour {



	private float pointerAlpha=1f;
	private float pointerAlphaSpeed=0.7f;
	private Color pointerColor;


	// Use this for initialization
	void Start () {
		pointerColor=gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		pointerAlpha-=Time.deltaTime*pointerAlphaSpeed;
		pointerColor.a=pointerAlpha;
		gameObject.renderer.material.color=pointerColor;
		if(pointerAlpha<0f){
			Destroy(gameObject);
		}
	}
}