using UnityEngine;
using Meta;
using System.Collections;

public class HandTrackingVektor : MonoBehaviour {

	public Transform positionPalm;
	public Transform positionFinger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Hand hand = Meta.Hands.right;

		positionPalm.rotation = hand.pointer.orientation;
		positionPalm.position = hand.palm.position;

		positionFinger.position = hand.pointer.position;
	
	}
}
