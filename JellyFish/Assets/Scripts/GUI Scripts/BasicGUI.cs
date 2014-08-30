using UnityEngine;
using System.Collections;

public class BasicGUI : MonoBehaviour {
	public float alpha=0;
	private float alphaDrow=0.02f;

	// Update is called once per frame
	void Update () {
		if(alpha<1){
			alpha+=alphaDrow;
		}
	}

	public void OnDisable(){
		alpha=0;
	}

	public Color changeAlphaGui ( Color myGUIColor) {
		Color myColor =myGUIColor;
		myColor.a=alpha;
		return myColor;
	}
}
