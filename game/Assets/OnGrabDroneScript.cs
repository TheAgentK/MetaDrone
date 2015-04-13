/************************************************************************************
 *  Copyright © 2014 Meta Company. All Rights Reserved. Use of this software source *
 *  code and binaries requires agreement and compliance with the META Licensed 		*
 *  Application End User License Agreement in the accompanying META EULA.txt file, 	*
 *  which must be included as part of this software for any use. 					*
 ************************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using Meta; 
using SocketIO;

public class OnGrabDroneScript : MonoBehaviour
{
	public Text textUpDown;
	public Text textForwardBackward;
	public Text textLeftRight;
	public Text textPosition;
	public Text textLocalPosition;

	public Transform reTransform;
	
	private float posDist = 0.1f;

	private bool isGrabed = false;

	public void OnStart () {
		GetComponent<Renderer>().material.color = Color.white;
	}

	// Update is called once per frame
	public void Update () {
		if(isGrabed == false) {
			transform.position = reTransform.position;
		}
	}

	public void OnHold()
	{
		Hand[] hands = Meta.Hands.GetHands();
		if (hands.Length > 0) {
			Hand right = Meta.Hands.right;
			if (right != null && right.isValid && right.gesture.type.Equals(MetaGesture.GRAB) ) {

				isGrabed = true;

				Vector3 position = Meta.Hands.right.palm.position;
				Vector3 localPosition = reTransform.position;
				
				float xPos = position.x;
				float yPos = position.y;
				float zPos = position.z;
				
				float xPosDist = localPosition.x;
				float yPosDist = localPosition.y;
				float zPosDist = localPosition.z;
				
				textLocalPosition.text = localPosition.x.ToString("F2") + " | " + localPosition.y.ToString("F2") + " | " + localPosition.z.ToString("F2");
				textPosition.text = xPos.ToString("F2") + " | " + yPos.ToString("F2") + " | " + zPos.ToString("F2");
				
				if( 
				   (xPos > (xPosDist + posDist) || xPos < (xPosDist - posDist)) || 
				   (yPos > (yPosDist + posDist) || yPos < (yPosDist - posDist)) ||
				   (zPos > (zPosDist + posDist) || zPos < (zPosDist - posDist))
				   ){
					
					if (xPos > (xPosDist + posDist) || xPos < (xPosDist - posDist)){
						GetComponent<Renderer>().material.color = Color.red;
						transform.position = new Vector3(xPos, localPosition.y, localPosition.z);
						
						if(xPos > (xPosDist + posDist)){
							// Drohne rechts
						} else if(xPos < (xPosDist - posDist)){
							// Drohne links
						}
					} else if (yPos > (yPosDist + posDist) || yPos < (yPosDist - posDist)){
						GetComponent<Renderer>().material.color = Color.yellow;
						transform.position = new Vector3(localPosition.x, yPos, localPosition.z);
						
						if(yPos > (yPosDist + posDist)){
							// Drohne hoch
						} else if(yPos < (yPosDist - posDist)){
							// Drohne runter
						}
					} else if (zPos > (zPosDist + posDist) || zPos < (zPosDist - posDist)){
						GetComponent<Renderer>().material.color = Color.green;
						transform.position = new Vector3(localPosition.x, localPosition.y, zPos);
						
						if(zPos > (zPosDist + posDist)){
							// Drohne zurück
						} else if(zPos < (zPosDist - posDist)){
							// Drohne vor
						}
					}
				} else {
					GetComponent<Renderer>().material.color = Color.white;
					transform.position = reTransform.position;
				}

			}
		}


	}

	public void OnRelease()
	{
		isGrabed = false;
		GetComponent<Renderer>().material.color = Color.cyan;
		transform.position = reTransform.position;
	}
}