using UnityEngine;
using System.Collections;

public class RotatePropeller : MonoBehaviour {
	public float rand;
	// Use this for initialization
	void Start () 
	{
		rand = Random.Range (-30f, 30f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0, 0, rand);
	}
}
