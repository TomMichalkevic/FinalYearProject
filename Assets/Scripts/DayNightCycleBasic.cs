using UnityEngine;
using System.Collections;

public class DayNightCycleBasic : MonoBehaviour {

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

}
