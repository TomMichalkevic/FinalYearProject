using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public GameObject body;

	// Use this for initialization
	void Start () {
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		body = GameObject.FindWithTag ("Player");
		pauseMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				pauseMenu.enabled = true;
				body.GetComponent<FirstPersonController> ().enabled = false;
			} else {
				Time.timeScale = 1;
				pauseMenu.enabled = false;
				body.GetComponent<FirstPersonController> ().enabled = true;
			}
		}
	}

	public void ExitToMenu(){
		Time.timeScale = 1;
		pauseMenu.enabled = false;
		body.GetComponent<FirstPersonController> ().enabled = true;
		Application.LoadLevel (0);
	}
}
