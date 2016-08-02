using UnityEngine;
using System.Collections;

public class MoralHandler : MonoBehaviour {

	private GaugeHandler gaugeHandler;
	public int p;
	private WindZone weatherComponent;
	private DayNightCycle sunScript;
	public GameObject snow;

	// Use this for initialization
	void Start () {
		gaugeHandler = GameObject.FindGameObjectWithTag ("Player").GetComponent<GaugeHandler> ();
		weatherComponent = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<WindZone> ();
		sunScript = GameObject.FindGameObjectWithTag ("Sun").GetComponent<DayNightCycle> ();
		//snow = GameObject.FindGameObjectWithTag ("Snow");
	}
	
	// Update is called once per frame
	void Update () {
		adjustWeather ();
		adjustLighting ();
	}

	public void adjustGauges(int points){
		Debug.Log (points);
		p = points;
		points = Mathf.Abs (points);
		if (p == -1) {
			Debug.Log("Adding to bad");
			gaugeHandler.AddToBad (points);
			gaugeHandler.DeductFromGood (points);
		}else if(p == 1){
			gaugeHandler.DeductFromBad (points);
			gaugeHandler.AddToGood (points);
		}
	}

	public void adjustWeather(){
		if (gaugeHandler.badGauge.value > 0.5) {
			weatherComponent.windMain = 1;
		} else {
			weatherComponent.windMain = 0;
		}
		if (gaugeHandler.badGauge.value > 0.7 && gaugeHandler.badGauge.value < 0.9) {
			weatherComponent.windTurbulence = 5;
		} else if (gaugeHandler.badGauge.value > 0.9) {
			weatherComponent.windTurbulence = 10;
		} else {
			weatherComponent.windTurbulence = 1;
		}
		if (gaugeHandler.badGauge.value > 0.5) {
			snow.SetActive (true);
		} else {
			snow.SetActive (false);
		}
	}

	public void adjustLighting(){
		if (gaugeHandler.badGauge.value < 0.4) {
			sunScript.ChangeSunColor (1);
		}else if (gaugeHandler.badGauge.value > 0.4 && gaugeHandler.badGauge.value < 0.6) {
			sunScript.ChangeSunColor (2);
		} else if (gaugeHandler.badGauge.value > 0.6 && gaugeHandler.badGauge.value<0.8) {
			sunScript.ChangeSunColor (3);
		} else {
			sunScript.ChangeSunColor (4);
		}
	}

	public void adjustMonsters(){}
}
