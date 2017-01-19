using UnityEngine;
using System.Collections;

public class bossScripts : MonoBehaviour {


	public float bossHPMax = 5;
	public float bossHP = 5;
	public float damage = 1; // Damage boss bullets deal to player
	public float speed = 7.5f; // Boss movement speed
	public float bulletRotationY = 15f; //
	public float bulletRotationX = 15f; //
	public GameObject bossBulletObject; // Bullet link
	public float firingRate = 0.55f;
	private float cooldownPointer; // Internal cooldown variable
	private float damagePtoB;
	private Transform playerPosition; // Used for tracking the player's movements
	private playerScripts playerScript; // Player script reference holder
	public float firingPositionY = -2.5f; // Firing offset Y
	public float firingPositionX = 0f; // Firing offset X
	public bool spreadShot = false; // Activates spread shot mode (tri-bullet)
	public float bulletSpeed = 7.5f;
	public bool addForce = false;
	public float force = 5f;
	public float spreadOffsetX = 1.5f;

	public GameObject DAN;

	// Use this for initialization
	void Start () {

		if (bossHP != bossHPMax)
			bossHP = bossHPMax;

		playerPosition = GameObject.FindGameObjectWithTag ("player").transform;
		playerScript = GameObject.FindGameObjectWithTag ("player").GetComponent <playerScripts>();
		damagePtoB = playerScript.damage;

		force = bulletSpeed * 100;
	}
	
	// Update is called once per frame
	void Update () {

		if (playerPosition.transform.position.x > this.transform.position.x)
			GetComponent<Rigidbody2D>().velocity = (new Vector3 (speed, 0f, 0f));

		if (playerPosition.transform.position.x < this.transform.position.x)
			GetComponent<Rigidbody2D>().velocity = (new Vector3 (speed * -1f, 0f, 0f));

		if (Time.time > cooldownPointer && spreadShot == false)
			StartCoroutine ("shoot");

		if (Time.time > cooldownPointer && spreadShot == true)
			StartCoroutine ("spreadshot");
	}
		public void OnCollisionEnter2D (Collision2D colInfo)
	{

		if (colInfo.collider.tag == "bullet") // Boss gets damaged
			bossHP -= damagePtoB; 
		// PUT BOSS GUI UPDATE HERE //

		if(bossHP < 0)
		{
			GameObject.Destroy(this);

			Instantiate (DAN, transform.position, transform.rotation);
		}
	}


	public void Credits(){
				
		Application.LoadLevel("End_Comic");
			
		
	}
	public void shoot ()
	{
		GameObject bulletClone = Instantiate(bossBulletObject, transform.position + new Vector3(firingPositionX,firingPositionY,0f), transform.rotation) as GameObject;
		cooldownPointer = Time.time + firingRate;
		bulletClone.transform.Rotate (0f, 0f, 0f);
		if (addForce == true) {
			bulletClone.GetComponent<Rigidbody2D>().AddForce (bulletClone.transform.up * force);
		}
	}

	public void spreadshot ()
	{

		GameObject bulletClone2 = Instantiate (bossBulletObject, transform.position + new Vector3 (firingPositionX, firingPositionY, 0f), transform.rotation) as GameObject;
		bulletClone2.transform.Rotate (0f, 0f, 0f);
		if (addForce == true) {
			bulletClone2.GetComponent<Rigidbody2D>().AddForce (bulletClone2.transform.up * (1f * force));
		}
		
		GameObject bulletClone3 = Instantiate (bossBulletObject, transform.position + new Vector3 (firingPositionX + spreadOffsetX, firingPositionY, 0f), transform.rotation) as GameObject;
		bulletClone3.transform.Rotate (bulletRotationX, (-1f * bulletRotationY), 0f);
		if (addForce == true) {
			bulletClone3.GetComponent<Rigidbody2D>().AddForce (bulletClone3.transform.up * (1f * force));
		}
		
		GameObject bulletClone4 = Instantiate (bossBulletObject, transform.position + new Vector3 (firingPositionX - spreadOffsetX, firingPositionY, 0f), transform.rotation) as GameObject;
		bulletClone4.transform.Rotate (bulletRotationX, bulletRotationY, 0f);
		if (addForce == true) {
			bulletClone4.GetComponent<Rigidbody2D>().AddForce (bulletClone4.transform.up * (1f * force));
		}
		
		cooldownPointer = Time.time + firingRate;
	}
}
