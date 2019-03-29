using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Trilhas.Tutorials
{
	public class CarouselController : MonoBehaviour
	{
		[SerializeField] CanvasGroup _leftButton;
		[SerializeField] CanvasGroup _rightButton;
		[SerializeField] CarouselItem[] _items;
		[SerializeField] float _posOffset;
		[SerializeField] float _duration;
		[SerializeField] CanvasGroup canvasGroup;
		private int _index;

		void Start()
		{
			VerifyButtons();
            
			for (int i = 1; i < _items.Length; i++)
			{
				_items[i].SetPosition(_posOffset);
			}
		}
  
        public void Left()
		{
			if (_index > 0)
			{
				_items[_index].DoMove(_posOffset, _duration);
                _index--;
				VerifyButtons();
				_items[_index].DoMove(_posOffset, _duration);
			}
		}

		public void Right()
		{
			if (_index < _items.Length - 1)
                
            {
				_items[_index].DoMove(-_posOffset, _duration);
				_index++;
				VerifyButtons();
				_items[_index].DoMove(-_posOffset, _duration);
            }
		}

		private void SetButton(CanvasGroup button,bool isEnable)
		{
			button.alpha = isEnable ? 1 : 0;
			button.interactable = isEnable;
			button.blocksRaycasts = isEnable;
		}

		private void VerifyButtons()
		{
			if (_index == 0)
            {
                SetButton(_leftButton, false);
				SetButton(_rightButton, true);

            }
            else if (_index == _items.Length - 1)
            {
				SetButton(_leftButton, true);
				SetButton(_rightButton, false);
			}
			else
			{
				SetButton(_leftButton, true);
                SetButton(_rightButton, true);
			}
		}

        public void SetVisible(bool isVisible)
		{
			canvasGroup.alpha = isVisible ? 1 : 0;
			canvasGroup.blocksRaycasts = isVisible;
			canvasGroup.interactable = isVisible;
		}
	}
}