using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedusaTentacles : MonoBehaviour{
	private Color c1 = Color.magenta;
	private Color c2 = Color.white;
	private bool activeFlag=false;
	private LineRenderer lineRenderer;

	private List<Transform> blockList= new List<Transform>();
	private float distance=1000;
	private int count=0;
	private Vector3 distort;

	
	void Start() {
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.SetWidth(0.1F, 0.0F);
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		c1.a=0.3f;
		c2.a=0.1f;
		lineRenderer.SetColors(c1, c2);
		foreach(Transform child in this.transform){
			blockList.Add(child);
		}
		lineRenderer.SetVertexCount(blockList.Count);
	}

	void Update() {
		if(blockList.Count!=0){
			count++;
			lineRenderer=GetComponent<LineRenderer>();
			for(int i=0;i<blockList.Count;i++){
				lineRenderer.SetPosition(i, blockList[i].position);
			}

			GetComponent<LineRenderer>().enabled=true;
		}else{
			GetComponent<LineRenderer>().enabled=false;
			Debug.Log("List Empty");
		}
	}
}