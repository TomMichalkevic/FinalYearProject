using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;

//https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data

public class GameStateControl : MonoBehaviour{

	public static GameStateControl stateControl;

	public float health;
	public float badGauge;
	public float goodGauge;

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
		data.health = health;
		data.badGauge = badGauge;
		data.goodGauge = goodGauge;

		formatter.Serialize (file, data);
		file.Close();
	}

	public void Load(){
		if(File.Exists(Application.persistentDataPath + "/finalYearProject.dat")){
			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/finalYearProject.dat", FileMode.Open);
			GameStateData data = (GameStateData)formatter.Deserialize (file);
			file.Close ();

			health = data.health;
			goodGauge = data.goodGauge;
			badGauge = data.badGauge;
		}
	}
}

[Serializable]
class GameStateData{
	public float health;
	public float badGauge;
	public float goodGauge;
}