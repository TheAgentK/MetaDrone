using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

/// <summary>
/// Bewegungserkennung der rechten Hand
/// @brief Übergabe aller steuerungsaktionen und aller HUD Objekte an HandTracking()
/// @implements HandTracking
/// </summary>
/// <see cref="HandTracking">
public class HandTrackingRight : MonoBehaviour
{
	
		/// <summary>
		/// HandTracking() Objekt zur schlussendlichen steuerung
		/// </summary>
		private HandTracking tracking = new HandTracking ();

		/// <summary>
		/// HUD-Objekt Pfeil nach Links
		/// </summary>
		public MeshRenderer arrowRotateLeft;

		/// <summary>
		/// HUD-Objekt Pfeil nach Rechts
		/// </summary>
		public MeshRenderer arrowRotateRight;
	
		/// <summary>
		/// HUD-Objekt Pfeil nach Oben
		/// </summary>
		public MeshRenderer arrowUp;
	
		/// <summary>
		/// HUD-Objekt Pfeil nach Unten
		/// </summary>
		public MeshRenderer arrowDown;
	
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
				tracking.hand = Meta.Hands.right;
				tracking.otherHand = Meta.Hands.left;

				tracking.socket = gameObject.GetComponent<SocketIOComponent> ();

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
