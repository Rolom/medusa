using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MedusaAnimation : MonoBehaviour {

	private float count=0f;
	private int frame=0;
	private float count2=0;
	public List<Sprite> sprites;
	private List<Transform> tentacleList= new List<Transform>();
	private bool movementFlag=true;
	private int STATIC_FRAME=1;
	private int pingPongAnimationMultiplier=1;
	private int pingPongFrame=0;
	private int pingPongCounter=0;
	private bool damageFlag=false;
	private float colorCount=0;
	private float colorNum=0;
	private int colorChangeCount=0;
	private int MAX_COLOR_DAMAGE_COUNT=100;
	private Color color;

	// Use this for initialization
	void Start () {
		tentacleList=gameObject.GetComponent<MedusaHealth>().getTentacleList();
	}
	
	// Update is called once per frame
	void Update () {
		if(movementFlag){
			movementAnimation();
		}else{
			//staticAnimation();
			gameObject.GetComponent<SpriteRenderer>().sprite=sprites[STATIC_FRAME];
		}
		if(damageFlag){
			damageAnimation();
		}
	}

	private void movementAnimation(){
		count+=10f*Time.deltaTime;
		count2+=25*Time.deltaTime;

		for(int i=0;i<tentacleList.Count;i++){
			float conectedAnchor=tentacleList[i].GetComponent<DistanceJoint2D>().connectedAnchor.x;
			Vector2 newConectedAnchorX=new Vector2(((Mathf.Sin(count)/25)),0);
			Vector2 newConectedAnchorY=new Vector2(0,((Mathf.Sin(count)/20)));
			if(conectedAnchor>0){
				tentacleList[i].GetComponent<DistanceJoint2D>().connectedAnchor+=newConectedAnchorX;
			}
			if(conectedAnchor<0){
				tentacleList[i].GetComponent<DistanceJoint2D>().connectedAnchor-=newConectedAnchorX;
			}
			tentacleList[i].GetComponent<DistanceJoint2D>().connectedAnchor-=newConectedAnchorY;
		}
		
		if(count2>=1){
			count2=0;
			frame++;
			if(frame>=sprites.Count){
				frame=0;
			}
			if(frame==STATIC_FRAME){
				frame=STATIC_FRAME;
				movementFlag=false;
			}
			gameObject.GetComponent<SpriteRenderer>().sprite=sprites[frame];
		}
		
		
	}

	private void staticAnimation(){
		count2+=2*Time.deltaTime;

		if(count2>=1){
			count2=0;
			pingPongCounter++;
			if(pingPongCounter>pingPongFrame){
				pingPongCounter=0;
				pingPongAnimationMultiplier*=-1;
			}
			frame+=1*pingPongAnimationMultiplier;

			if(frame>=sprites.Count ){
				frame=0;
			}else{
				if(frame<0){
					frame=sprites.Count-1;
				}
			}
			gameObject.GetComponent<SpriteRenderer>().sprite=sprites[frame];
		}
	}

	private void damageAnimation(){
		colorCount+=20f*Time.deltaTime;
		colorNum=Mathf.Abs(Mathf.Sin(colorCount))+0.3f;
		print (colorNum);
		color=new Color(1f,colorNum,colorNum,1f);
		gameObject.renderer.material.color=color;
		colorChangeCount++;
		if(colorChangeCount>MAX_COLOR_DAMAGE_COUNT){
			damageFlag=false;
			colorChangeCount=0;
			color=new Color(1f,1f,1f,1f);
			gameObject.renderer.material.color=color;
		}
	}

	public void setMovementFlag(bool mf){
		movementFlag=mf;
	}

	public void setDamageFlag(bool df){
		damageFlag=df;
	}
}
