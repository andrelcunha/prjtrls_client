using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Missao
	{
		public string token;
		public string codigo;
		public int ano;
		public int semestre;
		public int sequencia;
		public string titulo;
		public string descricao;
		public List<Eixo> eixos;
	}
}