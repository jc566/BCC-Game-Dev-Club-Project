using UnityEngine;
using System.Collections;

public class ItemsCollision : MonoBehaviour {


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
* General Collision
*/
	void OnCollisionEnter2D(Collision2D hit)
	{
		if(hit.gameObject.tag == "player")
			
		{	
			Debug.Log ("Player Touched This Item");
			DestroyObject(this.gameObject);			
		}
	}
	/*Not Needed since its destroyed instantly on contact!
	 * void OnCollisionExit2D(Collision2D hit)
	{
		Debug.Log ("This Item is Donezo!");

	}
	*/
}
