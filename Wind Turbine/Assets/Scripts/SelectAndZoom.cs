using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectAndZoom : MonoBehaviour {
	// Use this for initialization
	public GameObject delete;

	void Start () 
	{
		delete = GameObject.FindWithTag("del") as GameObject;
		delete.transform.position = new Vector3 (2000, 2000,delete.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.CompareTag ("landmill") || hit.transform.CompareTag("seamill")) {
					GameObject.FindWithTag("Yeah").GetComponent<Rotate360>().enabled = false;
					delete.transform.position = new Vector3(Input.mousePosition.x+15,Input.mousePosition.y+7,delete.transform.position.z);
					Camera.main.GetComponent<SelectedChoice>().mordelObj = hit.transform.gameObject;
					delete.SetActive(true);
				}
			}
		}
		if (Input.GetMouseButtonDown (0) && delete.transform.position != new Vector3 (2000, 2000,delete.transform.position.z)) 
		{
			GetComponent<DragMove>().enabled = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if(!hit.transform.CompareTag ("landmill") && !hit.transform.CompareTag("seamill") && !EventSystem.current.IsPointerOverGameObject())
				{
					GameObject.FindWithTag("Yeah").GetComponent<Rotate360>().enabled = true;
					delete.transform.position = new Vector3 (2000, 2000,delete.transform.position.z);
				}
			}
		}
	}
}