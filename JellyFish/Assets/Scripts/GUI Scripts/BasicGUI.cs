using UnityEngine;
using System.Collections;

public class BasicGUI : MonoBehaviour {
	protected float alpha=0;
	protected float alphaDrow=0.02f;
	public GUISkin myGuiSkin;

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
