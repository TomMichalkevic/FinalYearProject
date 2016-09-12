using UnityEngine;
using System.Collections;
// http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5
public class DayNightCycle : MonoBehaviour {

	public Light sun;
	public float fullDayInSeconds;
	[Range(0,1)]
	public float currentTime = 0;
	public float timeMultiplier = 1f;

	[Header("Current color of the directional light in RGB")]
	public float compR;
	public float compG;
	public float compB;
	[Space(20)]

	float sunInitialIntensity;

	void Start() {
		sunInitialIntensity = sun.intensity;
		compR = sun.color.r;
		compG = sun.color.g;
		compB = sun.color.b;
	}

	// Update the timing
	void Update() {
		UpdateSun();

		currentTime += (Time.deltaTime / fullDayInSeconds) * timeMultiplier;

		if (currentTime >= 1) {
			currentTime = 0;
		}
	}

	// Update the sun's position
	void UpdateSun() {
		sun.transform.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 170, 0);

		float intensityMultiplier = 1;
		if (currentTime <= 0.23f || currentTime >= 0.75f) {
			intensityMultiplier = 0;
		}
		else if (currentTime <= 0.25f) {
			intensityMultiplier = Mathf.Clamp01((currentTime - 0.23f) * (1 / 0.02f));
		}
		else if (currentTime >= 0.73f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
		}

		sun.intensity = sunInitialIntensity * intensityMultiplier;
	}

	// Change the colour of the sun
	public void ChangeSunColor(int option){
		switch (option) {
		case 1:
			sun.color = Color.yellow;
			break;
		case 2:
			sun.color = Color.green;
			break;
		case 3:
			sun.color = Color.gray;
			break;
		case 4:
			sun.color = Color.black;
			break;
		}
	}
}
