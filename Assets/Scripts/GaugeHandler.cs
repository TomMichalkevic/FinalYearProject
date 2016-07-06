using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//http://www.thegamecontriver.com/2014/08/unity-46-create-health-bar-hud.html

public class GaugeHandler : MonoBehaviour {

	public Slider goodGauge;
	public Slider badGauge;

	// Use this for initialization
	void Start () {
		goodGauge.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
