using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class Item {
	public string name;
	public Sprite icon;
	public string message;
	Button.ButtonClickedEvent clickEvent;
}

[System.Serializable]
public class Notification {
	public string message;
	Button.ButtonClickedEvent clickEvent;
}

public class Gui_CreateScrollList : MonoBehaviour {

	public GameObject sampleButton;
	public List<Item> itemList;
	public Transform contentPanel;
	public Image portrait;
	public ScrollRect scrollrect;
	//public InputField myfield;
	GameObject chat_input;
	Gui_TchatAnim tchatAnim;
	string message_old;

	//tentative d'ajout des notifications:
	public GameObject logNotification;
	public List<Notification> notificationList;

	// Use this for initialization
	void Start() {
		//PopulateList ();
		chat_input = GameObject.Find("tchat_complet");
		tchatAnim = chat_input.GetComponent<Gui_TchatAnim> ();


	}

	void PopulateList() {
		foreach(var item in itemList) {
			GameObject newButton = Instantiate(sampleButton) as GameObject;
			Gui_SampleButton button = newButton.GetComponent <Gui_SampleButton> ();
			button.nameLabel.text = item.name;
			button.icon.sprite = item.icon;
			button.message.text = item.message;
			newButton.transform.SetParent(contentPanel);
			button.gameObject.SetActive(true);

		}

	}


	// Update is called once per frame
	void Update() {

	}

	public void writeMessage(string name, string message) {

		scrollrect.verticalNormalizedPosition = 0;
		GameObject myNewButton = Instantiate(sampleButton) as GameObject;
		Gui_SampleButton button = myNewButton.GetComponent<Gui_SampleButton> ();
		button.nameLabel.text = name;
		button.message.text = tchatAnim.message;
		button.icon.sprite = portrait.sprite;
		button.gameObject.SetActive(true);
		myNewButton.transform.SetParent(contentPanel);

	}

	public void writeNotification(string message) {

		scrollrect.verticalNormalizedPosition = 0;
		GameObject myNewButton = Instantiate(logNotification) as GameObject;
		Gui_LogNotification notif = myNewButton.GetComponent<Gui_LogNotification> ();
		notif.message.text = message;
		myNewButton.transform.SetParent(contentPanel);
	}
}
