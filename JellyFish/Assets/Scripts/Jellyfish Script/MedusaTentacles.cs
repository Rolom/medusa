using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedusaTentacles : MonoBehaviour{
	
	private Color c1;
	private Color c2;
	private bool activeFlag=false;
	private LineRenderer lineRenderer;

	private List<Transform> nodeList= new List<Transform>();
	private float distance=1000;
	private int count=0;
	private Vector3 distort;

	
	void Start() {
		c1=getRandomColor();
		c2=getRandomColor();
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.SetWidth(Random.Range(0.06f,0.10F), 0.0F);
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		c1.a=0.3f;
		c2.a=1f;
		lineRenderer.SetColors(c1, c2);
		foreach(Transform child in this.transform){
			nodeList.Add(child);
		}
		lineRenderer.SetVertexCount(nodeList.Count);
	}

	void Update() {
		drawLine();
	}

	private void drawLine(){
		if(nodeList.Count!=0){
			count++;
			lineRenderer=GetComponent<LineRenderer>();
			for(int i=0;i<nodeList.Count;i++){
				lineRenderer.SetPosition(i, nodeList[i].position);
			}
			
			GetComponent<LineRenderer>().enabled=true;
		}else{
			GetComponent<LineRenderer>().enabled=false;
			Debug.Log("List Empty");
		}
	}
		
	private Vector4 getRandomColor(){
		Color randomColor = new Vector4(Random.Range(0f,1F), 0, Random.Range(0.3f,1F), 1);
		return randomColor;
	}
}