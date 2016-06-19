using UnityEngine;
using System.Collections;

public class ForestCreator : MonoBehaviour {

	public Terrain terrain;
	//This is used for debugging
	public Vector3 terrainSize;
	public Vector2 test;

	// Use this for initialization
	void Start () {
		terrainSize = terrain.terrainData.size;
		//I need to create the tree near 554, 56, 123;

		test = Random.insideUnitCircle *5;

		for (int j = 0; j < 7; j++) {
			for (int i = 0; i < 14; i++) {
				TreeInstance tree = new TreeInstance ();
				tree.prototypeIndex = 0;
				tree.heightScale = 1.0f;
				tree.widthScale = 1.0f;
				tree.color = Color.black;
				Vector3 position = new Vector3 ((15.0f - i) / 15 - 0.07f, 0.0f, (7.0f-j)/7-0.1f);
				tree.position = position;
				terrain.AddTreeInstance (tree);
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
