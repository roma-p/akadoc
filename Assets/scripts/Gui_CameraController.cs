using UnityEngine;
using System.Collections;

public class Gui_CameraController : MonoBehaviour {

	public Vector3 targetPos;
	public Quaternion targetRot;
	public Transform initLocation;

	// Use this for initialization
	void Awake() {
		transform.position = initLocation.position;
		transform.rotation = initLocation.rotation;

		targetPos = transform.position;
		targetRot = transform.rotation;
	}

	// Update is called once per frame
	void Update() {
		transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*10);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime*10);
	}

	private	GameObject[] cameraPosList;
}
