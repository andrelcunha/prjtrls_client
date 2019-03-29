using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.Dados
{
	public class MapaMissao
	{
		public Guid Codigo { get; set; }
		public int Ano { get; set; }
		public int Semestre { get; set; }
		public int Sequencia { get; set; }
		public bool Obrigatorio { get; set; }
		public Guid Ligacao { get; set; }
		public bool Liberada { get; set; }
		public bool Cumprida { get; set; }
		public bool Jogando { get; set; }
        public bool Aprovada { get; set; }
        public int Referencia { get; set; }
	}
}