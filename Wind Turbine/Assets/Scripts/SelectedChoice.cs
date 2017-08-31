using UnityEngine;
using System.Collections;

public class SelectedChoice : MonoBehaviour {

	// Use this for initialization
	public GameObject landmill;
	public GameObject seamill;
	public GameObject mordelObj;
	public GameObject delbutton;
	//public GameObject movebutton;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
	
	}
	public void onLandClick()
	{
		delbutton.transform.position = new Vector3 (2000, 2000,delbutton.transform.position.z);
		//movebutton.transform.position = new Vector3 (2000, 2000,movebutton.transform.position.z);
		GameObject land = Instantiate (landmill) as GameObject;
		land.transform.position = Input.mousePosition;
		land.GetComponent<BoxCollider> ().enabled = false;
		land.transform.localScale = landmill.transform.lossyScale;
		land.transform.rotation = landmill.transform.rotation;
		land.AddComponent<Follow1> ().enabled = true;
		land.AddComponent<Place> ().enabled = true;
		land.GetComponent<DragMove> ().enabled = false;
		land.GetComponent<SelectAndZoom> ().enabled = false;
		GameObject.FindWithTag ("Yeah").GetComponent<Rotate360> ().enabled = false;
	}
	public void onSeaClick()
	{
		delbutton.transform.position = new Vector3 (2000, 2000,delbutton.transform.position.z);
		//movebutton.transform.position = new Vector3 (2000, 2000,movebutton.transform.position.z);
		GameObject sea = Instantiate (seamill) as GameObject;
		sea.transform.position = Input.mousePosition;
		sea.GetComponent<BoxCollider> ().enabled = false;
		sea.transform.rotation = seamill.transform.rotation;
		sea.transform.localScale = seamill.transform.lossyScale;
		sea.AddComponent<Follow1> ().enabled = true;
		sea.GetComponent<DragMove> ().enabled = false;
		sea.AddComponent<Place2> ().enabled = true;
		sea.GetComponent<SelectAndZoom> ().enabled = false;
		GameObject.FindWithTag ("Yeah").GetComponent<Rotate360> ().enabled = false;
	}
	public void onDeleteClick()
	{
		mordelObj.GetComponent<SelectAndZoom> ().enabled = false;
		Destroy (mordelObj);
		delbutton.transform.position = new Vector3 (2000, 2000,delbutton.transform.position.z);
		//movebutton.transform.position = new Vector3 (2000, 2000,movebutton.transform.position.z);
		GameObject.FindWithTag("Yeah").GetComponent<Rotate360>().enabled = true;
	}
	/*
	public void onMoveClick()
	{
		mordelObj.GetComponent<SelectAndZoom> ().enabled = false;
		mordelObj.GetComponent<Follow1> ().enabled = true;
		mordelObj.AddComponent<Move> ().enabled = true;
		mordelObj.GetComponent<BoxCollider> ().enabled = false;
		delbutton.transform.position = new Vector3 (2000, 2000,delbutton.transform.position.z);
		movebutton.transform.position = new Vector3 (2000, 2000,movebutton.transform.position.z);
	}
	*/
	public void onResetClick()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}
}
