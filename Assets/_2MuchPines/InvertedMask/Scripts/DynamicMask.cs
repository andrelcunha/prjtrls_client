using UnityEngine;
using UnityEngine.UI;

using System.Linq;
using DG.Tweening;

namespace _2MuchPines.InvertedMask
{
	public class DynamicMask : MonoBehaviour
	{
		[SerializeField] GameObject _maskItem;
		[SerializeField] CanvasGroup _blackPanel;
		[SerializeField] GameObject _target;
		[SerializeField] float _duration;

        
		public GameObject MaskItem
		{
			get
			{
				return _maskItem;
			}

			set
			{
				_maskItem = value;
			}
		}

		public GameObject Target
		{
			get
			{
				return _target;
			}

			set
			{
				_target = value;
				MaskTargetPosition();
			}
		}

        #region EditorSetup
		[ContextMenu("Setup")]
        private void Setup()
        {
			if (_blackPanel == null)
			{
				_blackPanel = GetComponentInChildren<CanvasGroup>();

			}
			if (_maskItem == null)
            {
				_maskItem = GetComponentsInChildren<Image>()
					.Select((arg) => arg.gameObject)
					.Single((go) => go != _blackPanel.gameObject);
            }

        }
		#endregion

		#region MonoBehavior Methods
        void Awake()
		{
			_blackPanel.blocksRaycasts = false;

		}
        #endregion

		public void FadeIn()
		{
			gameObject.SetActive(true);
			_blackPanel.DOFade(1, _duration);         
		}
        
		public void FadeOut()
        {
			_blackPanel.DOFade(0, _duration);
        }

		void MaskTargetPosition()
        {
            //Vector3 btnPosition = _btnItem.transform.position;
			_maskItem.transform.position = _target.transform.position;

        }

	}


}
