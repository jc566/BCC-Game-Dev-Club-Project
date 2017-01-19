using UnityEngine;
using System.Collections;

public class VortexCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D hit)
	{
		if(hit.gameObject.tag == "player")
			
		{	
			Debug.Log ("Player Touched VORTEX");
			Application.LoadLevel ("Boss");		
		}
	}
}
