using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
    [Serializable]
    public class DialogosMissao
    {
        public string token;
        public string missao;
        public List<MissaoNPC> falas;
        public List<Erro> erros;
    }
}