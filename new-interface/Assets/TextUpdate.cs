﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (typeof(GameObject));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rise(float y){
		GetComponent<Text> ().text = "Altitude - Rising: " + y;
		GetComponent<Text> ().color = Color.green;
	}
	public void Fall(float y){
		GetComponent<Text> ().text = "Altitude - Falling: " + y;
		GetComponent<Text> ().color = Color.red;
	}
}
