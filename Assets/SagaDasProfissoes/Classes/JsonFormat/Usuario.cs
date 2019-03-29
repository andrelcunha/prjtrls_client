using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
	[Serializable]
	public class Usuario
	{
        public string idaluno;
	    public string nome;
	    public int sexo;
	    public int cabelo;
	    public int pele;
	    public int ano;
	    public int semestre;
	    public int dinheiro;
	    public int pontos;
		public List<EixoPonto> eixos;
		public List<MissaoUsuario> missoes;
        public List<Mochila> mochila;
        public List<LojaItem> loja;
        public List<Erro> erros;
		public string token;
		public string usuario;
	}
}