using UnityEngine;
using System.Collections;

public class Game_Player : MonoBehaviour {

	void Awake(){
		//Debug
		SetCharacter(charID);
		SetRole(roleID);
		Game.Get().SetMainPlayer(this);
	}


	public void DebugInfo() {
		Debug.Log(charname+" is a "+Rdb.GetStrRef(rolename_strref)+" with "+hp.ToString()+" hit points");
	}

	void SetCharacter(int _charID){
		charID = _charID;

		var ct = Rdb.GetTable("characters");
		charname = ct.GetValue<string>(charID, "name");
		spellID = ct.GetValue<int>(charID, "spell");
		hp = ct.GetValue<int>(charID, "hp");
	}

	void SetRole(int _roleID){
		roleID = _roleID;

		var rt = Rdb.GetTable("roles");
		rolename_strref = rt.GetValue<int>(roleID, "name_strref");
		ultiID = rt.GetValue<int>(roleID, "ulti");
		align = rt.GetValue<string>(roleID, "alignment");
	}

	public int charID;
	public string charname;
	public int spellID;
	public int hp;

	public int roleID;
	public int rolename_strref;
	public int ultiID;
	public string align;
}
