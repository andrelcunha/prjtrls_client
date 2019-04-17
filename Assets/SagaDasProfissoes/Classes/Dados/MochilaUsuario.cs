using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trilhas.JsonFormat;

namespace Trilhas.Dados
{
    public class MochilaUsuario
    {
        private List<Mochila> _itens = new List<Mochila>();

        public int Slots { get; set; }
        public int LimiteDinheiro { get; set; }

        public List<Mochila> Itens
        {
            get
            {
                return _itens;
            }
			set
			{
				_itens = value;
			}
        }
    }
    /*
    public class MochilaItem
    {
        public string Codigo;
        public string Tipo;
        public string Nome;
        public string Eixo;
        public int Limite;
        public int Bonus;
        public bool EstaUsando;
        public string Imagem;
    }*/
}