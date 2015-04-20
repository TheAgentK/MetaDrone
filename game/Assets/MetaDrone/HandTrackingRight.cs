using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

/// <summary>
/// The Class for Right Handtracking
/// @implements HandTracking
/// </summary>
/// <see cref="HandTracking">
public class HandTrackingRight : MonoBehaviour {

	private HandTracking tracking = new HandTracking();

	/// <summary>
	/// The arrow rotate left.
	/// </summary>
	public MeshRenderer arrowRotateLeft;
	/// <summary>
	/// The arrow rotate right.
	/// </summary>
	public MeshRenderer arrowRotateRight;
	/// <summary>
	/// The arrow up.
	/// </summary>
	public MeshRenderer arrowUp;
	/// <summary>
	/// The arrow down.
	/// </summary>
	public MeshRenderer arrowDown;
	/// <summary>
	/// The arrow center.
	/// </summary>
	public MeshRenderer arrowCenter;

	/// <summary>
	/// Text object to display Debug Informations about the Position Vector
	/// </summary>
	public Text centerVector;
	/// <summary>
	/// Text Object to display Debug Informations about the Palm Position Vector
	/// </summary>
	public Text palmVector;

	/// <summary>
	/// The Center Position to calculate the Hand movments
	/// </summary>
	public Transform positionCenter;

	/// <summary>
	/// Variable to
	/// </summary>
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
