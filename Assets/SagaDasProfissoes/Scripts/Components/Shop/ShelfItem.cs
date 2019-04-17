using Trilhas.Controller;
using Trilhas.JsonFormat;
using UnityEngine;
using UnityEngine.UI;


namespace Trilhas.Components.Shop
{
	[RequireComponent(typeof (Button),typeof(Image))]
	public class ShelfItem : MonoBehaviour
	{
		public LojaItem lojaItem;

		private Button _button;

		private Image _imagem;

		public Image Imagem
		{
			get
			{
				return _imagem;
			}
		}

		private GenericItemPopUp _popup;
		private GenericShopController _shopController;

		#region Properties
		public string Codigo
		{
			get{
				return lojaItem.codigo;
			}
			set{
				lojaItem.codigo = value;
			}
		}

		public ItemTipo Tipo
        {
            get
            {
				return lojaItem.tipo;
            }
            set
            {
				lojaItem.tipo = value;
            }
        }

		public string Nome
        {
            get
            {
				return lojaItem.nome;
            }
            set
            {
				lojaItem.nome = value;
            }
        }

        //Campo descricao adicionado para teste.
		public string Descricao
        {
            get
            {
				return lojaItem.descricao;
            }
            set
            {
				lojaItem.descricao = value;
            }
        }
        //Campo imagem adicionado para teste.
		public string ImagemFile
        {
            get
            {
				return lojaItem.imagem;
            }
            set
            {
				lojaItem.imagem = value;
				Imagem.sprite = Utilities.Tools.LoadImageFile(ImagemFile, Tipo,EixoItem);            
            }
        }
		public EixoNome EixoItem
        {
            get
            {
				return lojaItem.eixo;
            }
            set
            {
				lojaItem.eixo = value;
            }
        }

		public int Limite
        {
            get
            {
				return lojaItem.limite;
            }
            set
            {
				lojaItem.limite = value;
            }
        }

		public int Bonus
        {
            get
            {
				return lojaItem.bonus;
            }
            set
            {
				lojaItem.bonus = value;
            }
        }

		public int Nivel
        {
            get
            {
				return lojaItem.nivel;
            }
            set
            {
				lojaItem.nivel = value;
            }
        }
		public bool Comprado
        {
            get
            {
				return lojaItem.comprado;
            }
            set
            {
				lojaItem.comprado = value;
            }
        }

		public int Preco
        {
            get
            {
				return lojaItem.preco;
            }
            set
            {
				lojaItem.preco = value;
            }
        }

		public Button Button
		{
			get
			{
				return _button;
			}

			set
			{
				_button = value;
			}
		}

		public Mochila mochilaItem 
		{ 
			get
			{
				return lojaItem as Mochila;
			}
			set
			{
				Mochila mochilaVal = value;
				lojaItem.bonus = mochilaVal.bonus;
				lojaItem.codigo = mochilaVal.codigo;
				lojaItem.descricao = mochilaVal.descricao;
				lojaItem.eixo = mochilaVal.eixo;
				lojaItem.imagem = mochilaVal.imagem;
				lojaItem.limite = mochilaVal.limite;
				lojaItem.nivel = mochilaVal.nivel;
				lojaItem.nome = mochilaVal.nome;
				lojaItem.preco = mochilaItem.preco;
				lojaItem.tipo = mochilaItem.tipo;            
			}
		}


		public Mochila basicItem { get; set; }

#endregion
        void Awake()
		{
			_imagem = GetComponent<Image>();
			Button = GetComponent<Button>();
		}

		void Start()
		{

			Imagem.sprite = Utilities.Tools.LoadImageFile(ImagemFile, Tipo,EixoItem);
			_popup = GenericItemPopUp.Instance;
			_shopController = GenericShopController.Instance;
			Debug.Log(_shopController.gameObject.name);
            AddEventListener();
		}

        private void AddEventListener()
		{
			_button.onClick.AddListener(delegate {
				//_popup.Item = this;
				_shopController.CurrentItem = this;
				_popup.ToggleVisible();
			});
		}
	}
}
