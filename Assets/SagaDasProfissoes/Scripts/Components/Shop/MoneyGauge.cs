using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Trilhas.Components.Shop
{
	public class MoneyGauge: MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI _moneyText;
		[SerializeField] Image _image;
		[SerializeField] Sprite[] _sprites;
		[SerializeField] int _limit;

#region Properties
		public int Money
        {
            get
            {
				return int.Parse(_moneyText.text);
            }
            set
            {
                
				_moneyText.text = value.ToString();
            }
        }

		public int Limit
		{
			get
			{
				return _limit;
			}

			set
			{
				_limit = value;
				SetSprite();
			}
		}
#endregion
        
		void SetSprite()
		{
			_image.sprite = _sprites[GetSpriteIndexFromLimit(Limit)];
		}

		int GetSpriteIndexFromLimit(int limit)
		{
			int index = -1;
			switch (limit)
			{
				case 200:
					index = 0;
					break;
				case 500:
					index = 1;
					break;
				case 2000:
					index = 2;
					break;
				default:
					index = 3;
					break;
			}
			return index;
		}
	}
}