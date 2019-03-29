using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class MissaoUsuario:Missao
	{
		//public string codigo;
		//public int ano;
		//public int semestre;
		//public int sequencia;
		//public Missao missao;
		public bool obrigatorio;
		public string ligadoa;
		public bool liberada;
		public bool cumprida;
		public bool jogando;
        public bool aprovada;
        public int referencia;
	}
}