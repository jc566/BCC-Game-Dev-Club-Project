using UnityEngine;
using System.Collections;

public class SkipEnding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Spacebar"))
		{
			Application.LoadLevel ("Credits");
		}
	}
}
