using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Resposta
	{
		public string codigo;
		public string texto;
		public bool correta;
	}
}