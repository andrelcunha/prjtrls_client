using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Escolas
	{
		public List<Escola> escolas;
		public string token;
		public string cidade;
	}
}