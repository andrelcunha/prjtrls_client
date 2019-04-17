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

namespace Trilhas.Controller
{
	public class ShopController : GenericShopController
	{
		[SerializeField] TweenEffect _confirmPopup;
		[SerializeField] TweenEffect _warningPopup;
		[SerializeField] string sucessMsg;
		[SerializeField] string failureMsg;

		private string shopFilename = "loja";

		private TextMeshProUGUI _warningTMPro;

		public TextMeshProUGUI WarningTMPro
		{
			get
			{
				if (_warningTMPro == null)
				{
					_warningTMPro = _warningPopup.GetComponentInChildren<TextMeshProUGUI>();
				}
				return _warningTMPro;
			}
		}


        
		internal override void Start()
		{
			base.Start();
			foreach (var item in _content)
			{
				switch(item.tipo)
				{
					case ItemTipo.ITEM:
						CreateItem(item as BasicItem, (int)ShelfId.upper);
						break;
					case ItemTipo.ROUPA:
						CreateItem(item as BasicItem, (int)ShelfId.lower);
						break;
					case ItemTipo.CARTEIRA:
						break;
					default:
						Debug.LogWarningFormat("Item type value not expected: '{0}'", item.tipo);
						break;
				}

			}
		}             
        

		internal override void LoadContent()
        {
            try
            {
                TextAsset file = Resources.Load<TextAsset>(shopFilename);
                string dataAsJon = file.ToString();
				_content = JsonUtility.FromJson<LojaContent>(dataAsJon).items;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Cannot load file");
                Debug.LogError(ex.ToString());
            }
        }

		public void TestBuy()
		{
			if (Money < CurrentItem.Preco)
            {
                _warningPopup.StartTween(0);
				WarningTMPro.text = failureMsg;
            }
			else
			{
				_confirmPopup.StartTween(0);
			}
         }

		public void BuyItem()
		{
			Money = Money - CurrentItem.Preco;
			SendToBackpack(CurrentItem.lojaItem);
			_warningPopup.StartTween(0);
			WarningTMPro.text = sucessMsg;
        }

		private void SendToBackpack(LojaItem lojaItem)
		{
			Mochila backpackItem = Tools.LojaToMochila(lojaItem);
			UserController.Instance.MinhaMochila.Itens.Add(backpackItem);
			UserController.Instance.SyncUser();
		}
	}
}

