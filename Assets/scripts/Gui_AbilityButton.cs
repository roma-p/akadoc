using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Gui_AbilityButton : MonoBehaviour{
	public enum AbilityType{
		Spell, Ultimate
	}

	public AbilityType type;

	void Awake(){
		button = GetComponent<Button>();
		icon = GetComponent<Image>();
		name = GetComponentInChildren<Text>();
	}

	void Start(){
		switch(type){
			case AbilityType.Spell:
				SetAbilityID(Game.Get().GetMainPlayer().spellID);
				break;
			case AbilityType.Ultimate:
				SetAbilityID(Game.Get().GetMainPlayer().ultiID);
				break;
		}
	}

	void SetAbilityID(int _abilityID){
		abilityID = _abilityID;

		//Set image, callback
		var st = Rdb.GetTable("abilities");

		//Set icon
		string sIcon = st.GetValue<string>(abilityID, "icon");
		var iconImage = Resources.Load<Sprite>(sIcon);
		if(iconImage==null){
			Debug.LogWarning("Could not open "+sIcon);
		}
		else
			icon.sprite = iconImage;

		//Set name
		name.text = Rdb.GetStrRef(st.GetValue<int>(abilityID, "name_strref"));

		//Execute script
		button.onClick.AddListener(()=>{
			Debug.Log("Clicked");
		});

	}

	private int abilityID;

	private Button button;
	private Image icon;
	private Text name;

}

