using System.Collections;
using System.Collections.Generic;
using Trilhas.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Trilhas.Tutorials
{
	public class MissionTutorialController : MonoBehaviour
	{
		[SerializeField] Text _nome;
		[SerializeField] Text _colegio;
		[SerializeField] Text _serie;
		[SerializeField] Button _okButton;
		private UserController _userController;

        void Start()
		{
			_userController = UserController.Instance;
        }

        public void ConfirmData()
		{
			_userController.SetTutorialMissionOk(true);
		}
	}
}