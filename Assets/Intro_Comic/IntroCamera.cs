using UnityEngine;
using System.Collections;

public class IntroCamera : MonoBehaviour {

	//make reference for Comic Panels
	public GameObject Panel01;
	public GameObject Panel02;
	public GameObject Panel03;
	public GameObject Panel04;

	//make reference to panel locations
	public Transform panel01;
	public Transform panel02;
	public Transform panel03;
	public Transform panel04;





	// Use this for initialization
	void Start () {
		//Detect location of panels
		panel01 = Panel01.transform;
		panel02 = Panel02.transform;
		panel03 = Panel03.transform;
		panel04 = Panel04.transform;



		//move from first panel to second panel
		StartCoroutine(FirstCoroutine(panel02));




	}
	
	// Update is called once per frame
	void Update () {

	}

	//moving from first to second panel
	IEnumerator FirstCoroutine(Transform panel02)
	{
		//wait for first panel then start moving
		yield return new WaitForSeconds(3.2f);

		//begin to move camera
		while(Vector2.Distance(transform.position, panel02.position) > 0.01f)
		{
			moveToPanel();

			yield return null;
		}

		Debug.Log ("Reached 2nd panel");
		yield return new WaitForSeconds(2.5f);
		//move from second panel to third panel
		StartCoroutine(SecondCoroutine(panel03));
	}

	//moving from second to third panel
	IEnumerator SecondCoroutine(Transform panel03)
	{
		while(Vector2.Distance(transform.position, panel03.position) > 0.01f)
		{
			moveToPanel();
			
			yield return null;
		}
		Debug.Log ("Reached 3rd panel");
		yield return new WaitForSeconds(2.5f);
		//move from third panel to last panel
		StartCoroutine(FinalCoroutine(panel04));
	}

	//moving from third panel to last panel, then start Library
	IEnumerator FinalCoroutine(Transform panel04)
	{
		while(Vector2.Distance(transform.position, panel04.position) > 0.01f)
		{
			moveToPanel();
			
			yield return null;
		}
		Debug.Log ("Reached 4rd panel");
		yield return new WaitForSeconds(4f);

		//Load Library Level
		Application.LoadLevel("Library");
	}

	//function to move camera to panel to the right
	void moveToPanel()
	{
		transform.Translate(Vector3.right * Time.deltaTime);
	}


}
