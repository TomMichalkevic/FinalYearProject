using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//http://www.thegamecontriver.com/2014/08/unity-46-create-health-bar-hud.html is the tutorial used in this class

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

	// Add to the bad gauge
	public void AddToBad(int points){
		badGauge.value = (float)(badGauge.value + points * multiplier);
		//Debug.Log ("Was here");
	}

	// Add to the good gauge
	public void AddToGood(int points){
		goodGauge.value = (float)(goodGauge.value + points * multiplier);
	}

	// Deduct from the good gauge
	public void DeductFromGood(int points){
		goodGauge.value = (float)(goodGauge.value - points * multiplier);
	}

	// Deduct from the bad gauge
	public void DeductFromBad(int points){
		badGauge.value = (float)(badGauge.value - points * multiplier);
	}

	// Set the bad gauge
	public void SetBadGauge(float value){
		badGauge.value = value;
	}

	// Set the good gauge
	public void SetGoodGauge(float value){
		goodGauge.value = value;
	}
}
