using UnityEngine;
using System.Collections;

public class bossBullet : MonoBehaviour {

	private float velocityY = 0f;
	private bossScripts bossScript;
	public bool selfAccel = true;
	public float velocityX = 0f;
	public bool addForce = false;
	
	
	public void Start()
	{
		bossScript = GameObject.FindGameObjectWithTag("boss").GetComponent<bossScripts> ();
		addForce = bossScript.addForce;
		if (addForce == true)
			selfAccel = false;

		if (selfAccel == true && addForce == false)
		{
			velocityY = bossScript.bulletSpeed;
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, velocityY * (-1f));

		}
	}
	
	
	public void Update()
	{
		//Destroy(this.gameObject, 5); // For testing, eliminates stray bullets that have bee on-screen for too long.
	}
	
	
	public void OnCollisionEnter2D(Collision2D colInfo) 
	{
		if (colInfo.collider.tag != "bullet")
			Destroy(this.gameObject, 0.01f);
	}
}
