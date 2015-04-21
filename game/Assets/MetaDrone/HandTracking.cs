using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

/// <summary>
/// Klasse zum tracken einer Hand
/// @author Karsten Siedentopp
/// @date 20.04.2015
/// @warning Die Gestensteuerung ist bisher nicht sehr präzise
/// </summary>
public class HandTracking
{

		/// <summary>
		/// Die Hand die getracked werden soll.
		/// </summary>
		public Hand hand;

		/// <summary>
		/// Die andere Hand
		/// </summary>
		public Hand otherHand;

		/// <summary>
		/// Webschnittstelle zur Node.js Bibliothek zur Steuerung des Quadrokopters
		/// @implements SocketIOComponent
		/// </summary>
		public SocketIOComponent socket;

		/// <summary>
		/// HUD-Objekt Pfeil nach links
		/// </summary>
		public MeshRenderer arrowLeft = null;

		/// <summary>
		/// HUD-Objekt Pfeil nach rechts
		/// </summary>
		public MeshRenderer arrowRight = null;

		/// <summary>
		/// HUD-Objekt Pfeil nach oben
		/// </summary>
		public MeshRenderer arrowUp = null;

		/// <summary>
		/// HUD-Objekt Pfeil nach unten
		/// </summary>
		public MeshRenderer arrowDown = null;

		/// <summary>
		/// HUD-Objekt Pfeil nach vorne
		/// </summary>
		public MeshRenderer arrowForward = null;

		/// <summary>
		/// HUD-Objekt Pfeil nach hinten
		/// </summary>
		public MeshRenderer arrowBackward = null;

		/// <summary>
		/// HUD-Objekt Mittelpunkt
		/// </summary>
		public MeshRenderer arrowCenter = null;

		/// <summary>
		/// The action left.
		/// </summary>
		public string actionLeft = "";

		/// <summary>
		/// Socket.IO Komando wenn die Hand nach Links bewegt wird
		/// </summary>
		public string actionRight = "";

		/// <summary>
		/// Socket.IO Komando wenn die Hand nach Oben bewegt wird
		/// </summary>
		public string actionUp = "";

		/// <summary>
		/// Socket.IO Komando wenn die Hand nach Unten bewegt wird
		/// </summary>
		public string actionDown = "";

		/// <summary>
		/// Socket.IO Komando wenn die Hand von einem Weg bewegt wird
		/// </summary>
		public string actionForward = "";

		/// <summary>
		/// Socket.IO Komando wenn die Hand zu einem Hin bewegt wird
		/// </summary>
		public string actionBackward = "";

		/// <summary>
		/// Text-Objekt auf MGUI.Stats zur Ausgabe des Trackingmittelpunktes
		/// @warning Nur zum Debugen
		/// </summary>
		public Text centerVectorText;

		/// <summary>
		/// Text-Objekt auf MGUI.Stats zur Ausgabe des Handmittelpunkts
		/// @warning Nur zum Debugen
		/// </summary>
		public Text palmVectorText;

		/// <summary>
		/// Trackingmittelpunkt
		/// </summary>
		public Vector3 positionCenter;

		/// <summary>
		/// Dronensteuerung ist erlaubt oder nicht
		/// @see StartDrone
		/// </summary>
		public bool canStart = false;

		/// <summary>
		/// Handentfernung zur Meta 1 VR-Brille auf der Z-Ebene
		/// @warning Wert sollte nur verändert werden, wenn man weiß was man tut.
		/// </summary>
		private float positionCenterZ = 0.4f;

		/// <summary>
		/// Variable zur bestimmung welche Frame zur erkennung der Handbewegung genutzt werden soll.
		/// Mit dem Wert 2 wird jedes 2te Frame fallen gelassen und nicht berücksichtigt
		/// Dadurch werden bereits kleinere Fehlbewegungen der Hand herrausgefiltert
		/// @warning Wert sollte nur verändert werden, wenn man weiß was man tut.
		/// </summary>
		private int frameDelay = 2;

		/// <summary>
		/// Variable zum zählen der Frames
		/// @warning Der Wert wird automatisch gesetzt
		/// </summary>
		private int frameDelayCounter = 0;

		/// <summary>
		/// Hand wird getracked oder nicht
		/// @warning Der Wert wird automatisch gesetzt
		/// </summary>
		private bool isGrabed = false;
		
		/// <summary>
		/// True wenn Hand in Bewegung
		/// False wenn Hand nicht mehr bewegt wird.
		/// @warning Der Wert wird automatisch gesetzt
		/// </summary>
		private bool stopped = false;
	
		/// <summary>
		/// Inizialisierung des Objekts
		/// </summary>
		public void Start ()
		{
				if (canStart)
						setColorToAll (Color.white);
		}

		/// <summary>
		/// Update() wird bei jedem Frame aufgerufen.
		/// @brief Hier findet die eigentlich Steuerung statt
		/// </summary>
		
