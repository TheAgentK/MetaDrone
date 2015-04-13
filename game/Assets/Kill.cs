using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class Kill : MonoBehaviour {
	
	public bool isStarted = false;
	
	public MeshRenderer arrowCenterLeft = null;
	public MeshRenderer arrowCenterRight = null;
	public MeshRenderer arrowCenterDefault = null;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Meta.Hands.right.gesture.type.Equals (MetaGesture.GRAB) && Meta.Hands.left.gesture.type.Equals (MetaGesture.GRAB) && isStarted == true) {
			setColorToAll (Color.red);
			isStarted = false;
		}
	}
	
	private void setColorToAll(Color _color){
		arrowCenterLeft.material.color = _color;
		arrowCenterRight.material.color = _color;
		arrowCenterDefault.material.color = _color;
	}
}
