using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

public class ForestCreator : ScriptableWizard {

	[MenuItem("Terrain/Generate Forests")]
	public static void CreateWizard(MenuCommand command){
		ScriptableWizard.DisplayWizard ("Forest Generation Wizard", typeof(ForestCreator));
	}

	void OnWizardUpdate(){
		helpString = "This little tool allows to create trees across the whole terrain based on the height of the land at each point";
	}

	void OnWizardCreate(){
		GameObject o = Selection.activeGameObject;
		//StreamWriter sw = System.IO.File.AppendText ("/Users/tomasmichalkevic/test.txt");
		//HelperMethods helper = new HelperMethods ();
		//Vector3 worldPosToTest = new Vector3(0,0,0);
		if (o.GetComponent<Terrain> ()) {
			for (int j = 0; j < 60; j++) {
				for (int i = 0; i < 60; i++) {
					TreeInstance tree = new TreeInstance ();
					tree.prototypeIndex = 0;
					tree.heightScale = 1.0f;
					tree.widthScale = 1.0f;
					tree.color = Color.black;
					Vector3 position = new Vector3 ((60.0f - i) / 60 - 0.01f, 0.0f, (60.0f-j)/60-0.1f);
					tree.position = position;

					//worldPosToTest = helper.convertFromLocalToWorld (position.x, position.y, position.z, o.GetComponent<Terrain> ());

					if (Random.Range (0.0f, 10.0f) < 6.0f) {
						o.GetComponent<Terrain>().AddTreeInstance (tree);
					}


				}
			}
		}
	}

	// Use this for initialization
//	void Start () {
//		terrainSize = terrain.terrainData.size;
//		//I need to create the tree near 554, 56, 123;
//
//		//test = Random.insideUnitCircle *5;
//
//		for (int j = 0; j < 7; j++) {
//			for (int i = 0; i < 14; i++) {
//				TreeInstance tree = new TreeInstance ();
//				tree.prototypeIndex = 0;
//				tree.heightScale = 1.0f;
//				tree.widthScale = 1.0f;
//				tree.color = Color.black;
//				Vector3 position = new Vector3 ((15.0f - i) / 15 - 0.07f, 0.0f, (7.0f-j)/7-0.1f);
//				tree.position = position;
//				terrain.AddTreeInstance (tree);
//			}
//		}	
//	}


//	// Update is called once per frame
//	void Update () {
//		calculatedHeight = terrain.terrainData.GetHeight (x, y);
//	}

}
