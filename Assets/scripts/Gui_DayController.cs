using UnityEngine;
using System.Collections;

public class Gui_DayController : MonoBehaviour {

	public Animator machine;
	public int maxDay;
	public int maxNight;
	public int maxKilling;

	float timer;
	int maxDiscussion;
	int maxAccusation;
	int dayNb;

	//appel de Window Chat
	GameObject chatWindowScroll;
	Gui_ChatWindow chatWindow;

	//appel de CreateScrollList
	GameObject createScrollListObject;
	Gui_CreateScrollList createScrollList;

	//appel de ManaStack
	GameObject manaStackObject;
	Game_ManaStack manaStack;


	// Use this for initialization
	void Start() {

		//calcul des différent timing.
		machine.SetInteger("day_status", 0);
		maxDiscussion = (int) maxDay / 2;
		maxAccusation = maxDay - maxDiscussion;

		//appel de Window Chat
		chatWindowScroll = GameObject.Find("ChatWindowScroll");
		chatWindow = chatWindowScroll.GetComponent<Gui_ChatWindow> ();

		//appel de CreateScrollList
		createScrollListObject = GameObject.Find("log_controller");
		createScrollList = createScrollListObject.GetComponent<Gui_CreateScrollList> ();

		//appel de ManaStack
		manaStackObject = GameObject.Find("mana_controller");
		manaStack = manaStackObject.GetComponent<Game_ManaStack> ();

		dayNb = 1;
		chatWindow.writeDay(dayNb);
		manaStack.addDaily(dayNb);

	}

	// Update is called once per frame
	void Update() {

		//DISUCSSION
		if(machine.GetInteger("day_status") == 0) {


			if(timer >= (float)maxDiscussion) {
				machine.SetInteger("day_status", 1);
				print("Accusation!");
				createScrollList.writeNotification("Denoncez-vous, pauvres fous!!!");
			}

			else {
				timer += Time.deltaTime;
			}

		}

		//ACCUSATION
		if(machine.GetInteger("day_status") == 1) {


			if(timer >= (float)maxDay) {
				machine.SetInteger("day_status", 3);
				print("il fait nuit!");
				timer = 0;
			}

			else {
				timer += Time.deltaTime;
			}

		}

		//NUIT
		if(machine.GetInteger("day_status") == 3) {


			if(timer >= (float)maxNight) {
				machine.SetInteger("day_status", 0);
				timer = 0;
				dayNb ++;

				chatWindow.writeDay(dayNb);
				manaStack.addDaily(dayNb);
				print("le jour se lève, discutez!");

			}

			else {
				timer += Time.deltaTime;
			}

		}



	}


	public int getDay() {return dayNb;}
}
