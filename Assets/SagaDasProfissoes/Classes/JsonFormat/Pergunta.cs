using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Pergunta
	{
		public string codigo;
		public string enunciado;
        public string categoria; //inserted to fix question panel label
		public List<Resposta> respostas;
	}
}