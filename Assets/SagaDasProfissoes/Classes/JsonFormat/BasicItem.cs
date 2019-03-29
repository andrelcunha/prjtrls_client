using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
    [Serializable]
    public class BasicItem
    {
		public int bonus;
        public string codigo;
        //Campo descricao adicionado para teste.
        //TODO: verificar se existe no BD.
        public string descricao;
		public EixoNome eixo;
        //Campo imagem adicionado para teste.
        public string imagem;
        public int limite;
        public string nome;
		public ItemTipo tipo;
              
		public bool estausando;        

        public int nivel;
        public bool comprado;
        public int preco;
  
    }
}