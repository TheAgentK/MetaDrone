using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class StartDrone : MonoBehaviour {

	/// <summary>
	/// Zeigt an ob der Quadrocopter gestart ist oder nicht
	/// </summary>
	public bool isStarted = false;

	/// <summary>
	/// Mesh-Objekt für den linken Mittelpunkt
	/// </summary>
	public MeshRenderer arrowCenterLeft = null;
	/// <summary>
	/// Mesh-Objekt für den rechten Mittelpunkt
	/// </summary>
	public MeshRenderer arrowCenterRight = null;

	/// <summary>
	/// Text-Objekt zur benachrichtigung des Benutzers
	/// </summary>
	public Text hudText;

	/// <summary>
	/// Temporäre Variable zur Speicherung eines Zeitpunktes um die Geste zum Starten Zeitgesteuert ausführen zu können
	/// @brief Die Geste zum Starten muss 5 sec gehalten werden, damit der Quadrocopter startet
	/// </summary>
	private float takeoffEndTime = -1;

	/// <summary>
	/// Temporäre Variable zur Speicherung eines Zeitpunktes um die Geste zum Landen Zeitgesteuert ausführen zu können
	/// @brief Die Geste zum Landen muss 2 sec gehalten werden, damit der Quadrocopter startet
	/// </summary>
	private float killEndTime = -1;

	/// <summary>
	/// Temporäre Variable zur Speicherung eines Zeitpunktes um die Geste zum Landen Zeitgesteuert ausführen zu können
	/// @brief Wenn keine Hänge erkannt werden, wird dem benutzer 10 sec Zeit gegeben, die Steuerung wieder aufzunehmen.
	/// 	   Ansonsten wird der Quadrocopter Notgelandet.
	/// </summary>
	private float noHandsEndTime = -1;

	/// <summary>
	/// Inizialisierung des Objekts
	/// @brief Der HUD-Text wird gelert, damit der benutzer keine Benachrichtigung beim inizialisieren sieht
	/// </summary>
	void Start () {
		hudText.text = "";
	}
	
	/// <summary>
	/// Update() wird bei jedem Frame aufgerufen.
	/// @brief Hier findet die eigentlich Steuerung statt
	/// </summary>
	void Update () {
		startDrone ();
		killDrone ();
		safetyKill ();
	}

	/// <summary>
	/// Gestenerkennung zum Starten des Quadrocopters
	/// @brief Die linke Hand muss geöffnet und die Rechte geschlossen sein um den Quadrocopter zu starten
	/// Die Geste muss dann 5 sec gehalten werden um die Drohne abheben zu lassen
	/// </summary>
	private void startDrone(){
		if (Meta.Hands.right.gesture.type.Equals (MetaGesture.GRAB) && Meta.Hands.left.gesture.type.Equals (MetaGesture.OPEN) && isStarted == false) {
			hudText.color = Color.green;
			setColorToAll (Color.red);
			
			if(takeoffEndTime == -1){
				takeoffEndTime = Time.time + 5;
				hudText.text = "Start in 5";
			}
			
			int timeLeft = (int)(takeoffEndTime - Time.time);
			
			if (timeLeft <= 0) {
				timeLeft = 0;
				isStarted = true;
				gameObject.GetComponent<SocketIOComponent> ().Emit ("takeoff");
				setColorToAll (Color.green);
			} else {
				hudText.text = "Start in " + timeLeft.ToString (); 
			}
		} else {
			takeoffEndTime = -1;
			hudText.text = "";
		}
	}

	/// <summary>
	/// Gestenerkennung zum Landen des Quadrocopters
	/// @brief Beide Hände müssen geschlossen sein um den Quadrocopter zu landen
	/// Die Geste muss dann 2 sec gehalten werden um die Drohne landen zu lassen
	/// </summary>
	private void killDrone(){
		if (Meta.Hands.right.gesture.type.Equals (MetaGesture.GRAB) && Meta.Hands.left.gesture.type.Equals (MetaGesture.GRAB)) {
			hudText.color = Color.red;
			setColorToAll (Color.red);
			
			if(killEndTime == -1){
				killEndTime = Time.time + 2;
				hudText.text = "Landen in 2";
			}
			
			int timeLeft = (int)(killEndTime - Time.time);
			
			if (timeLeft <= 0) {
				timeLeft = 0;
				isStarted = false;
				gameObject.GetComponent<SocketIOComponent> ().Emit ("kill");
				setColorToAll (Color.red);
			} else {
				hudText.text = "Landen in " + timeLeft.ToString (); 
			}
		} else {
			killEndTime = -1;
		}
	}

	/// <summary>
	/// Sicherheitsfunktion zum Notlanden der Drohne wenn keine Hände erkannt werden
	/// @brief Wenn keine Hände erkannt werden, wird die Drohne nach 10 sec Notgelandet.
	/// </summary>
	private void safetyKill(){
		if ((!Meta.Hands.right.isValid && !Meta.Hands.left.isValid) && isStarted) {
			hudText.fontSize = 60;
			hudText.color = Color.red;
			setColorToAll (Color.red);
			
			if(noHandsEndTime == -1){
				noHandsEndTime = Time.time + 10;
				hudText.text = "Hände nicht erkannt \r\n Landen in 10";
			}
			
			int timeLeft = (int)(noHandsEndTime - Time.time);
			
			if (timeLeft <= 0) {
				timeLeft = 0;
				isStarted = false;
				gameObject.GetComponent<SocketIOComponent> ().Emit ("kill");
				setColorToAll (Color.red);
			} else {
				hudText.text = "Hände nicht erkannt \r\n Landen in " + timeLeft.ToString ();
			}
		} else {
			noHandsEndTime = -1;
			hudText.fontSize = 80;
		}
	}

	/// <summary>
	/// Setzte beide Mittelpunkte auf die gleiche Farbe
	/// </summary>
	private void setColorToAll(Color _color){
		arrowCenterLeft.material.color = _color;
		arrowCenterRight.material.color = _color;
	}
}
