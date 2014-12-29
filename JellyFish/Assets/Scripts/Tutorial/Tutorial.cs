using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour
{

		public GameObject pointer;
		public bool pointerFlag;
		private List<GameObject> plancktonList = new List<GameObject> ();
		private List<GameObject> rockList = new List<GameObject> ();
		private float maxDistanceConstant = 1f;
		private float distance;
		private const float MEDUSWIDHT = 0.8f;
		private GameObject closerPlanck;
		private float pointerInstanceDistance = 5;
		private float pointerMaxDistance = 2;
		private GameObject pointerObj = null;
		
		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
			if(StageGameManager.getInstance().TutorialFlag){
					showPointer ();
			}else{
				if(pointerObj!=null){
					Destroy(pointerObj);
					gameObject.SetActive(false);
				}
			}
		}

		private void showPointer ()
		{
				Vector3 jellyPosition = gameObject.transform.parent.gameObject.transform.position;
				GameObject selectPlanckt = null;

				float selectPlankHorizontalDist = 0;
				float selectPlankVerticalDist = 0;

				for (int plankNum = 0; plankNum < plancktonList.Count; plankNum++) {
						GameObject planktom = plancktonList [plankNum];

						if (planktom == null) {
								plancktonList.RemoveRange (plankNum, 1);
								plankNum--;
						}

						if (planktom != null && planktom.transform.position.y < jellyPosition.y) {
								plancktonList.Remove (planktom);
								plankNum--;
						} else {
								if (planktom != null) {
										float plankHorizontalDist = Mathf.Abs (planktom.transform.position.x - jellyPosition.x);
										if (selectPlanckt == null && plankHorizontalDist > MEDUSWIDHT) {		
												if (pointerFlag == false) {
														pointerObj = Instantiate (pointer) as GameObject;
														pointerFlag = true;
												}
												selectPlanckt = plancktonList [0];
												selectPlankHorizontalDist = Mathf.Abs (selectPlanckt.transform.position.x - jellyPosition.x);
												selectPlankVerticalDist = (selectPlanckt.transform.position.y - jellyPosition.y);
										}

										if (selectPlankHorizontalDist <= MEDUSWIDHT && pointerObj != null) {
												pointerObj.GetComponent<PointerAnimation> ().destroyPointer ();

										}

										if (pointerObj == null) {
												pointerFlag = false;
										}

										if (selectPlankVerticalDist < 0) {
												plancktonList.Remove (planktom);
												selectPlanckt = null;
										}
								}
						}
				}

				if (plancktonList.Count == 0) {
						if (pointerObj != null) {
								pointerObj.GetComponent<PointerAnimation> ().destroyPointer ();
								pointerFlag = false;
						}
		
				}
				if (pointerObj != null && selectPlanckt != null) {
						pointerObj.transform.position = calculatePointerPosition (gameObject.transform.parent.gameObject, selectPlanckt);
						print (calculatePointerPosition (gameObject.transform.parent.gameObject, selectPlanckt) + " Distance");
				}

		}

		private Vector3 calculatePointerPosition (GameObject obj1, GameObject obj2)
		{
				distance = (obj1.transform.position.x - obj2.transform.position.x);
				float pointerDistance;
				if (distance > 0) {
						pointerDistance = (obj1.transform.position.x) + ((maxDistanceConstant / distance) + MEDUSWIDHT);
						if (pointerDistance > pointerMaxDistance) {
								pointerDistance = pointerMaxDistance;
						}
				} else {
						pointerDistance = (obj1.transform.position.x) + ((maxDistanceConstant / distance) - MEDUSWIDHT);
						if (pointerDistance < pointerMaxDistance * -1) {
								pointerDistance = pointerMaxDistance * -1;
						}
				}

				return new Vector3 (pointerDistance, obj1.transform.position.y, -5);
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag != "Stage" && other.tag != "Limits" && other.tag != "Untagged") {
						if (other.tag == "Plank") {
								plancktonList.Add (other.transform.gameObject);
						}
						if (other.tag == "Rock") {
								rockList.Add (other.gameObject);
						}
				}
		}

		void OnTriggerExit2D (Collider2D other)
		{
				if (other.tag == "Plank") {
						plancktonList.Remove (other.gameObject);
				}
				if (other.tag == "Rock") {
						rockList.Remove (other.gameObject);
				}
		}
}
