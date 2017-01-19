using UnityEngine;
using System.Collections;

public class bossVaks : MonoBehaviour 
{

	public int bossHP;
	public Transform playerLocation;
	public GameObject bossProjectile;
	public playerScripts playerScript;
	public float speed;

	// Use this for initialization
	void Start () 
	{

		playerScript = GameObject.FindGameObjectWithTag ("player").GetComponent <playerScripts>();
		//damagePtoB = playerScript.damage;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (playerLocation.transform.position.x > this.transform.position.x)
			GetComponent<Rigidbody2D>().velocity = (new Vector3 (speed, 0f, 0f));
		
		if (playerLocation.transform.position.x < this.transform.position.x)
			GetComponent<Rigidbody2D>().velocity = (new Vector3 (speed * -1f, 0f, 0f));
		
		/*if (Time.time > cooldownPointer && spreadShot == false)
			StartCoroutine ("shoot");
		
		if (Time.time > cooldownPointer && spreadShot == true)
			StartCoroutine ("spreadshot");*/
			
	}
}
