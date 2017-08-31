using UnityEngine;
using System.Collections;

public class Follow1 : MonoBehaviour {
	public float depth = 350.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit))
		{
			transform.position = hit.point;
		}
		if (Input.GetMouseButtonDown (1)) 
		{
			Destroy(this.gameObject);
			GameObject.FindWithTag("Yeah").GetComponent<Rotate360>().enabled = true;
		}
	}
}
