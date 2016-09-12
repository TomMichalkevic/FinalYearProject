using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//http://www.thegamecontriver.com/2014/08/unity-46-create-health-bar-hud.html

public class GaugeHandler : MonoBehaviour {

	public Slider goodGauge;
	public Slider badGauge;
	public float multiplier;

	public static GaugeHandler gaugeHandler;

	// Use this for initialization
	void Start () {
		goodGauge.value = 1;
		badGauge.value = 0;
		multiplier = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddToBad(int points){
		badGauge.value = (float)(badGauge.value + points * multiplier);
		//Debug.Log ("Was here");
	}

	public void AddToGood(int points){
		goodGauge.value = (float)(goodGauge.value + points * multiplier);
	}

	public void DeductFromGood(int points){
		goodGauge.value = (float)(goodGauge.value - points * multiplier);
	}

	public void DeductFromBad(int points){
		badGauge.value = (float)(badGauge.value - points * multiplier);
	}

	public void SetBadGauge(int value){
		badGauge.value = value;
	}

	public void SetGoodGauge(int value){
		goodGauge.value = value;
	}
}
