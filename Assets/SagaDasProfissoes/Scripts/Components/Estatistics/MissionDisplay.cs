using System;
using UnityEngine;
using Trilhas.JsonFormat;
using TMPro;
using Trilhas.Controller;
using System.Linq;
using UnityEngine.UI;

namespace Trilhas.Components.Estatistics
{
	public class MissionDisplay:MonoBehaviour
    {
		[SerializeField] MissaoUsuario _missao;
		[SerializeField] TextMeshProUGUI _missionTitleTMPro;
		[SerializeField] Image _checkMark;
        
		private UserController _userController;

        #region Properties

		public MissaoUsuario Mission
		{
			get
			{
				return _missao;
			}

			set
			{
				_missao = value;
				IsDone = _missao.aprovada;
				MissionTitle = Mission.titulo;
			}
		}

		public bool IsDone
		{
			get
			{
				return Mission.aprovada;
			}

			set
			{
				_checkMark.enabled = value;
			}
		}

		public String MissionTitle
		{
			get
			{
				return _missao.titulo;
			}

			set
			{
				_missionTitleTMPro.text = String.Format("MISSÃO: <b>{0}</b>" ,value);
			}
		}
  
		#endregion
  
    }
}
