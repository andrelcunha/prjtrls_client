using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trilhas.JsonFormat;
using TMPro;

namespace Trilhas.Controller
{

    public class QuestionController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI categoriaTMP; //Eixo
        [SerializeField] TextMeshProUGUI perguntaTMP;
        [SerializeField] List<AnswerController> answers;

        private Pergunta _perguntaObj;


        public Pergunta PerguntaObj
        {
            get
            {
                return _perguntaObj;
            }

            set
            {
                _perguntaObj = value;
                perguntaTMP.text = _perguntaObj.enunciado;
                categoriaTMP.text = _perguntaObj.categoria;
                for (int i = 0; i < answers.Count; i++)
                {
                    if (i < _perguntaObj.respostas.Count)
                    {
                        answers[i].Answer = _perguntaObj.respostas[i];
                    }
                }

            }
        }
    }

}
