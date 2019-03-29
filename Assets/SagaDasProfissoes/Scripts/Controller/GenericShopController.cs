using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using Trilhas.JsonFormat;
//using Trilhas.Dados;
using _2MuchPines.Templates;
using Trilhas.Components.Shop;
using TMPro;
using _2MuchPines.PlugglableTweens;
using Trilhas.Utilities;
using System;

namespace Trilhas.Controller
{
	public class GenericShopController : MonoBehaviourSingleton<GenericShopController>
    {

		[SerializeField] internal ShelfController[] _shelves;
		[SerializeField] internal GameObject _shelfItemPrefab;
		[SerializeField] internal MoneyGauge _moneyGauge;

		//[HideInInspector] 
		public LojaItem[] _content;

        [HideInInspector] public ShelfItem CurrentItem;
        private UserController userController;

		internal enum ShelfId
        {
            upper,
            lower
        }
  
		#region Properties
        public int Limit
        {
            get
            {
                return userController.MinhaMochila.LimiteDinheiro;
            }
            set
            {
                userController.MinhaMochila.LimiteDinheiro = value;
                _moneyGauge.Limit = value;

            }
        }

        public int Money
        {
            get
            {
                return userController.User.dinheiro;
            }
            set
            {
                userController.User.dinheiro = value;
                _moneyGauge.Money = userController.User.dinheiro;
            }
        }
		#endregion


        internal virtual void Start()
        {
			userController = UserController.Instance;
			SetGaugeValues();
			LoadContent();
        }

		internal virtual void LoadContent()
        {
            throw new NotImplementedException();
        }

		internal void SetGaugeValues()
		{
			_moneyGauge.Money = userController.User.dinheiro;
            _moneyGauge.Limit = userController.MinhaMochila.LimiteDinheiro;
		}
        
		internal void CreateItem(BasicItem item, int _shelfIndex=0)
        {
            GameObject go = Instantiate(_shelfItemPrefab);
            var tmp = go.GetComponent<ShelfItem>();
            tmp.lojaItem = (LojaItem)item;
            tmp.name = item.imagem;
			//To ensure that _shelfIndex is valid
			if (_shelves.Length> _shelfIndex)
			{
				_shelves[_shelfIndex].InsertItem(go);
			}
        }



    }
}
