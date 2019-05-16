//The object must have a collider

using UnityEngine;
using System.Collections;

public class Gui_OnClickedMoveCamera : MonoBehaviour {

	public Transform destination;
	public Gui_CameraController camCtrl;

	private Color clrBase;
	private Color clrTarget;
	private Renderer[] children;
	public Canvas canva;

	void Awake() {
		clrBase = GetComponent<Renderer>().material.color;
		clrTarget = clrBase;
		children = GetComponentsInChildren<Renderer>();
		//canva = destination.GetComponentInChildren (Canvas);
	}


	void OnMouseDown() {
		//Move to position



		camCtrl.targetPos = destination.position;
		camCtrl.targetRot = destination.rotation;
	}

	void OnMouseEnter() {
		//Lerp to hilight color
		clrTarget = new Color(1.0F, 0.87F, 0.75F);
	}

	void OnMouseExit() {
		//Lerp to base color
		clrTarget = clrBase;
	}

	void Update() {
		//Lerp to clrTarget
		Color clr = Color.Lerp(GetComponent<Renderer>().material.color, clrTarget, Time.deltaTime * 10);

		//Fixme? Any newly created chilren wont be lerped
		foreach(Renderer child in children) {
			child.material.color = clr;
		}
	}
}
