using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class HandTrackingSingle : MonoBehaviour {
	
	private HandTracking tracking = new HandTracking();
	
	public MeshRenderer arrowUp;
	public MeshRenderer arrowDown;

	public MeshRenderer arrowLeft;
	public MeshRenderer arrowRight;

	public MeshRenderer arrowForward;
	public MeshRenderer arrowBackward;

	public MeshRenderer arrowCenter;
	
	public Text centerVector;
	public Text palmVector;
	
	// Use this for initialization
	void Start () {
		tracking.hand = Meta.Hands.right;
		tracking.otherHand = Meta.Hands.left;
		
		tracking.socket = gameObject.GetComponent<SocketIOComponent>();
		
		tracking.arrowUp = arrowUp;
		tracking.arrowDown = arrowDown;
		tracking.arrowLeft = arrowLeft;
		tracking.arrowRight = arrowRight;
		tracking.arrowForward = arrowForward;
		tracking.arrowBackward = arrowBackward;
		tracking.arrowCenter = arrowCenter;

		tracking.actionUp = "rise";
		tracking.actionDown = "fall";
		tracking.actionLeft = "left";
		tracking.actionRight = "right";		
		tracking.actionForward = "forwards";
		tracking.actionBackward = "backwards";
		
		tracking.palmVectorText = palmVector;
		tracking.centerVectorText = centerVector;
		
		tracking.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		tracking.Update ();
	}
}