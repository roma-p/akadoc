using UnityEngine;
using System.IO;

public class Game {

	public void SetMainPlayer(Game_Player p){
		m_mainPlayer = p;
	}


	public Game_Player GetMainPlayer(){
		return m_mainPlayer;
	}




	public static Game Get() {
		lock(m_singlmutex) {
			if(m_inst==null)
				m_inst = new Game();
		}
		return m_inst;
	}
	private Game() {

	}


	private static Game m_inst = null;
	private static object m_singlmutex = new Object();


	private Game_Player m_mainPlayer = null;
	


}