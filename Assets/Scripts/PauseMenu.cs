using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public GameObject body;
	public Slider goodGaugeSl;
	public Slider badGaugeSl;

	//Private vars used for game saving/loading
	private float badGauge;
	private float goodGauge;
	private int currentGnomeNumber;
	private GameStateControl stateControl;

	// Use this for initialization
	void Start () {
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		body = GameObject.FindWithTag ("Player");
		pauseMenu.enabled = false;
		stateControl = new GameStateControl ();
		Debug.Log (Application.persistentDataPath);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (pauseMenu.enabled==false) {
				Time.timeScale = 0;
				pauseMenu.enabled = true;
				body.GetComponent<FirstPersonController> ().enabled = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			} else {
				Time.timeScale = 1;
				pauseMenu.enabled = false;
				body.GetComponent<FirstPersonController> ().enabled = true;
			}
		}
	}

	// Initiate the save game mechanism
	public void SaveGame(){
		badGauge = GameObject.FindGameObjectWithTag ("Player").GetComponent<GaugeHandler> ().badGauge.value;
		goodGauge = GameObject.FindGameObjectWithTag ("Player").GetComponent<GaugeHandler> ().goodGauge.value;
		currentGnomeNumber = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<GnomeManager> ().currentVisible;
		stateControl.badGauge = badGauge;
		stateControl.goodGauge = goodGauge;
		stateControl.currentGnomeNumber = currentGnomeNumber;
		stateControl.Save ();
	}

	// Initiate the load game mechanism
	public void LoadGame (){
		stateControl.Load ();
		goodGaugeSl.value = stateControl.goodGauge;
		badGaugeSl.value = stateControl.badGauge;
	}

	// Exit game
	public void ExitToMenu(){
		Application.Quit ();
	}
}
