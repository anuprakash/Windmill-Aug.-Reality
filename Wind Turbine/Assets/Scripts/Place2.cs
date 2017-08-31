using UnityEngine;
using System.Collections;

public class Place2 : MonoBehaviour {
	// Use this for initialization
	void Start () 
	{
	}
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y < 0 || transform.position.y > 0)
			transform.position = new Vector3(transform.position.x,0,transform.position.z);
		
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay( new Vector3(Input.mousePosition.x,Input.mousePosition.y) );
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit))
			{
				if(hit.transform.CompareTag("Water")){
					transform.position = new Vector3 (hit.point.x, 0, hit.point.z);
					GetComponent<BoxCollider>().enabled = true;
					GetComponent<SelectAndZoom>().enabled = true;
					GameObject obj = Instantiate (GameObject.FindWithTag ("seamill")) as GameObject;
					obj.transform.position = Input.mousePosition;
					obj.transform.rotation = this.gameObject.transform.rotation;
					obj.transform.localScale = this.gameObject.transform.lossyScale;
					obj.GetComponent<SelectAndZoom>().enabled = false;
					obj.GetComponent<BoxCollider>().enabled = false;
					obj.AddComponent<Follow1> ().enabled = true;
					obj.AddComponent<Place2> ().enabled = true;
					this.transform.parent = GameObject.FindWithTag ("Yeah").transform;
				}
				else{
					this.gameObject.GetComponent<Follow1> ().enabled = false;
					this.gameObject.GetComponent<Place2> ().enabled = false;
				}
			}
			this.gameObject.GetComponent<Follow1> ().enabled = !this.gameObject.GetComponent<Follow1> ().enabled;
			this.gameObject.GetComponent<Place2>().enabled = !this.gameObject.GetComponent<Place2>().enabled;
			
		}
		
	}
}
