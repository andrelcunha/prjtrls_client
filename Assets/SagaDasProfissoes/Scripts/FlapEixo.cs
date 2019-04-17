using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapEixo : MonoBehaviour {
    [SerializeField] EixoNome eixo;

    public EixoNome Eixo
    {
        get
        {
            return eixo;
        }
    }
}
