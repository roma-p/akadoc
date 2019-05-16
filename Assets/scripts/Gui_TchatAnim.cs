using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gui_TchatAnim : MonoBehaviour {

	public Animator machine;
	public Text charac_nb;
	public InputField myfield;
	public Text timer;
	public Image img_bg;
	float timer_sec;
	int max_timer;
	public string message;

	//appel de WindowChat
	GameObject chatWindowScroll;
	Gui_ChatWindow chatWindow;

	//appel de TchatAnim
	GameObject createScrollListObject;
	Gui_CreateScrollList createScrollList;

	// Use this for initialization
	void Start() {
		timer_sec = 0;
		max_timer = 15;

		//appel de WindowChat
		chatWindowScroll = GameObject.Find("ChatWindowScroll");
		chatWindow = chatWindowScroll.GetComponent<Gui_ChatWindow> ();

		//appel de CreateScrollList
		createScrollListObject = GameObject.Find("log_controller");
		createScrollList = createScrollListObject.GetComponent<Gui_CreateScrollList> ();

	}


	void Awake() {

	}


	// Update is called once per frame

	void Update() {


		//print (machine.GetInteger("etat_chat"));
		if(myfield.isFocused) {
			img_bg.color = Color.green;
		} else
			img_bg.color = Color.white;

		if(machine.GetInteger("etat_chat") == 0) {
			myfield.gameObject.SetActive(true);
			message = myfield.text;

		}

		//transition vers chat_up
		if(myfield.textComponent.cachedTextGenerator.lineCount > 1 &&  machine.GetInteger("etat_chat") == 0) {
			print("trop long");
			machine.SetInteger("etat_chat", 1);
			charac_nb.text = " ";
			message = myfield.text;

		}

		//transition vers chat_long
		if(myfield.text.Length > 110 &&  machine.GetInteger("etat_chat") == 1) {
			print("trop trop long");
			machine.SetInteger("etat_chat", 2);
			message = myfield.text;
		}


		//affichage nombre de caractère restant.
		if(Input.anyKey && machine.GetInteger("etat_chat") == 2) {
			charac_nb.text = (myfield.characterLimit - myfield.text.Length).ToString();
		}

		//les derniers caractères sont écris en rouges
		if(myfield.text.Length > 130) {
			charac_nb.color = Color.red;
		} else
			charac_nb.color = Color.white;

		//transition vers chat_empty: si l'on vide complètement un message, le tcht se rabaisse.
		//sinon on le laisse haut (y compris si le message est court).
		if((machine.GetInteger("etat_chat") == 1 || machine.GetInteger("etat_chat") == 2) && myfield.text.Length == 0) {

			machine.SetInteger("etat_chat", 0);
			message = "";
		}


		//En cas de validation du message
		if(Input.GetKeyDown("return") && myfield.isFocused) {

			chatWindow.writeMessage("perceval", myfield.text); //inscription du message dans la fenetre de chat
			createScrollList.writeMessage("perceval", myfield.text); //inscription du message dans les logs.
			myfield.gameObject.SetActive(false);
			myfield.text = " ";
			charac_nb.text = "";
			print("space pressed");

			//texte long
			if(machine.GetInteger("etat_chat") == 1 || machine.GetInteger("etat_chat") == 2) {
				machine.SetInteger("etat_chat", 3);
			}

			//texte court
			if(machine.GetInteger("etat_chat") == 0) {
				machine.SetInteger("etat_chat", 3);
			}

		}

		//Gestion de l'état Timer.
		if(machine.GetInteger("etat_chat") == 3) {


			timer_sec += Time.deltaTime;
			timer.text = (max_timer - (int) timer_sec).ToString() + " secondes restantes";

			if(timer_sec >= (float)max_timer - 1) {
				timer_sec = 0;
				timer.text = "";
				machine.SetInteger("etat_chat", 0);
				myfield.text = "";
				message = "";

			}

		}

	}

	public void submit() {
		print("submit entered");
	}

}
