using Trilhas.JsonFormat;
using UnityEngine;
using _2MuchPines.Templates;
using _2MuchPines.Unity_Timer;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Trilhas.Controller
{
    public class QuizController:MonoBehaviourSingleton<QuizController>
    {
        [SerializeField] QuizConnection conn;
        [SerializeField] QuestionController questionController;
        [SerializeField] Timer timer;
        private Quiz _quiz;
        private int questionIndex = -1;
        private List<bool> resultList;
        [SerializeField]
        private List<Resposta> answerList; 

        void Awake()
        {
            resultList = new List<bool>();
            answerList = new List<Resposta>();
        }

        public void GetQuiz()
        {
            conn.QuizConnectionAtempt();
        }

        public bool ProcessQuiz(string strJson)
        {
            try
            {
                //Debug.Log(strJson);
                _quiz = JsonUtility.FromJson<Quiz>(strJson);
                ShowNextQuestion();
                if (!timer.IsRunning)
                    timer.StartRunning();
                
            }
            catch (System.Exception e)
            {
                Debug.LogException(e, this);
                return false;
            }

            return true;

        }

        public void ShowNextQuestion()
        {

            questionIndex++;
            Pergunta nextQuestion;
            if (questionIndex < _quiz.perguntas.Count)
            {
                nextQuestion = _quiz.perguntas[questionIndex];
            }
            else 
            {
                EndQuiz();
                nextQuestion = EmptyQuestion();
            }
            ShowQuestion(nextQuestion);
        }

        void ShowQuestion(Pergunta nextQuestion)
        {
            questionController.PerguntaObj = nextQuestion;
        }

        public void SaveResult(Resposta answer)
        {
            answerList.Add(answer);
        }

        void EndQuiz()
        {
            //Debug.Log("Quiz is Over");
            DoResultCorrection();
            timer.StopRunning();

        }

        void DoResultCorrection()
        { 
            foreach(var answer in answerList)
            {

                var result = answer.correta;
                resultList.Add(result);
            }
            for (int i = 0; i < resultList.Count; i++)
            {
                Debug.LogFormat("{0}. {1}", i + 1, resultList[i] ? "Correto" : "Errado");
            }
            float timeElapsed = timer.TotalTime - timer.TimeLeft;
            Debug.LogFormat("Total {0} acertos", resultList.Count((arg) => arg));
            Debug.LogFormat("Time Elapsed: {0}",timeElapsed);
        }

        Pergunta EmptyQuestion()
        {
            var emptyQuestion = new Pergunta
            {
                categoria = "",
                codigo = "",
                enunciado = "",
                respostas = new List<Resposta>()
            };
            for (int i = 0; i < 4; i++)
            {
                emptyQuestion.respostas.Add(new Resposta { codigo = "", texto = "" });
            }
            return emptyQuestion;
        }
    }
}
