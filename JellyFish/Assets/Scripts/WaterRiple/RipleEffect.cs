using UnityEngine;
using System.Collections;

public class RipleEffect : MonoBehaviour {

	public GameObject riple;
	private int count=0;
	private float maxCountRiple=0;
	private int numberOfRiples;
	private int minNumberOfRiples=2;
	private int maxNumberOfRiples=5;
	private int ripleCount=0;
	private Vector3 riplePosition;

	// Use this for initialization
	void Start () {
	}

	public void setRiplePosition(Vector3 inputPosition){
		riplePosition=inputPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(ripleCount>=numberOfRiples){
			Destroy(gameObject);
		}
	}

	public void createRiples(Vector3 inputPosition){
		print (inputPosition);
		riplePosition=Camera.main.ScreenToWorldPoint(inputPosition);
		Vector3 riplePositionModify=new Vector3(riplePosition.x,riplePosition.y,-5);
		maxCountRiple=Random.Range(minNumberOfRiples,maxNumberOfRiples);
		while(count<maxCountRiple){
			count++;
			ripleCount++;
			riple.transform.position=(riplePositionModify);
			print (count+" count");
			if(count>1){
				Instantiate(riple);
			}else{
				Instantiate(riple);
				riple.GetComponent<OneRipleAnimation>().createFirst();
			}
		}
		count=0;
	}
}
