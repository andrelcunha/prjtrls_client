using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using Trilhas.JsonFormat;
using UnityEngine;
using UnityEngine.UI;


namespace Trilhas.Components.MenuMochila
{
	[RequireComponent(typeof(Image))]
	public class MochilaSlot : MonoBehaviour
    {
		Image _imageItem;
		[SerializeField] Sprite[] _spriteStates;
		[SerializeField] MochilaSlotStatus _status;
		private Mochila _itemMochila;

		public MochilaSlotStatus Status
		{
			get
			{
				return _status;
			}

			set
			{
				_status = value;
                _imageItem.sprite = _spriteStates[(int)value];            
			}
		}

		public Mochila ItemMochila
		{
			get
			{
				return _itemMochila;
			}
            
			set
			{
				_itemMochila = value;
				_spriteStates[(int)MochilaSlotStatus.full] = Utilities.Tools.LoadImageFile(_itemMochila.imagem, ItemTipo.ITEM,_itemMochila.eixo);
				Status = MochilaSlotStatus.full;
			}
		}
        void Awake()
		{
			_imageItem = GetComponent<Image>();
			Status = MochilaSlotStatus.locked;
		}
        

		public Sprite LoadImageFile()
        {
			var fileName = Path.Combine();
            var filePath = Path.Combine("Sprites", "ITEMS", fileName);
            Sprite sprite = Resources.Load<Sprite>(filePath);
            return sprite;
        }
	}


}
