using UnityEngine;
using System.Collections;

public class OneRipleAnimation : MonoBehaviour {

	private float scaleSize=0;
	private float ripleAlpha=0.4f;
	private float growSpeed=0.8f;
	private float alphaSpeed=0.3f;
	private Color ripleColor;
	private int delay =0;
	private int delayMin=5;
	private int delayMax=50;
	private int delayCount=0;
	private float maxScaleSize=1.5f;

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale=new Vector2(0,0);
		ripleColor=gameObject.renderer.material.color;
		delay=Random.Range(delayMin,delayMax);
	}
	
	// Update is called once per frame
	void Update () {
		if(delayCount>delay){
		scaleSize+=Time.deltaTime*growSpeed;
		gameObject.transform.localScale=new Vector2(scaleSize,scaleSize);
		ripleAlpha-=Time.deltaTime*alphaSpeed;
		ripleColor.a=ripleAlpha;
		gameObject.renderer.material.color=ripleColor;
		if(scaleSize>maxScaleSize){
			Destroy(gameObject);
		}
		}else{
			delayCount++;
		}
	}

	public void createFirst(){
		delayCount=delay;
	}
}
