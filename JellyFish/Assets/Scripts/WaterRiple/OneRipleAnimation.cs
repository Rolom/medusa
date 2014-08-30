using UnityEngine;
using System.Collections;

public class OneRipleAnimation : MonoBehaviour {

	private float scaleSize=0;
	private float ripleAlpha=0.4f;
	private float growSpeed=0.8f;
	private float alphaSpeed=0.3f;
	private Color ripleColor;

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale=new Vector2(0,0);
		ripleColor=gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
		scaleSize+=Time.deltaTime*growSpeed;
		gameObject.transform.localScale=new Vector2(scaleSize,scaleSize);
		ripleAlpha-=Time.deltaTime*alphaSpeed;
		ripleColor.a=ripleAlpha;
		gameObject.renderer.material.color=ripleColor;
		if(scaleSize>1.5f){
			Destroy(gameObject);
		}
	}
}
