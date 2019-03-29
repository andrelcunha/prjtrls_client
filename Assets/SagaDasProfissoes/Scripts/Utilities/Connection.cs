using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Trilhas.JsonFormat;
using Trilhas.Controller;

namespace Trilhas.Utilities
{
    public class Connection: MonoBehaviour
    {
        private string _jsonResponse;
        private bool isDone=false;
        private Config _objConfig;
		private string _key;
		//public string _token;
        #region Properties

        public string JsonResponse
        {
            get
            {
                return _jsonResponse;
            }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
        }

        public string Token
        {
            get
            {
				return UserController.Instance.Token;
            }
   
        }
		#endregion
        #region Singleton
        private static Connection _instance;

        public static Connection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (Connection)FindObjectOfType(typeof(Connection));
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("Connection:Singleton");
                        _instance = go.AddComponent<Connection>();
                    }
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
  
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Trilhas.Utilities.Connection"/> class.
		/// </summary>
		void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            string strJsonConfig = Uteis.LoadJson("config");
            _objConfig = JsonUtility.FromJson<Config>(strJsonConfig);
        }

        void OnDisable()
        {
            Instance = null;
        }


        #region PrivateMembers

        private string CreateKey(string pwd){
            string strChave = "-hmy|:djCle@|6&ydd;/)?/cs,'w5P9s\"`h_g+PM}IFU-#~T-$M6DU%3E[T@^kw";

            string strData = DateTime.Now.ToString("yyyyMMddHHmmss");
            strChave = strData + strChave;

            strChave += pwd;

            byte[] byteB64 = Encoding.UTF8.GetBytes(strChave);
            string strB64 = Convert.ToBase64String(byteB64);

            return strB64;
        }

        private string ConvertBase64(string json){
            byte[] byteB64 = Encoding.UTF8.GetBytes(json);
            string valorBase64 = Convert.ToBase64String(byteB64);
            Debug.Log(valorBase64);
            return valorBase64;
        }

		private void ResetValues(){
			_jsonResponse = null;
            isDone = false;
		}


        IEnumerator SendData(string url, WWWForm form){
            using (UnityWebRequest www = UnityWebRequest.Post(String.Format("{0}{1}", _objConfig.urlws, url), form))
            {

                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.LogError(www.error);

                    _jsonResponse =  ConnectionErrorToJson(www.error);
                    Debug.Log(_jsonResponse);
                    isDone = true;
                }
                else
                {
                    _jsonResponse = www.downloadHandler.text;
                    isDone = true;
                }
            }
        }

        string ConnectionErrorToJson(string error)
        {
            List<Erro> erros = new List<Erro>();
            erros.Add(new Erro
            {
                mensagem = error
            });
            JsonResponse json = new JsonResponse ();
            json.erros = erros;
            json.chave = "";
            json.valor = "";
            json.gravou = false;
            return JsonUtility.ToJson(json); 
        }
        #endregion

        #region PublicMembers
        public IEnumerator Autenticate(string user, string pwd)
        {
			ResetValues();
            _key = CreateKey(pwd);
			Debug.Log(_key);
            WWWForm form = new WWWForm();
            form.AddField("usuario", user);
            form.AddField("chave", _key);
            yield return StartCoroutine(SendData("login.php", form));
        }

        public IEnumerator GetCities()
		{
			ResetValues();
            WWWForm form = new WWWForm();
            yield return StartCoroutine(SendData("listarcidades.php", form));
            //yield return new WaitWhile(() => !isDone);
        }

        public IEnumerator GetSchools(string city)
        {
			ResetValues();
            WWWForm form = new WWWForm();
            form.AddField("cidade", city);
            yield return StartCoroutine(SendData("listarescolas.php", form));
            //yield return new WaitWhile(() => !isDone);

        }
        
        public IEnumerator RegisterPlayer(string name, string user, string pwd, string email, string unidade, string matricula, int ano)
		{
            /*
            ResetValues();
            _key= CreateKey(pwd);
            string value = "{ \"nome\": \"" + name + "\", \"usuario\": \"" + user + "\", \"email\": \"" + email + "\", \"unidade\": \"" + unidade + "\", \"matricula\": " + matricula + ", \"ano\": " + ano.ToString() + " }";
            byte[] byteB64 = Encoding.UTF8.GetBytes(value);
            string valorBase64 = Convert.ToBase64String(byteB64);
            WWWForm form = new WWWForm();
            form.AddField("chave", _key);
            form.AddField("valor", valorBase64);
            yield return StartCoroutine(SendData("cadastrarjogador.php", form));
            //yield return new WaitWhile(() => !isDone);*/
            yield return null;
        }

        public IEnumerator RegisterPlayer(string jsonStr, string pwd)
        {
			ResetValues();
            _key = CreateKey(pwd);
            WWWForm form = new WWWForm();
            form.AddField("chave", _key);
            form.AddField("valor", ConvertBase64(jsonStr));
            yield return StartCoroutine(SendData("cadastrarjogador.php", form));
            //yield return new WaitWhile(() => !isDone);
        }

        public IEnumerator ForgotPasswd(string jsonStr, string pwd)
        {
			//TODO: Não estaá funcionando... apenas placeholder
			_jsonResponse = null;
            isDone = false;
            _key = CreateKey(pwd);
            WWWForm form = new WWWForm();
            form.AddField("chave", _key);
            form.AddField("valor", ConvertBase64(jsonStr));
            yield return StartCoroutine(SendData("cadastrarjogador.php", form));
            //yield return new WaitWhile(() => !isDone);
        }
        
		public IEnumerator SaveAvatar(string jsonStr)
        {
			//TODO: Fazer funcionar o salvamento do avatar
			_jsonResponse = null;
            isDone = false;
            WWWForm form = new WWWForm();
            if (Token != null)
			{

				form.AddField("token", Token);
				form.AddField("valor", ConvertBase64(jsonStr));
				yield return StartCoroutine(SendData("customperson.php", form));
			}
			else
			{
				Debug.LogWarning("There is no token to send!");
				yield return null;
			}
        }

        public IEnumerator GetPerguntasQuiz(string pedido)
        {
            //TODO: Fazer funcionar o a aquisicao de perguntas pelo servidor
            /*
            _jsonResponse = null;
            isDone = false;
            WWWForm form = new WWWForm();
            if (Token != null)
            {

                form.AddField("token", Token);
                form.AddField("pedido", "ec9be43e-16d0-43b2-86b5-1d217e77fcae");
                yield return StartCoroutine(SendData("perguntasquiz.php", form));
            }
            else
            {
                Debug.LogWarning("There is no token to send!");
                yield return null;
            }*/
            _jsonResponse = Uteis.LoadJson("quiz_1");
            yield return null;
        }
        #endregion


        private void ProcessUser(string strJson)
        {/*
            //TODO: objUsuario assignment must be inside as try to avoid
            //connection error.
            //This is assuming that connection will always be ok.
            try
            {
                objUsuario = JsonUtility.FromJson<Usuario>(strJson);
                Debug.Log(objUsuario.idaluno);
                if (objUsuario.idaluno == null)
                {
                    Debug.Log("Wrong username or password");
                    return;
                }
                Token = objUsuario.token;
                IdAluno = objUsuario.idaluno;
                NomeUsuario = objUsuario.usuario;
                Nome = objUsuario.nome;
                Sexo = objUsuario.sexo;
                Pele = objUsuario.pele;
                Cabelo = objUsuario.cabelo;
                Pontos = objUsuario.pontos;
                Dinheiro = objUsuario.dinheiro;

                foreach (EixoPonto objEixo in objUsuario.eixos)
                {
                    EixoPontoUsuario objEixoPonto = new EixoPontoUsuario();
                    objEixoPonto.Nome = objEixo.nome;
                    objEixoPonto.Pontos = objEixo.pontos;

                    Eixos.Add(objEixoPonto);
                }

                foreach (MissaoUsuario objMissao in objUsuario.missoes)
                {
                    MapaMissao objMapaMissao = new MapaMissao();

                    objMapaMissao.Ano = objMissao.ano;
                    objMapaMissao.Codigo = new Guid(objMissao.codigo);
                    objMapaMissao.Cumprida = objMissao.cumprida;
                    objMapaMissao.Liberada = objMissao.liberada;
                    objMapaMissao.Jogando = objMissao.jogando;
                    objMapaMissao.Aprovada = objMissao.aprovada;
                    objMapaMissao.Ligacao = new Guid();

                    if (objMissao.ligadoa != "")
                    {
                        objMapaMissao.Ligacao = new Guid(objMissao.ligadoa);
                    }

                    objMapaMissao.Obrigatorio = objMissao.obrigatorio;
                    objMapaMissao.Semestre = objMissao.semestre;
                    objMapaMissao.Sequencia = objMissao.sequencia;
                    objMapaMissao.Referencia = objMissao.referencia;

                    Missoes.Add(objMapaMissao);
                }

                LojaProdutos objProdutos = new LojaProdutos();

                foreach (Trilhas.JsonFormat.LojaItem objItem in objUsuario.loja)
                {
                    Trilhas.Dados.LojaItem objItemDado = new Trilhas.Dados.LojaItem();
                    objItemDado.Preco = objItem.preco;
                    objItemDado.Descricao = objItem.nome;

                    switch (objItem.tipo)
                    {
                        case "CARTEIRA":
                            objProdutos.Carteiras.Add(objItemDado);
                            break;
                        case "ROUPA":
                            objProdutos.Roupas.Add(objItemDado);
                            break;
                        case "ITEM":
                            objProdutos.Itens.Add(objItemDado);
                            break;
                    }
                }

                MinhaMochila = new MochilaUsuario();

                foreach (Mochila objMochila in objUsuario.mochila)
                {
                    MochilaItem objItem = new MochilaItem();
                    objItem.Bonus = objMochila.bonus;
                    objItem.Codigo = objMochila.codigo;
                    objItem.Eixo = objMochila.eixo;
                    objItem.EstaUsando = objMochila.estausando;
                    objItem.Limite = objMochila.limite;
                    objItem.Nome = objMochila.nome;
                    objItem.Tipo = objMochila.tipo;
                    objItem.Imagem = objMochila.imagem;

                    MinhaMochila.Itens.Add(objItem);

                    if (objMochila.estausando)
                    {
                        if (objMochila.tipo == "ROUPA")
                        {
                            MinhaMochila.Slots = objItem.Limite;
                        }
                        else if (objMochila.tipo == "CARTEIRA")
                        {
                            MinhaMochila.LimiteDinheiro = objItem.Limite;
                        }
                    }
                }

                SceneManager.LoadScene("CenaMenuEixo");
            }
            catch (System.Exception)
            {

                throw;
            }*/
        }

        void ProcessCities(string strJson){/*
            Cidades listCidade = JsonUtility.FromJson<Cidades>(strJson);

            Debug.Log(strJson);
            Debug.Log("Count: " + listCidade.cidades.Count);

            cmbCidade.options.Clear();

            List<Dropdown.OptionData> lsOpt = new List<Dropdown.OptionData>();

            Dropdown.OptionData objOption = new Dropdown.OptionData();
            objOption.text = "Selecione";
            lsOpt.Add(objOption);

            cidades = new string[listCidade.cidades.Count];
            int count = 0;
            foreach (Cidade objCidade in listCidade.cidades)
            {
                objOption = new Dropdown.OptionData();
                objOption.text = objCidade.nome;

                lsOpt.Add(objOption);

                cidades[count] = objCidade.codigo;
                count++;
            }

            cmbCidade.AddOptions(lsOpt);*/
        }

        void ProcessSchools(string strJson){/*
            Escolas listEscola = JsonUtility.FromJson<Escolas>(strJson);

            cmbUnidadeEnsino.options.Clear();

            List<Dropdown.OptionData> lsOpt = new List<Dropdown.OptionData>();

            Dropdown.OptionData objOption = new Dropdown.OptionData();
            objOption.text = "Selecione";
            lsOpt.Add(objOption);

            escolas = new string[listEscola.escolas.Count];
            int count = 0;
            foreach (Escola objEscola in listEscola.escolas)
            {
                objOption = new Dropdown.OptionData();
                objOption.text = objEscola.nome + " (" + objEscola.codigo + ")";

                lsOpt.Add(objOption);

                escolas[count] = objEscola.codigo;
                count++;
            }

            cmbUnidadeEnsino.AddOptions(lsOpt);*/
        }

    }

}
