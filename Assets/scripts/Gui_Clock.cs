using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gui_Clock : MonoBehaviour {

	public GameObject clock;
	GameObject day_controller;
	Gui_DayController daycontroller;
	int maxDay;
	int maxNight;


	// Use this for initialization
	void Start() {
		day_controller = GameObject.Find("day_controller");
		daycontroller = day_controller.GetComponent<Gui_DayController> ();

		maxDay = daycontroller.maxDay;
		maxNight = daycontroller.maxNight;
	}

	// Update is called once per frame
	void Update() {
		//TODO: Sync clock with the server
		//TODO: Set var as for day % or hour

		float fRot = clock.transform.rotation.eulerAngles.z;

		if(fRot>=180) {
			clock.transform.Rotate(0, 0, (float)(Time.deltaTime * (-180.0)/maxNight));//2.5min
		}
		else {
			clock.transform.Rotate(0, 0, (float)(Time.deltaTime * (-180.0)/maxDay));//1min
		}
	}
}
