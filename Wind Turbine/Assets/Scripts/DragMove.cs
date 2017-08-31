using UnityEngine;
using System.Collections;

public class DragMove : MonoBehaviour {

	private bool _mouseState;
	private GameObject target;
	public Vector3 screenSpace;
	public Vector3 offset;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Debug.Log(_mouseState);
		if (Input.GetMouseButtonDown (0)) {
			
			RaycastHit hitInfo;
			target = GetClickedObject (out hitInfo);
			if (target != null) {
				_mouseState = true;
				screenSpace = Camera.main.WorldToScreenPoint (target.transform.position);
				offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
			}
		}
		if (Input.GetMouseButtonUp (0)) {
			_mouseState = false;
			GameObject.FindWithTag("Yeah").GetComponent<Rotate360>().enabled = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit)) {
				if(hit.transform.CompareTag("landmill") || hit.transform.CompareTag("seamill"))
				{
					GameObject delete = GameObject.FindWithTag("del") as GameObject;
					delete.transform.position = new Vector3(Input.mousePosition.x+15,Input.mousePosition.y+7,delete.transform.position.z);;
				}
			}
			//GetComponent<DragMove>().enabled = false;
		}
		if (_mouseState) {
			GameObject delete = GameObject.FindWithTag("del") as GameObject;
			delete.transform.position = new Vector3 (2000, 2000,delete.transform.position.z);

			//keep track of the mouse position
			var curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			//convert the screen mouse position to world point and adjust with offset
			var curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;
			//update the position of the object in the world
			target.transform.position = curPosition;
			//target.transform.position = new Vector3 (curPosition.x, 0, curPosition.z);
			//target.transform.position = new Vector3(Input.mousePosition.x,0,Input.mousePosition.y);
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//RaycastHit hit;
			//if (Physics.Raycast (ray, out hit))
			//{
			//	target.transform.position = hit.point;
			//'}
			if(target.transform.position.y < 0 || target.transform.position.y > 0)
				target.transform.position = new Vector3(target.transform.position.x,0,target.transform.position.z);
		}
	}
	
	
	GameObject GetClickedObject (out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray,out hit)) {
			if(hit.transform.CompareTag("landmill") || hit.transform.CompareTag("seamill"))
				target = hit.collider.gameObject;
		}
		
		return target;
	}

}
