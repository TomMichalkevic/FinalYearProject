using UnityEngine;
using System.Collections;

public class MoralHandler : MonoBehaviour {

	public static MoralHandler moralHandler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void adjustGauges(int points){
		if (points < 0) {
			GaugeHandler.gaugeHandler.AddToBad (points);
			GaugeHandler.gaugeHandler.DeductFromGood (points);
		}else if(points>0){
			GaugeHandler.gaugeHandler.DeductFromBad (points);
			GaugeHandler.gaugeHandler.AddToGood (points);
		}
	}

	public void adjustLighting(){}

	public void adjustMonsters(){}
}
