using UnityEngine;
using System.Collections;

public class BringDialogueToFront : MonoBehaviour {

	// Make the dialogue box foremost in the display hierarchy
	void OnEnable(){
		transform.SetAsLastSibling ();
	}
}
