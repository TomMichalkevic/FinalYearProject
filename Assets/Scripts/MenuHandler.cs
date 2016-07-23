using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHandler : MonoBehaviour {

	//public Canvas menuCan;
	public Button playGameB;
	public Button loadGameB;
	public Button aboutDevB;
	public Button exitB;
	public Canvas aboutDev;

	// Use this for initialization
	void Start () {
		//menuCan = menuCan.GetComponent<Canvas> ();
		playGameB = playGameB.GetComponent<Button> ();
		loadGameB = loadGameB.GetComponent<Button> ();
		aboutDevB = aboutDevB.GetComponent<Button> ();
		exitB = aboutDevB.GetComponent<Button> ();
		aboutDev = aboutDev.GetComponent<Canvas> ();
		//aboutDevB.enabled = false;
		//loadGameB.enabled = false;
		aboutDev.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevelOne(){
		Application.LoadLevel (1);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void HideAboutDev(){
		aboutDev.enabled = false;
		playGameB.enabled = true;
		loadGameB.enabled = true;
		aboutDevB.enabled = true;
		exitB.enabled = true;
	}

	public void ShowAboutDev(){
		aboutDev.enabled = true;
		playGameB.enabled = false;
		loadGameB.enabled = false;
		aboutDevB.enabled = false;
		exitB.enabled = false;
	}

	public void LoadGame(){
		GameStateControl.stateControl.Load ();
	}
}
