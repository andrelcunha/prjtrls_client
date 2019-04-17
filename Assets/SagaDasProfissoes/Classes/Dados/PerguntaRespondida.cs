using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.Dados
{
	public class PerguntaRespondida
	{
		public string IdPedido { get; set; }
		public string IdPergunta { get; set; }
		public string IdRespostaDada { get; set; }
		public string IdRespostaCerta { get; set; }
		public bool Acertou { get; set; }
		public double Segundos { get; set; }
	}
}