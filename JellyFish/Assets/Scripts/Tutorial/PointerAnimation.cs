using UnityEngine;
using System.Collections;

public class PointerAnimation : MonoBehaviour {



	private float pointerAlpha=0f;
	private float pointerAlphaSpeed=3f;
	private Color pointerColor;
	private bool destroyFlag=false;
	private float animMultiplier=1;


	// Use this for initialization
	void Start () {
		pointerColor=gameObject.renderer.material.color;
		pointerColor.a=0;
		gameObject.renderer.material.color=pointerColor;
	}
	
	// Update is called once per frame
	void Update () {
		pointerAlpha+=Time.deltaTime*(pointerAlphaSpeed*animMultiplier);
		pointerColor.a=pointerAlpha;
		gameObject.renderer.material.color=pointerColor;
		if(pointerAlpha>1f || pointerAlpha<0){
			animMultiplier*=-1;
		}

		if(destroyFlag && pointerAlpha<=0){
			Destroy(gameObject);
		}

	}

	public void destroyPointer(){
		destroyFlag=true;
	}
}