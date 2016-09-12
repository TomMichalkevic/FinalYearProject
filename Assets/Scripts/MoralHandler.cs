using UnityEngine;
using System.Collections;

public class MoralHandler : MonoBehaviour {

	private GaugeHandler gaugeHandler;
	public int p;
	private WindZone weatherComponent;
	private DayNightCycle sunScript;
	public GameObject snow;
	private AudioSource terrainAudio;
	private AudioClip level1;
	private AudioClip level2;
	private AudioClip level3;
	private AudioClip level4;

	// Use this for initialization
	void Start () {
		gaugeHandler = GameObject.FindGameObjectWithTag ("Player").GetComponent<GaugeHandler> ();
		weatherComponent = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<WindZone> ();
		sunScript = GameObject.FindGameObjectWithTag ("Sun").GetComponent<DayNightCycle> ();
		terrainAudio = GameObject.FindGameObjectWithTag ("Terrain").GetComponent<AudioSource> ();
		level1 = (AudioClip)Resources.Load("Audio/221758__motion-s__ambient-forest-birds"); //Downloaded from https://www.freesound.org/people/Motion_S/sounds/221758/ on 12/09/2016, Royalty Free License
		level2 = (AudioClip)Resources.Load("Audio/68068__rogerforeman__coyote2"); //Downloaded from https://www.freesound.org/people/rogerforeman/sounds/68068/ on 12/09/2016, Royalty Free License
		level3 = (AudioClip)Resources.Load("Audio/138430__henrythetrain__air-rush-longer"); //Downloaded from https://www.freesound.org/people/Henrythetrain/sounds/138430/ on 12/09/2016
		level4 = (AudioClip)Resources.Load("Audio/338134__spectre-of-pain__world-of-the-damned-souls"); //Downloaded from https://www.freesound.org/people/Spectre_of_Pain/sounds/338134/ on 12/09/2016, Royalty Free License

		terrainAudio.clip = level1;
		terrainAudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		adjustWeather ();
		adjustLighting ();
		//adjustMusic ();
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

	//Adjust weather based on moral the value in the gauge
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

	//Adjust lighting based on the value in the gauge
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

	//Adjust background music based on value in the gauge
	public void adjustMusic(){
		if (gaugeHandler.badGauge.value < 0.2) {
			ChangeToLevel1 ();
		} else if (gaugeHandler.badGauge.value > 0.2 && gaugeHandler.badGauge.value < 0.5) {
			ChangeToLevel2 ();
		} else if (gaugeHandler.badGauge.value > 0.5 && gaugeHandler.badGauge.value < 0.7) {
			ChangeToLevel3 ();
		} else {
			ChangeToLevel4 ();
		}
	}

	void ChangeToLevel1(){
		terrainAudio.clip = level1;
		terrainAudio.Play ();
	}

	void ChangeToLevel2(){
		terrainAudio.clip = level2;
		terrainAudio.Play ();
	}

	void ChangeToLevel3(){
		terrainAudio.clip = level3;
		terrainAudio.Play ();
	}

	void ChangeToLevel4(){
		terrainAudio.clip = level4;
		terrainAudio.Play ();
	}
}
