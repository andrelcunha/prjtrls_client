using System;
using UnityEngine;
using Trilhas.Components.Estatistics;
using System.Linq;
using Trilhas.JsonFormat;



namespace Trilhas.Controller
{
	public class MissionDisplayController:MonoBehaviour
    {
		[SerializeField] GameObject _missionEntryPrefab;
		private UserController _userController;
		[SerializeField] 
		MissaoUsuario[] Missions;


		void Start()
        {
            _userController = UserController.Instance;
			Missions = _userController.Missions
			                          .Where((arg) => arg.obrigatorio)
			                          .ToArray();
			                          
                                          
			foreach(var mission in Missions)
			{
				CreateMissionEntry(mission);
			}
            
            //Mission = _userController.Missions
            //                         .First((arg) => arg.aprovada);
        }

		void CreateMissionEntry(MissaoUsuario mission)
		{
			GameObject go = Instantiate(_missionEntryPrefab);
			var tmp = go.GetComponent<MissionDisplay>();
			tmp.Mission = mission;
			tmp.name = mission.codigo;
			tmp.transform.SetParent(gameObject.transform);
			tmp.transform.localEulerAngles = new Vector3(0, 0, 0);
			tmp.transform.localScale = new Vector3(1, 1, 1);

		}
    }
}
