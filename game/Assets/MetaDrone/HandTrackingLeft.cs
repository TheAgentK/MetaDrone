using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

/// <summary>
/// Bewegungserkennung der linken Hand
/// @brief Übergabe aller steuerungsaktionen und aller HUD Objekte an HandTracking()
/// @implements HandTracking
/// </summary>
/// <see cref="HandTracking">
public class HandTrackingLeft : MonoBehaviour
{

		/// <summary>
		/// HandTracking() Objekt zur schlussendlichen steuerung
		/// </summary>
		private HandTracking tracking = new HandTracking ();
	
		/// <summary>
		/// HUD-Objekt Pfeil nach vorne
		/// </summary>
		public MeshRenderer arrowForward;

		/// <summary>
		/// HUD-Objekt Pfeil nach hinten
		/// </summary>
		public MeshRenderer arrowBackward;

		/// <summary>
		/// HUD-Objekt Mittelpunkt
		/// </summary>
		public MeshRenderer arrowCenter;

		/// <summary>
		/// Text-Objekt auf MGUI.Stats zur Ausgabe des Trackingmittelpunktes
		/// @warning Nur zum Debugen
		/// </summary>
		public Text centerVector;

		/// <summary>
		/// Text-Objekt auf MGUI.Stats zur Ausgabe des Handmittelpunkts
		/// @warning Nur zum Debugen
		/// </summary>
		public Text palmVector;

		/// <summary>
		/// Trackingmittelpunkt
		/// </summary>
		public Transform positionCenter;

		/// <summary>
		/// Dronensteuerung ist erlaubt oder nicht
		/// @see StartDrone
		/// </summary>
		public bool canStart = false;

		/// <summary>
		/// Inizialisierung des HandTracking Objekts mit allen nötigen Informationen
		/// </summary>
		void Start ()
		{
				tracking.hand = Meta.Hands.left;
				tracking.otherHand = Meta.Hands.right;

				tracking.socket = gameObject.GetComponent<SocketIOComponent> ();

				tracking.arrowForward = arrowForward;
				tracking.arrowBackward = arrowBackward;
				tracking.arrowCenter = arrowCenter;

				tracking.actionForward = "forwards";
				tracking.actionBackward = "backwards";
		
				tracking.palmVectorText = palmVector;
				tracking.centerVectorText = centerVector;

				tracking.Start ();
		}
	
		/// <summary>
		/// Update() wird bei jedem Frame aufgerufen.
		/// @brief Hier findet die eigentlich Steuerung statt
		/// </summary>
		void Update ()
		{
				tracking.canStart = GetComponent<StartDrone> ().isStarted;
				tracking.positionCenter = positionCenter.position;
				tracking.Update ();
		}
}