using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

//https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data

public class GameStateControl : MonoBehaviour{

	public static GameStateControl stateControl;

	public float badGauge;
	public float goodGauge;
	public GameObject currentGnome;
	public int currentGnomeNumber;
	public Vector3 playerPosition;

	void Awake(){
		if (stateControl == null) {
			DontDestroyOnLoad (gameObject);
			stateControl = this;
		} else if (stateControl != this) {
			Destroy (gameObject);
		}
	}

	public void Save(){
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/finalYearProject.dat");
		GameStateData data = new GameStateData ();
		data.badGauge = badGauge;
		data.goodGauge = goodGauge;

		formatter.Serialize (file, data);
		file.Close();
		Debug.Log ("Data saved");
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/finalYearProject.dat")){
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/finalYearProject.dat", FileMode.Open);
			GameStateData data = (GameStateData)formatter.Deserialize (file);
			file.Close ();

			goodGauge = data.goodGauge;
			badGauge = data.badGauge;
			currentGnome = data.currentGnome;
			currentGnomeNumber = data.currentGnomeNumber;
			playerPosition = data.playerPosition;
			Debug.Log ("Data Loaded");
		}
	}
}

[Serializable]
class GameStateData{
	public float badGauge;
	public float goodGauge;
	public GameObject currentGnome;
	public int currentGnomeNumber;
	public Vector3 playerPosition;
}