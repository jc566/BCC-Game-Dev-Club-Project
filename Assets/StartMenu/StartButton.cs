using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver()
	{
		Debug.Log ("Mouse is Hovering Over Start Button");

		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log ("Start has been clicked");
			Application.LoadLevel("Intro_Comic");
		}
	}
}
