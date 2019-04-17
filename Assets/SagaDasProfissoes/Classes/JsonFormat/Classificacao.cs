using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Classificacao
	{
		public string token;
		public int minhacolocacao;
		public int minhapontuacao;
		public List<EixoPonto> eixos;
		public List<Ranking> ostop;
	}
}