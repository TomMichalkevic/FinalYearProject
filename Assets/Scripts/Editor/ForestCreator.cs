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

					if (Random.Range (0.0f, 10.0f) < 6.0f) {
						o.GetComponent<Terrain>().AddTreeInstance (tree);
					}


				}
			}
		}
	}

}
