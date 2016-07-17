using UnityEngine;
using System.Collections;

public class HelperMethods : MonoBehaviour {

	void Start(){
	}

	void Update(){
	}

	public Vector3 convertFromLocalToWorld(float x, float y, float z, Terrain terrain){
		Vector3 worldCoord = new Vector3 (0, 0, 0);
		worldCoord = terrain.transform.TransformPoint (x, y, z);
		return worldCoord;

	}
}
