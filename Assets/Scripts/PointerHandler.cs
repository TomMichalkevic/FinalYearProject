using UnityEngine;
using System.Collections;

public class PointerHandler : MonoBehaviour {

	public Vector3 destination;
	GameObject pointer;

	// Use this for initialization
	void Start () {
		pointer = GameObject.Find ("Pointer");
		//pointer.transform.Rotate (new Vector3 (0, 90, 0));
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePointer ();
	}

	void UpdatePointer(){
		pointer.transform.rotation = Quaternion.LookRotation (destination);
	}
}
