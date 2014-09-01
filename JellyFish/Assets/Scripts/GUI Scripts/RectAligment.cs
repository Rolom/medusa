using UnityEngine;
using System.Collections;

public class RectAligment : MonoBehaviour {

	private static float sWidth=Screen.width;
	private static float sHeight=Screen.height;

	public static Rect centerRect(float y,int w,int h){
		float pW=(sWidth*w)/100;
		float x=sWidth/2-pW/2;
		float pH=(sHeight*h)/100;
		float pY=(sHeight*y)/100;
		Rect myRect= new Rect(x,pY,pW,pH);
		
		return myRect;
	}

	public static Rect leftRect(float y,int w,int h){
		float pW=(sWidth*w)/100;
		float x=sWidth-pW;
		float pH=(sHeight*h)/100;
		float pY=(sHeight*y)/100;
		Rect myRect= new Rect(x,pY,pW,pH);
		
		return myRect;
	}

	public static Rect rigthRect(float y,int w,int h){
		float pW=(sWidth*w)/100;
		float x=0;
		float pH=(sHeight*h)/100;
		float pY=(sHeight*y)/100;
		Rect myRect= new Rect(x,pY,pW,pH);
		
		return myRect;
	}

}
