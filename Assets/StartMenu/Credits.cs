﻿using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver()
	{
		Debug.Log ("Mouse is Hovering Over Credits Button");
		
		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log ("Credit has been clicked");
			Application.LoadLevel("Credits");
		}
	}
}
