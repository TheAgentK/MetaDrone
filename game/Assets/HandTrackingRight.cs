using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class HandTrackingRight : MonoBehaviour {

	private HandTracking tracking = new HandTracking();

	public MeshRenderer arrowRotateLeft;
	public MeshRenderer arrowRotateRight;
	public MeshRenderer arrowUp;
	public MeshRenderer arrowDown;
	public MeshRenderer arrowCenter;

	public Text centerVector;
	public Text palmVector;

	public Transform positionCenter;

	public bool canStart = false;

	// Use this for initialization
	void Start () {
		tracking.hand = Meta.Hands.right;
		tracking.otherHand = Meta.Hands.left;

		tracking.socket = gameObject.GetComponent<SocketIOComponent>();

		tracking.arrowLeft = arrowRotateLeft;
		tracking.arrowRight = arrowRotateRight;
		tracking.arrowUp = arrowUp;
		tracking.arrowDown = arrowDown;
		tracking.arrowCenter = arrowCenter;

		tracking.actionUp = "rise";
		tracking.actionDown = "fall";
		tracking.actionLeft = "left";
		tracking.actionRight = "right";
		
		tracking.palmVectorText = palmVector;
		tracking.centerVectorText = centerVector;

		tracking.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		tracking.canStart = GetComponent<StartDrone>().isStarted;
		tracking.positionCenter = positionCenter.position;
		tracking.Update ();
	}
}
