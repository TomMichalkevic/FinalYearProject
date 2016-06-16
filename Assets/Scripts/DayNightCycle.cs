﻿using UnityEngine;
using System.Collections;
// http://twiik.net/articles/simplest-possible-day-night-cycle-in-unity-5
public class DayNightCycle : MonoBehaviour {

	public Light sun;
	public float fullDayInSeconds;
	[Range(0,1)]
	public float currentTime = 0;
	public float timeMultiplier = 1f;

	float sunInitialIntensity;

	void Start() {
		sunInitialIntensity = sun.intensity;
	}

	void Update() {
		UpdateSun();

		currentTime += (Time.deltaTime / fullDayInSeconds) * timeMultiplier;

		if (currentTime >= 1) {
			currentTime = 0;
		}
	}

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
