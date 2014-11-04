using UnityEngine;
using System.Collections;

public class RipleEffect : MonoBehaviour {

	public GameObject riple;
	private int count=0;
	private float maxCountRiple=0;
	private int maxCountRange=20;
	private int minCountRange=10;
	private int numberOfRiples;
	private int minNumberOfRiples=2;
	private int maxNumberOfRiples=4;
	private int ripleCount=0;
	private Vector2 riplePosition;

	// Use this for initialization
	void Start () {
		numberOfRiples=Random.Range(minNumberOfRiples,maxNumberOfRiples);
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer ) {
			riplePosition=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		}else{
			riplePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	
	// Update is called once per frame
	void Update () {
		count++;
		if(count>maxCountRiple){
			count=0;
			ripleCount++;
			maxCountRiple=Random.Range(minCountRange,maxCountRange);
			riple.transform.position=riplePosition;
			Instantiate(riple);
		}

		if(ripleCount>numberOfRiples){
			Destroy(gameObject);
		}
	}
}
