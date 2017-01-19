using UnityEngine;
using System.Collections;

public class BossFightConditions : MonoBehaviour {

	//make reference to the player
	public GameObject player;

	//make reference to Vortex item
	public GameObject Vortex;

	//make reference to Vortex Spawn Location
	public GameObject SpawnLocation;

	//booleans to see if all items collected, all set to false to begin
	public bool Energy = false;
	public bool Textbook = false;
	public bool Flash = false;
	public bool AllItems = false;

	public GameObject Message;

	IEnumerator DestroyGUIMessage()
	{
		yield return new WaitForSeconds(5);
		GameObject.Destroy(Message);

	}
	// Use this for initialization
	void Start () {

		StartCoroutine("DestroyGUIMessage");
	}
	
	// Update is called once per frame
	void Update () {
	
		//Run function to Create Vortex once Conditions are met
		CreateVortex ();

		//Run function to see if all items are acquired
		IsVortexAllowed();


	
	}
	//Function that checks for Vortex instantiate conditions
	void IsVortexAllowed()
	{
		if(Energy == true && Textbook == true && Flash == true)
		{
			Debug.Log ("All items are picked up, vortex is allowed to spawn!");
			AllItems = true;
			//Reset all other bools to false to avoid infinite loop
			Energy = false;
			Textbook = false;
			Flash = false;
		}
	}

	//Function that creates Vortext when conditions met
	void CreateVortex()
	{
		if(AllItems == true)
		{
			GameObject VortexClone = Instantiate(Vortex, SpawnLocation.transform.position, SpawnLocation.transform.rotation) as GameObject;
			AllItems = false;
		}
	}

	//Collision Detection to register that items are touched
	void OnCollisionEnter2D(Collision2D hit)
	{


		if(hit.gameObject.tag == "algebratextbook")
		{
			Debug.Log ("Item Registered to True");
			Textbook = true;
		}
		if(hit.gameObject.tag == "flashdrive")
		{
			Debug.Log ("Item Registered to True");
			Flash = true;
		}
		if(hit.gameObject.tag == "energydrink")
		{
			Debug.Log ("Item Registered to True");
			Energy = true;
		}
	}
}
