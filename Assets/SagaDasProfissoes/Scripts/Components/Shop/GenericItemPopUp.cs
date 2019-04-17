using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Trilhas.JsonFormat;
using System.IO;
using _2MuchPines.Templates;
using _2MuchPines.PlugglableTweens;
using Trilhas.Controller;

namespace Trilhas.Components.Shop
{
    [RequireComponent(typeof(TweenEffect))]
	public class GenericItemPopUp : MonoBehaviourSingleton<GenericItemPopUp>
    {
        [SerializeField] Image _itemImage;
        [SerializeField] TextMeshProUGUI _description;

        [SerializeField] Image _confirmImage;
        [SerializeField] TextMeshProUGUI _price;

        ShelfItem _item;
        string _itemName;
        string _itemDesc;
        
		int _bonus;
        TweenEffect _tweenEffect;
        bool _isVisible;
        int _itemValue;

		ItemTipo _tipo;
        EixoNome _eixo;



        #region Properties   
        public string ItemName
        {
            get
            {
                return _itemName;
            }

            set
            {
                _itemName = value;
                SetDescription(_itemName, _itemDesc);
            }
        }

        public Image ItemImage
        {
            get
            {
                return _itemImage;
            }

            set
            {
                _itemImage = value;
            }
        }

		public int ItemBonus
        {
            get
            {
                return _bonus;
            }

            set
            {
                _bonus = value;
            }
        }

        public EixoNome ItemEixo
        {
            get
            {
                return _eixo;
            }

            set
            {
                _eixo = value;
            }
        }

        public ItemTipo ItemTipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                _tipo = value;
            }
        }

        public string ItemDesc
        {
            get
            {
                return _itemDesc;
            }

            set
            {
                _itemDesc = value;
                SetDescription(_itemName, _itemDesc);
            }
        }


        public ShelfItem Item
        {
            get
            {
                return _item;
            }

            set
            {
                _item = value;
                ItemName = _item.Nome;
                ItemDesc = _item.Descricao;
                ItemImage.sprite = _item.Imagem.sprite;
				if (_confirmImage != null)
				{
					_confirmImage.sprite = _item.Imagem.sprite;
				}
                ItemValue = _item.Preco;
				ItemEixo = _item.EixoItem;
                ItemTipo = _item.Tipo;

            }
        }

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            set
            {
                _isVisible = value;

            }
        }

        public int ItemValue
        {
            get
            {
                return _itemValue;
            }

            set
            {
                _itemValue = value;
                SetValue(_itemValue);
            }
        }
        #endregion

        void Awake()
        {
            _tweenEffect = GetComponent<TweenEffect>();
        }

        public void SetDescription(string name, string desc)
        {
            _description.text = string.Format("<b>{0}</b>\n\n{1}", name, desc);
        }

        public void SetValue(int val)
        {
            if (val < 100000000)
            {
                if (val > -1)
                {
                    if (_price != null)
					{
						_price.text = val.ToString();
					}	
                }
                else
                {
                    Debug.LogWarningFormat("Value {0} below minimum of the field", val);
                }
            }
            else
            {
                Debug.LogWarningFormat("Value {0} beyond max cap of the field", val);
            }
        }

        public void ToggleVisible()
        {
            IsVisible = !IsVisible;
            Item = GenericShopController.Instance.CurrentItem;
            if (IsVisible)
            {
                _tweenEffect.StartTween(0);
            }
            else
            {
                _tweenEffect.RewindTween(0);
            }

        }
    }
}
