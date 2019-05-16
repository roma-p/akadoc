using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Gui_ChatScrollbar : MonoBehaviour {

	public Scrollbar scrollbar;
	public InputField myfield;
	public ScrollRect scrollrect;


	// Use this for initialization
	void Start() {
		scrollbar.value = 1;

	}



	// Update is called once per frame
	void Update() {



		//print (iseditingtop);

	}





	bool isTypingText() {
		if(Input.anyKey && Input.GetMouseButton(0) == false && Input.GetMouseButton(1) == false && Input.GetMouseButton(2) == false && Input.GetKey("return") == false) {
			return true;
		} else
			return false;
	}


}
