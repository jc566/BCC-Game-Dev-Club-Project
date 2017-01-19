using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	private float velocity;
	private playerScripts playerScript;
	
	
	public void Start()
	{
		playerScript = GameObject.FindGameObjectWithTag("player").GetComponent<playerScripts> ();
		velocity = playerScript.bulletSpeedP;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, velocity);
	}
	
	
	public void Update()
	{
		Destroy(this.gameObject, 5); // For testing, eliminates stray bullets that have bee on-screen for too long.
	}
	
	
	public void OnCollisionEnter2D(Collision2D colInfo) 
	{
		if (colInfo.collider.tag != "bullet")
			Destroy(this.gameObject, 0.01f);
	}
}