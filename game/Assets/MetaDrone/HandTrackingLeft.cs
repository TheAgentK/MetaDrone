using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

/// <summary>
/// The Class for Left Handtracking
/// @implements HandTracking
/// </summary>
/// <see cref="HandTracking">
public class HandTrackingLeft : MonoBehaviour {

	private HandTracking tracking = new HandTracking();
	
	/// <summary>
	/// The arrow forward.
	/// </summary>
	public MeshRenderer arrowForward;
	/// <summary>
	/// The arrow backward.
	/// </summary>
	public MeshRenderer arrowBackward;
	/// <summary>
	/// The arrow center.
	/// </summary>
	public MeshRenderer arrowCenter;

	/// <summary>
	/// The center vector.
	/// </summary>
	public Text centerVector;
	/// <summary>
	/// The palm vector.
	/// </summary>
	public Text palmVector;

	/// <summary>
	/// The position center.
	/// </summary>
	public Transform positionCenter;

	/// <summary>
	/// The can start.
	/// </summary>
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