using System;
using UnityEngine;
using _2MuchPines.Templates;
using System.Linq;
using Trilhas.JsonFormat;
using TMPro;

namespace Trilhas.Controller
{
	public class ScoreSummaryController :MonoBehaviour
    {
		[SerializeField] TextMeshProUGUI[] _scoreTMPro;
		private int[] scores;
		private UserController userController;

        #region Properties
        public int ScoreEng
        {
            get
            {
                EixoNome eixo = EixoNome.ENGENHARIA;
                return scores[(int)eixo];
            }

        }

        public int ScoreHum
        {
            get
            {
                EixoNome eixo = EixoNome.HUMANAS;
				return scores[(int)eixo];
            }
        }
        public int ScoreNeg
        {
            get
            {
                EixoNome eixo = EixoNome.NEGOCIOS;
				return scores[(int)eixo];
            }
        }

        public int ScoreSau
        {
            get
            {
                EixoNome eixo = EixoNome.SAUDE;
				return scores[(int)eixo];
            }
        }            

        
        #endregion


        void Start()
        {
			userController = UserController.Instance;
			scores = userController.Eixos;
			//scores = new int[]{ 10, 20, 30, 40};
			UpdateScorePanel();
        }
  
        private void UpdateScorePanel()
        {
            _scoreTMPro[(int)EixoNome.ENGENHARIA].text = ScoreEng.ToString();
            _scoreTMPro[(int)EixoNome.HUMANAS].text = ScoreHum.ToString();
            _scoreTMPro[(int)EixoNome.NEGOCIOS].text = ScoreNeg.ToString();
            _scoreTMPro[(int)EixoNome.SAUDE].text = ScoreSau.ToString();
        }
        


    }
}
