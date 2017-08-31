using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y < 0 || transform.position.y > 0)
			transform.position = new Vector3(transform.position.x,0,transform.position.z);

		if (Input.GetMouseButtonDown (0)) {

			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Input.mousePosition.x, Input.mousePosition.y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) 
			{
				transform.position = new Vector3 (hit.point.x, 0, hit.point.z);
				GetComponent<BoxCollider> ().enabled = true;
				GetComponent<SelectAndZoom> ().enabled = true;
			}
			this.gameObject.GetComponent<Follow1> ().enabled = false;
			this.gameObject.GetComponent<Move> ().enabled = false;
		}
	}
}
