using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public Canvas pauseMenu;
	public GameObject body;

	//Private vars used for game saving/loading
	private float badGauge;
	private float goodGauge;
	private GameObject currentGnome;
	private int currentGnomeNumber;
	private Vector3 playerPosition;
	private GameStateControl stateControl;

	// Use this for initialization
	void Start () {
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		body = GameObject.FindWithTag ("Player");
		pauseMenu.enabled = false;
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

	public void SaveGame(){
		badGauge = GameObject.FindGameObjectWithTag ("Player").GetComponent<GaugeHandler> ().badGauge.value;
		goodGauge = GameObject.FindGameObjectWithTag ("Player").GetComponent<GaugeHandler> ().goodGauge.value;
		currentGnome = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<GnomeManager> ().currentGnome;
		currentGnomeNumber = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<GnomeManager> ().currentVisible;
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform.position;
		stateControl.badGauge = badGauge;
		stateControl.goodGauge = goodGauge;
		stateControl.currentGnome = currentGnome;
		stateControl.currentGnomeNumber = currentGnomeNumber;
		stateControl.playerPosition = playerPosition;
		stateControl.Save ();
	}

	public void LoadGame (){
		SceneManager.LoadScene (1);
		stateControl.Load ();
	}

	public void ExitToMenu(){
		Time.timeScale = 1;
		pauseMenu.enabled = false;
		body.GetComponent<FirstPersonController> ().enabled = true;
		SceneManager.UnloadScene (1);
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}
}
