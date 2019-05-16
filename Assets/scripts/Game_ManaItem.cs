using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game_ManaItem : MonoBehaviour {

	public Image manaImage;

	void Start() {
		//manaImage = GetComponent<Image> ();

	}

	public void setDisabled() {
		manaImage.color = Color.red;

	}

	public void setEnabled() {
		manaImage.color = Color.blue;
	}

	public void setSelected() {
		manaImage.color = Color.white;
	}

}
