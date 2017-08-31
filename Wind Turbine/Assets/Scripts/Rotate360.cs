using UnityEngine;
using System.Collections;

public class Rotate360 : MonoBehaviour {

	// Use this for initialization
	public GameObject buildings;
	public GameObject cones;
	public bool press;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		onClick ();
		if (press) 
		{
			transform.Rotate (0, 2f, 0);
			buildings.transform.Rotate(0,2f,0);
			cones.transform.Rotate(0,2f,0);
		}
		if (Input.GetMouseButtonDown (0))
			press = false;
	}

	public void onClick()
	{
		if (Input.GetMouseButton (0)) 
		{
			if(Input.GetAxis("Mouse X") < 0){
				transform.Rotate (0, 3.5f, 0);
				buildings.transform.Rotate(0,3.5f,0);
				cones.transform.Rotate(0,3.5f,0);
			}
			if(Input.GetAxis("Mouse X") > 0){
				transform.Rotate (0, -3.5f, 0);
				buildings.transform.Rotate(0,-3.5f,0);
				cones.transform.Rotate(0,-3.5f,0);
			}
		}
	}
	public void on360Click()
	{
		GameObject.FindWithTag ("del").transform.position = new Vector3 (2000, 2000, GameObject.FindWithTag ("del").transform.position.z);
		press = !press;
	}
}
