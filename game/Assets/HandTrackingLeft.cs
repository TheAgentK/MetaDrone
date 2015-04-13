using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class HandTrackingLeft : MonoBehaviour {

	private HandTracking tracking = new HandTracking();
	
	public MeshRenderer arrowForward;
	public MeshRenderer arrowBackward;
	public MeshRenderer arrowCenter;

	public Text centerVector;
	public Text palmVector;

	public Transform positionCenter;

	public bool canStart = false;

	// Use this for initialization
	void Start () {
		tracking.hand = Meta.Hands.left;
		tracking.otherHand = Meta.Hands.right;

		tracking.socket = gameObject.GetComponent<SocketIOComponent>();

		tracking.arrowForward = arrowForward;
		tracking.arrowBackward = arrowBackward;
		tracking.arrowCenter = arrowCenter;

		tracking.actionForward = "forwards";
		tracking.actionBackward = "backwards";
		
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