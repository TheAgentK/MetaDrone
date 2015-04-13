using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class StartDrone : MonoBehaviour {

	public bool isStarted = false;

	public MeshRenderer arrowCenterLeft = null;
	public MeshRenderer arrowCenterRight = null;

	public Text hudText;
	public float takeoffEndTime = -1;
	public float killEndTime = -1;
	public float noHandsEndTime = -1;

	// Use this for initialization
	void Start () {
		hudText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		//Drone Starten
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

		//Drohne mite Geste landen
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

		//keine Hände erkannt - im Notfall Drone landen
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

	private void setColorToAll(Color _color){
		arrowCenterLeft.material.color = _color;
		arrowCenterRight.material.color = _color;
	}
}
