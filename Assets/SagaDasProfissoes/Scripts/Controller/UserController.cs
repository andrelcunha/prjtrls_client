using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using Trilhas.JsonFormat;
using Trilhas.Dados;
using System;
using _2MuchPines.Templates;

namespace Trilhas.Controller
{
	public class UserController : MonoBehaviourSingletonPersistent<UserController>
	{
		[SerializeField] bool tutorialActive;

		public bool TutorialActive
		{
			get
			{
				return tutorialActive;
			}
		}
		[SerializeField] TutorialState _tutorialState;

		//[SerializeField] bool _tutorialMissionOk;
		//[SerializeField] bool _tutorialShoppingOk;


		/*
		 public bool TutorialMissionOk
		{
			get
			{
				return _tutorialMissionOk;
			}
		} 

		public bool TutorialShoppingOk
        {
            get
            {
				return _tutorialShoppingOk;
            }
        }*/

		private DataController _dataController;
		private User _user;
		private UserAvatar _avatar;
		MochilaUsuario _minhaMochila;
		List<MissaoUsuario> _missions;
		[HideInInspector] int _currentMission;
        private int _tickets;

		#region Properties
		public User User
		{
			get
			{
				_user = _dataController.User;
				return _user;
			}
			set
			{
				_user = value;
				SyncUser();
			}
		}

		public UserAvatar Avatar
		{
			get
			{
				_avatar.sexo = User.sexo;
				_avatar.pele = User.pele;
				_avatar.cabelo = User.cabelo;
				return _avatar;
			}

			set
			{
				_avatar = value;
				User.sexo = _avatar.sexo;
				User.pele = _avatar.pele;
				User.cabelo = _avatar.cabelo;
			}
		}

		public MochilaUsuario MinhaMochila
		{
			get
			{
				if (_minhaMochila.Itens == null || _minhaMochila.Itens.Count == 0)
				{
					_minhaMochila.Itens = new List<Mochila>(_user.mochila);
				}
				return _minhaMochila;
			}

			set
			{
				_minhaMochila = value;
				_user.mochila = _minhaMochila.Itens;
			}
		}

		public int[] Eixos 
		{
			get
			{
				return User.eixos;
			}
		}

		public List<MissaoUsuario> Missions
		{
			get
			{
				if (_missions == null || _missions.Count == 0)
				{
					_missions = new List<MissaoUsuario>(User.missoes);               
				}
			    return _missions;
			}
			set
			{
				_missions = value;
				_user.missoes = _missions;
			}
		}

		public int CurrentMission
		{
			get
			{
				return _currentMission;
			}

			set
			{
				_currentMission = value;
			}
		}
		public string Token
		{
			get
			{
				return User.token;
			}
		}

		public TutorialState TutorialState
		{
			get
			{
				return _tutorialState;
			}

			set
			{
				_tutorialState = value;
			}
		}

        public int Tickets
        {
            get
            {
                return _tickets;
            }
            set
            {
                _tickets = value;
                _user.tickets = _tickets;
            }
        }

        #endregion

        void Start()
		{

            _dataController = DataController.Instance;
			_avatar = new UserAvatar()
			{
				sexo = -1,
				pele = "",
				cabelo = ""
			};

			_minhaMochila = new MochilaUsuario()
			{
				Itens = new List<Mochila>(),
				LimiteDinheiro = 200,
				Slots = 1
			};
		}

        public void SyncUser()
		{
			//TODO: sync with Web Service
			//MinhaMochila = MinhaMochila;
            //Missions = Missions;

            DataController.SaveUser(User);
		}

		public void SetTutorialMissionOk(bool ok)
        {
			//_tutorialMissionOk = ok;
			if(ok)
			{
				TutorialState = TutorialState.PRIMEIRA_MISSAO;
			}
        }

		public void SetTutorialShoppingOk(bool ok)
        {
			//_tutorialShoppingOk = ok;
            if(ok)
			{
                TutorialState = TutorialState.LOJA;
			}
        }

        public void SetTutorialArenaOk(bool ok)
        {
            //_tutorialShoppingOk = ok;
            if (ok)
            {
                TutorialState = TutorialState.ARENA;
            }
        }

        public bool ProcessUser(string strJson)
		{
			try
			{
				Debug.Log(strJson);
				User = JsonUtility.FromJson<User>(strJson);
				Debug.Log(_user.idaluno);
				if (_user.idaluno == null)
				{
					Debug.Log("Something is wrong");
					return false;
				}
				_avatar.sexo = _user.sexo;
				_avatar.pele = _user.pele;
				_avatar.cabelo = _user.cabelo;

				//Token =  _usuarioObj.token;
				//IdAluno =  _user.idaluno;
				//NomeUsuario =  _user.usuario;
				//Nome =  _user.nome;
				//Sexo =  _user.sexo;
				//Pele =  _user.pele;
				//Cabelo =  _user.cabelo;
				//Pontos =  _user.pontos;
				//Dinheiro =  _user.dinheiro;

                /*
				foreach (EixoPonto objEixo in _user.eixos)
				{
					EixoPontoUsuario objEixoPonto = new EixoPontoUsuario();
					objEixoPonto.Nome = objEixo.nome;
					objEixoPonto.Pontos = objEixo.pontos;

					//Eixos.Add(objEixoPonto);
				}*/

                /*

				LojaProdutos objProdutos = new LojaProdutos();

				foreach (Trilhas.JsonFormat.LojaItem objItem in _user.loja)
				{
					LojaItem objItemDado = new LojaItem();
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
				}*/
				SetMissions(_user.missoes);

				SetBackpack(_user.mochila);
				return true;

			}
			catch (System.Exception e)
			{
				Debug.LogException(e, this);
				return false;
			}
		}

		private void SetBackpack(List<Mochila> itens)
		{
			foreach (Mochila objMochila in itens)
			{

				/*
                MochilaItem objItem = new MochilaItem();
                objItem.Bonus = objMochila.bonus;
                objItem.Codigo = objMochila.codigo;
                objItem.Eixo = objMochila.eixo;
                objItem.EstaUsando = objMochila.estausando;
                objItem.Limite = objMochila.limite;
                objItem.Nome = objMochila.nome;
                objItem.Tipo = objMochila.tipo;
                objItem.Imagem = objMochila.imagem;
                MinhaMochila.Itens.Add(objItem);*/
				MinhaMochila.Itens.Add(objMochila);

				if (objMochila.estausando)
				{
					if (objMochila.tipo == ItemTipo.ROUPA)
					{
						MinhaMochila.Slots = objMochila.limite;
					}
					else if (objMochila.tipo == ItemTipo.CARTEIRA)
					{
						MinhaMochila.LimiteDinheiro = objMochila.limite;
					}
				}
			}
		}

		private void SetMissions(List<MissaoUsuario> missions)
		{
			/*
			foreach (MissaoUsuario objMissao in missions)
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

                //Missoes.Add(objMapaMissao);


            }
            */
			Missions = missions;
            int i = 0;
            foreach (var mission in missions)
            {
                Debug.Log(mission.codigo);
                i++;
            }
            Debug.Log("total missions: " + i);
        }

	}
}

