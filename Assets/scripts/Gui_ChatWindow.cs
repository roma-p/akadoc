using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gui_ChatWindow : MonoBehaviour {

	public Text text_chat;
	public ScrollRect scrollrect;

	string message_old;

	// Use this for initialization
	void Start() {
		text_chat.text = "";


	}

	// Update is called once per frame
	void Update() {
	}



	//permet d'écrire du texte en brut dans la fenetre de chat. Sans style. A priori, ne doit pas etre utilisé...
	public void writeText(string text) {

		text_chat.text += text;

	}

	//prend en arguement le nombre de jour écoulé pour l'afficher dans la fenetre de chat.
	public void writeDay(int nbDay) {

		text_chat.text += "\n\n\n  <b><color=#000080ff>Day " + nbDay.ToString() + "\n</color></b>" ;
		scrollrect.verticalNormalizedPosition = 0;

	}

	//prend en argument le pseudo et le message reçu par TchatAnim.cs et l'inscrit dans la fenetre.
	public void writeMessage(string nom, string message) {

		text_chat.text += "<color=#0000ffff>" + nom + ": </color>"+ message + "\n";
		scrollrect.verticalNormalizedPosition = 0;

	}

	// TODO: rédiger des fonctions pour afficher les morts, les deconnections et certains évènement importants.

}
