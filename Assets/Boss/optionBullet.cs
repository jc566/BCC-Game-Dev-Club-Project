using UnityEngine;
using System.Collections;

public class optionBullet : MonoBehaviour {
	
	private float velocity;
	private optionAI option;
	private float stepUpTimePointer = 0f;
	public float stepUpTime = .10f;
	public float velocityIncrease = 1.50f;
	public bool accelerating = false; // Decides if bullet is progressively accelerating
	public bool multiplicative = false; // Decides if step-up is additive or multiplicative (percentage)
	
	public void Start()
	{
		option = GameObject.FindGameObjectWithTag("friendlyAI").GetComponent<optionAI> ();
		velocity = option.bulletSpeed;

		if (accelerating == true)
						velocity *= 0.10f;

		GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, velocity, 0f);


	}
	
	
	public void Update()
	{
		Destroy(this.gameObject, 5f); // For testing, eliminates stray bullets that have bee on-screen for too long.

		if (Time.time > stepUpTimePointer && accelerating == true)
		{
			if (multiplicative == true)
				velocity *= velocityIncrease;
			else
				velocity += velocityIncrease;

			GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, velocity, 0f);
			stepUpTimePointer = Time.time + stepUpTime;
		}
	}
	
	
	public void OnCollisionEnter2D(Collision2D colInfo) 
	{
		if (colInfo.collider.tag != "bullet")
			Destroy(this.gameObject, 0.01f);
	}
}