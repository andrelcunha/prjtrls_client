using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Quiz
	{
		public string token;
		public string pedido;
		//public string categoria;
		public List<Pergunta> perguntas;
	}
}