using UnityEngine;
using System.Collections;

public class ProportionFontSize : MonoBehaviour {

	private static float sWidth=Screen.width;
	private static float sHeight=Screen.height;

	public static int PorcentageFontSize(int size){
		int fontSize=0;
		fontSize=(int)(sWidth*size)/100;
		return fontSize;
	}
}
