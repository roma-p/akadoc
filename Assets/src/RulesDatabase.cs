using UnityEngine;
using System.IO;
using System.Collections.Generic;

//RulesDatabase
public class Rdb {

	public static TwoDA GetTable(string name) {
		TwoDA t = null;
		if(Get().m_tables.TryGetValue(name, out t)) {
			return t;
		}
		else
			return null;
	}

	public static void SetLocale(string lang) {
		Get().m_strref = GetTable("locale_"+lang);
	}

	public static string GetStrRef(int strref) {
		return Get().m_strref.GetValue<string>(strref, "text");
	}





	private Rdb() {
		m_tables = new Dictionary<string, TwoDA>();

		string[] files = Directory.GetFiles(m_folder, "*.2da", SearchOption.AllDirectories);

		foreach(string file in files) {
			string name = Path.GetFileNameWithoutExtension(file);
			m_tables.Add(name, new TwoDA(file));
			//Debug.Log ("Found "+name);
		}

		//Set default locale table
		m_tables.TryGetValue("locale_fr", out m_strref);
	}


	private static Rdb m_inst = null;
	private static object m_singlmutex = new Object();
	private static Rdb Get() {
		lock(m_singlmutex) {
			if(m_inst==null)
				m_inst = new Rdb();
		}
		return m_inst;
	}

	private Dictionary<string, TwoDA> m_tables;
	private TwoDA m_strref = null;
	private string m_folder = "Assets/rules";


}