		public void Update ()
		{
				setStartPosition ();
				//centerVectorText.text = isGrabed + " | " + positionCenter.x.ToString("F2") + " | " + positionCenter.y.ToString("F2");
				
				Hand[] hands = Meta.Hands.GetHands ();
				if (hands.Length > 0 && frameDelayCounter == frameDelay) {
						
						frameDelayCounter = 0;
						
						/// Prüfte ob die Variable hand überhaupt gesetzt ist und ob die Hand im Sichtbereich der META 1 Brille ist.
						/// zusätzlich wird geprüft ob die zu erkennende Hand geöffnet ist und ob die Drone üb erhaupt gestartet ist
						
						if (hand != null && hand.isValid && (hand.gesture.type.Equals (MetaGesture.OPEN) && canStart)) {
								isGrabed = true;

								Vector3 position = hand.palm.position;

								/// Positionsparameter der Hand mit welcher gesteuert werden soll
								float xPos = position.x;
								float yPos = position.y;
								float zPos = position.z;

								float xPosDist = positionCenter.x;
								float yPosDist = positionCenter.y;
								float zPosDist = positionCenterZ;

								/// Bereich definieren, ab dem die Handbewegung als solche erkannt werden soll
								float greaterX = xPosDist + 0.04f;
								float lessX = xPosDist - 0.04f;
								float greaterY = yPosDist + 0.04f;
								float lessY = yPosDist - 0.04f;
								float greaterZ = zPosDist + 0.045f;
								float lessZ = zPosDist - 0.045f;

								/// Ausgabe der Positionsvektoren der Hand und des aktuellen Mittelpunktes
								/// Dies ist nur zu Debug Zwecken
								palmVectorText.text = lessX.ToString ("F2") + " < " + xPos.ToString ("F2") + " < " + greaterX.ToString ("F2");
								centerVectorText.text = lessY.ToString ("F2") + " < " + yPos.ToString ("F2") + " < " + greaterY.ToString ("F2");

								/// Prüfe ob die zweite Hand auch geöffnet ist, damit die Steuerung nur funktioniert, wenn beide Hände geöffnet sind
								if (otherHand.gesture.type.Equals (MetaGesture.OPEN) && canStart) {
										
										/// Auswerten der Handbewegungen und trigern des jeweiligen Events zur steuerung des Quadrocopters
										if (xPos > greaterX && actionRight != "") {
												// Hand rechts
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.green);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionRight != "")
														socket.Emit (actionRight);
										} else if (xPos < lessX && actionLeft != "") {
												// Hand links
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.green);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionLeft != "")
														socket.Emit (actionLeft);
										} else if (yPos > greaterY && actionUp != "") {
												// Hand hoch
												stopped = false;

												setColorUp (Color.green);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionUp != "")
														socket.Emit (actionUp);
										} else if (yPos < lessY && actionDown != "") {
												// Hand runter
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.green);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionDown != "")
														socket.Emit (actionDown);
										} else  if (zPos > greaterZ && actionForward != "") {
												// Hand vor
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.green);
												setColorCenter (Color.white);
						
												if (actionForward != "")
														socket.Emit (actionForward);
										} else if (zPos < lessZ && actionBackward != "") {
												// Hand zurück
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.green);
												setColorBackward (Color.white);
												setColorCenter (Color.white);
						
												if (actionBackward != "")
														socket.Emit (actionBackward);
										} else {
												// Hand mitte
												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.green);

												if (!stopped) {
														socket.Emit ("stop");
														stopped = true;
												}
										}
								}
						} else {
								isGrabed = false;
								setColorToAll (Color.white);
								if (!stopped) {
										socket.Emit ("stop");
										stopped = true;
								}
						}
				}

				frameDelayCounter++;
		}

		private void setStartPosition ()
		{
				if (isGrabed == false) {
						//positionCenterZ = hand.palm.position.z;
				}
		}
	
		private void setColorToAll (Color _color)
		{
				if (canStart)
						setColorCenter (_color);

				setColorUp (_color);
				setColorDown (_color);
				setColorLeft (_color);
				setColorRight (_color);
				setColorForward (_color);
				setColorBackward (_color);
		}

		private void setColorCenter (Color _color)
		{
				if (arrowCenter != null)
						arrowCenter.material.color = _color;
		}

		private void setColorUp (Color _color)
		{
				if (arrowUp != null)
						arrowUp.material.color = _color;
		}

		private void setColorDown (Color _color)
		{
				if (arrowDown != null)
						arrowDown.material.color = _color;
		}

		private void setColorLeft (Color _color)
		{
				if (arrowLeft != null)
						arrowLeft.material.color = _color;
		}

		private void setColorRight (Color _color)
		{
				if (arrowRight != null)
						arrowRight.material.color = _color;
		}

		private void setColorForward (Color _color)
		{
				if (arrowForward != null)
						arrowForward.material.color = _color;
		}

		private void setColorBackward (Color _color)
		{
				if (arrowBackward != null)
						arrowBackward.material.color = _color;
		}
}
