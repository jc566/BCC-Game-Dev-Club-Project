using UnityEngine;
using System.Collections;

public class optionAI : MonoBehaviour {

	public float speed = 10;
	public bool matchSpeed = true; // Matches AI to player's speed
	public float firingRateCooldown = 0.45f;
	public bool doubleCooldown = true; // Uses the player's cooldown times 2
	public float maxDistance = 10; // Maximum follow distance
	public GameObject bulletLink;
	public float cooldownPointer = 0f;
	public float firingPositionX = 0f;
	public float firingPositionY = 1.5f;
	public float bulletSpeed = 10f;
	public bool matchBulletSpeed = true;
	private Transform playerPosition;
	private playerScripts player;
	private float x2;
	private float x1;
	private float y2;
	private float y1;
	private float x3;
	private float y3;


	// Use this for initialization
	void Start () {

		playerPosition = GameObject.FindGameObjectWithTag ("player").transform;
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<playerScripts> ();

		if (playerPosition.transform.position.y != this.transform.position.y)
			transform.position = new Vector2 (0f, playerPosition.transform.position.y);

		if (doubleCooldown == true)
			firingRateCooldown = 2f * player.rateOfFire;

		if (matchSpeed == true)
			speed = player.speed;

		if (matchBulletSpeed == true)
			bulletSpeed = player.bulletSpeedP;

	}
	
	// Update is called once per frame
	void Update () {

		x2 = playerPosition.transform.position.x;
		y2 = playerPosition.transform.position.y;
		x1 = this.transform.position.x;
		y1 = this.transform.position.y;
		x3 = x2 - x1;
		y3 = y2 - y1;


		if (Mathf.Sqrt (Mathf.Pow(x3, 2f) + Mathf.Pow(y3, 2f)) > maxDistance) 
		{
			if (playerPosition.transform.position.x > this.transform.position.x)
				GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0f);
			if (playerPosition.transform.position.x < this.transform.position.x)
				GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed,0f);
		} 
		else 
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0f,0f);
		}


		if (Time.time > cooldownPointer) {
			GameObject bulletClone = Instantiate (bulletLink, transform.position + new Vector3(firingPositionX,firingPositionY,0f), transform.rotation) as GameObject;
			cooldownPointer = Time.time + firingRateCooldown;

		}
	}
}
