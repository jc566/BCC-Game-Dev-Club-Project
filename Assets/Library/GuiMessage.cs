using UnityEngine;
using System.Collections;

public class GuiMessage : MonoBehaviour {

	private string message;
	// Use this for initialization
	void Start () {
	
		message = "You missed your Final Exam. The PROFESSOR has given you one chance to defeat him in battle." +
			"Collect your tools od dstruction. An Energy Drink, a Flash Drive, & your Textbook and" +
				"face your EXAM!!!!!!!!!!!!!!";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

		GUI.Label(new Rect(Screen.width/3, Screen.height /3, 200f, 200f), message);
	}
}
