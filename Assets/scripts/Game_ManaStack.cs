using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class Game_ManaStack : MonoBehaviour {

	public GameObject manaItem;
	public Transform contentPanel;
	public int manaMax;
	int manaLeft;

	// Use this for initialization
	void Start() {
		//création de la barre de mana.
		for(int i = 0; i < manaMax; i++) {
			createMana();
			GameObject.Find("ManaItem(Clone)").name = "ManaItem" + i;
			//GameObject.Find("ManaItem"+i).GetComponent("ManaItem").setDisabled();
		}
	}

	public int getMana() {return manaLeft;}

	//crée un cristaux de mana. (appelée dix fois lors de la fonction Start).
	void createMana() {
		GameObject myNewButton = Instantiate(manaItem) as GameObject;
		Game_ManaItem mana = myNewButton.GetComponent<Game_ManaItem> ();
		mana.setDisabled();
		myNewButton.transform.SetParent(contentPanel);
	}


	//ajoute le bon nombre de cristaux de mana chaque jour
	public void addDaily(int nbDay) {
		nbDay--;
		GameObject manaItemObject;
		Game_ManaItem manaButton;

		if(nbDay > manaMax - 1) {
			nbDay = manaMax - 1;
		}

		manaLeft = nbDay + 1;

		for(int i = 0; i <= nbDay; i++) {
			manaItemObject = GameObject.Find("ManaItem" + i);
			manaButton = manaItemObject.GetComponent<Game_ManaItem> ();
			manaButton.setEnabled();
			//GameObject.Find("ManaItem"+i).GetComponent("Button").int
		}
	}

	//ajoute la quantité de mana indiqué.
	public void addMana(int manaPlus) {
	}

	//soustrait la quantité de mana indiqué.
	public void subMana(int manaLess) {
	}

	//selectionne la quantité de mana indiqué
	//(quand on passe la souris sur un sort par exemple)
	public void selMana(int sel) {
	}

}
