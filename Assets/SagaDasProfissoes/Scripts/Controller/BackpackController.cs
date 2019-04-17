using UnityEngine;
using Trilhas.JsonFormat;
using _2MuchPines.Templates;
using Trilhas.Components.MenuMochila;
using Trilhas.Components.Shop;

using System.Linq;

namespace Trilhas.Controller
{
	public class BackpackController : GenericShopController
    {
		[SerializeField] MochilaSlotController _slotController;
		//[HideInInspector]
		public BasicItem[] _unequipedItems;
		public BasicItem[] _equipedItems;
        

		private ShelfController _shelf
		{
			get
			{
				return _shelves[0];
			}	
			set
			{
				_shelves[0] = value;
			}
		}

		internal override void Start()
        {
			base.Start();
			LoadEquipedItems();
			ShowBackpackContent();
        }

		internal override void LoadContent()
        {
            _content = UserController.Instance.MinhaMochila.Itens.ToArray();
            _unequipedItems = _content.Where((item) => item.estausando == false)
                                      .ToArray();
            _equipedItems = _content.Where((item) => item.estausando == true)
                                      .ToArray();
        }

        public void EquipItem()
        {
			CurrentItem.mochilaItem.estausando = _slotController.EquipItem(CurrentItem.mochilaItem);
			_shelf.RemoveItem(CurrentItem.mochilaItem.nome);
        }

		public void LoadCloths()
		{
			//TODO: Do the real thing
            //Mocking up the use of cloth bonuses
			_slotController.Slots[0].Status = MochilaSlotStatus.empty;
			_slotController.Slots[1].Status = MochilaSlotStatus.empty;
			_slotController.UpdateAvaliableSlots();
		}
        
		private void LoadEquipedItems()
		{
			LoadCloths();
			foreach (var item in _equipedItems)
            {
                _slotController.EquipItem((Mochila)item);

            }
			LoadContent();
		}
        
		private void ShowBackpackContent()
		{
			Mochila[] itemsOnShelf = _shelf.GetComponentsInChildren<ShelfItem>()
			                         .Select((arg) => arg.mochilaItem)
			                         .ToArray();
			Debug.Log("size:" + itemsOnShelf.Length);
			foreach (var item in _unequipedItems)
            {
				bool alreadyExists = itemsOnShelf.Contains(item);
				if(alreadyExists)
				{
					Debug.Log("Already exists.");
				}
				else if (item.tipo == ItemTipo.ITEM)
				{
					CreateItem((Mochila)item);
				}
            }
		}
    }
}

