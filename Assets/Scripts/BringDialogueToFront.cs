using UnityEngine;
using System.Collections;

public class BringDialogueToFront : MonoBehaviour {

	void OnEnable(){
		transform.SetAsLastSibling ();
	}
}
