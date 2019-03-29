using System.Collections;
using System.Collections.Generic;
using System;

namespace Trilhas.JsonFormat
{
    [Serializable]
    public class JsonResponse
    {
        public List<Erro> erros;
        public string chave;
        public string valor;
        public bool gravou;
    }
}