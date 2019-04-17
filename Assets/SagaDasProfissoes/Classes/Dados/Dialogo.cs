using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trilhas.Dados
{
    public class Dialogos : List<Dialogo>
    {
        private List<Dialogo> _dialogos = new List<Dialogo>();

        public string Missao { get; set; }

        public List<Dialogo> Falas
        {
            get
            {
                return _dialogos;
            }
        }
    }

    public class Dialogo
    {
        public int Sequencia { get; set; }
        public string NPC { get; set; }
        public string Humor { get; set; }
        public string Texto { get; set; }
    }
}