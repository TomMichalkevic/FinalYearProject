using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

//https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data was the tutorial used in this class

public class GameStateControl : MonoBehaviour{

	public static GameStateControl stateControl;

	public float badGauge;
	public float goodGauge;
	public int currentGnomeNumber;

	void Awake(){
		if (stateControl == null) {
			DontDestroyOnLoad (gameObject);
			stateControl = this;
		} else if (stateControl != this) {
			Destroy (gameObject);
		}
	}

	// Saving mechanism
	public void Save(){
		BinaryFormatter formatter = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/finalYearProject.dat");
		GameStateData data = new GameStateData ();
		data.badGauge = badGauge;
		data.goodGauge = goodGauge;
		data.currentGnomeNumber = currentGnomeNumber;

		formatter.Serialize (file, data);
		file.Close();
		Debug.Log ("Data saved");
	}

	// Loading mechanism
	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/finalYearProject.dat")){
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/finalYearProject.dat", FileMode.Open);
			GameStateData data = (GameStateData)formatter.Deserialize (file);
			file.Close ();

			goodGauge = data.goodGauge;
			badGauge = data.badGauge;
			currentGnomeNumber = data.currentGnomeNumber;

			Debug.Log ("Data Loaded");
		}
	}
}

[Serializable]
class GameStateData{
	public float badGauge;
	public float goodGauge;
	public int currentGnomeNumber;
}