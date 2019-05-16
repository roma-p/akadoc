
using System.Collections.Generic;

namespace Databind{


	interface Slave{
		void OnMasterUpdated();
	}

	class Master{
		void Register(Slave s){
			m_slaves.Add(s);
		}
		void Unregister(Slave s){
			m_slaves.Remove(s);
		}
		void Clear(){
			m_slaves.Clear();
		}

		void Update(){
			foreach(var s in m_slaves){
				s.OnMasterUpdated();
			}
		}


		private List<Slave> m_slaves = new List<Slave>();
	}


}