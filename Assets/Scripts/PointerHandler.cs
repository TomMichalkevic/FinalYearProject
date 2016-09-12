using UnityEngine;
using System.Collections;

public class PointerHandler : MonoBehaviour {

	public Vector3 destination;
	GameObject pointer;
	GameObject terrain;
	GnomeManager gnomeManager;
	public GameObject currentGnome;

	// Use this for initialization
	void Start () {
		pointer = GameObject.Find ("Pointer");
		terrain = GameObject.Find ("Terrain");
		gnomeManager = terrain.GetComponent<GnomeManager>();
		currentGnome = gnomeManager.gnomeOne;
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePointer ();
		currentGnome = gnomeManager.currentGnome;
	}

	// Update the rotation of the pointer
	void UpdatePointer(){
		pointer.transform.LookAt (currentGnome.transform);
	}
}
