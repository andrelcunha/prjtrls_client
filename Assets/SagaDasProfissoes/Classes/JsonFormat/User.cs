using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
    [Serializable]
    public class User
    {
        public string idaluno;
        public string nome;
        public int sexo;
        public string cabelo;
        public string pele;
        public int ano;
        public int semestre;
        public int dinheiro;
        public int tickets;
        //public int pontos;
		public int[] eixos;
        public List<MissaoUsuario> missoes;
        public List<Mochila> mochila;
        public List<LojaItem> loja;
        public List<Erro> erros;
        public string token;
        public string usuario;

    }
}