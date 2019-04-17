using UnityEngine;
using UnityEngine.Events;
using _2MuchPines.PlugglableTweens;
using DG.Tweening;
using UnityEngine.UI;
using Trilhas.Controller;
using System.Linq;
using System.Collections;
using _2MuchPines.InvertedMask;

namespace Trilhas.Tutorials
{
	public class TutorialShop : MonoBehaviour
	{
		[SerializeField] bool tutorialActive;
		[SerializeField] bool _playOnAwake;

		[SerializeField] DialogController _dialogController;

		[SerializeField] Dialog[] _dialogs;

		private TweenEffect _dialogTween
		{
			get
			{
				return _dialogController.Effect;
	

			}
		}
		[SerializeField] TweenEffect _lastTween;

		[SerializeField] CanvasGroup _blackPanelItem;	

		[SerializeField] string itemName;
		[SerializeField] Button _btnExit;

		[SerializeField] Button[] _shoppingButtonSet;
		//[SerializeField] Button _btnPopUpBuy;
		//[SerializeField] Button _btnConfirmBuy;
		private Button _btnDialogButton
		{
			get{
				return _dialogController.DialogButton;
			}
		}

		private Button _btnLastActon {
			get
			{
				int lastItem = _shoppingButtonSet.Length - 1;
				return _shoppingButtonSet[lastItem];
			}
        }
        [SerializeField] DynamicMask _dynamicMask;
        Button _btnItem;
        Button[] _buttons;
        [SerializeField] float _duration;

        private UnityEvent _action;
        private UnityEvent _firstAction;

        void Start()
        {
            Debug.Log("Tutorial State = " + UserController.Instance.TutorialState);
            tutorialActive = UserController.Instance.TutorialActive;
            tutorialActive &= UserController.Instance.TutorialState == TutorialState.LOJA ||
                UserController.Instance.TutorialState == TutorialState.MOCHILA;

            if (_dialogTween.onRewind.Length < 1)
            {
                _dialogTween.onRewind = new UnityEvent[] { new UnityEvent() };
            }
            //_action = _dialogTween.onRewind[_dialogTween.onRewind.Length - 1];
			_action = _dialogTween.onRewind[0];

            if (_playOnAwake)
            {
                DoAction(1);
            }
			else
			{
				if (_lastTween.onPlay.Length < 1)
                {
					_lastTween.onPlay = new UnityEvent[] { new UnityEvent() };
                }
				_firstAction = _lastTween.onPlay[0];
				_firstAction.AddListener(delegate {
				    DoAction(1);
				});
			}
        }

        public void DoAction(int sequence)
        {
            if (!tutorialActive)
                return;
            switch (sequence)
            {
                case 1:
                    //Show first dialog
					_buttons = FindObjectsOfType<Button>();
					_btnItem = _buttons.First(x => (x.name == itemName) );


                    LoadDialog(_dialogs[0]);
                    ShowMentor();
                    _action.AddListener(delegate 
                    {
						DoAction(2);
					});
                    break;

                case 2:
					_action.RemoveAllListeners();
                    EnableButton(_btnItem);
                    _dynamicMask.Target = _btnItem.gameObject;
                    _dynamicMask.FadeIn();
					_btnItem.onClick.AddListener(delegate {
                        DoAction(3);
                    });
                    break;

                case 3:
					//_btnPopUpBuy.interactable = true;
					//_btnConfirmBuy.interactable = true;
					//_btnLastActon.interactable = true;
					foreach (var btn in _shoppingButtonSet)
					{
						btn.interactable = true;
					}
					_btnItem.onClick.RemoveListener(delegate {
                        DoAction(4);
                    });
                    _dynamicMask.FadeOut();
                    _btnLastActon.onClick.AddListener(FinishShopping);          
                    break;

                case 4:
                    //show black mask over mission
                    //EnableButton((int)ButtonName.aceitar);
                    //_blackPanelAceitar.blocksRaycasts = false;
                    //_blackPanelAceitar.DOFade(1, _duration);
                    break;

                case 5:
                    //Hide black mask
                    //_blackPanelAceitar.blocksRaycasts = false;
                    //_blackPanelAceitar.DOFade(0, _duration);
                    break;

                default:
                    Debug.LogWarningFormat("Action {0} not found",sequence);
                    break;
            }
        }

        void ShowMentor()
        {
            StartCoroutine(my_corrotine());
        }

        void LoadDialog(Dialog dialog)
        {
            _dialogController.Dialogo = dialog;
            _dialogController.ResetIndex();

        }
        
		void EnableButton(Button button)
        {
			button.interactable = true;
			var collection = _buttons.Where(x => (x != button));
			foreach (var btn in collection)
			{
				btn.interactable = false;
			}        
        }

        void EnableAllButtons()
        {
            foreach (var btn in _buttons)
            {
				btn.interactable  = true;
            }
        }
       
        /*
        void FadeInBlackPanelItem()
        {
			_action.RemoveAllListeners();
			EnableButton(_btnItem);
			_dynamicMask.Target = _btnItem.gameObject;
			_dynamicMask.FadeIn();
            _btnItem.onClick.AddListener(FadeOutBlackPanelItem);
        }*/

        /*
        void FadeOutBlackPanelItem()
        {
			_btnPopUpBuy.interactable = true;
            _btnConfirmBuy.interactable = true;
			_btnPopupWarning.interactable = true;
			//goExitParent.SetActive(true);
            //goItemParent.SetActive(false);
			_btnItem.onClick.RemoveListener(FadeOutBlackPanelItem);
			_dynamicMask.FadeOut();
            //_blackPanelItem.DOFade(0, _duration);
			_btnPopupWarning.onClick.AddListener(FinishShopping);            
        }*/

        void FinishShopping()
		{
			EnableButton(_btnExit);
			_dialogController.ResetIndex();
            if (_dialogs.Length > 1)
            {
				_btnDialogButton.interactable = true;
				LoadDialog(_dialogs[1]);
				ShowMentor();
            }
            _action.AddListener(FadeInBlackPanelExit);
			_btnLastActon.onClick.RemoveListener(FinishShopping);         
		}

        void FadeInBlackPanelExit()
        {
			EnableButton(_btnExit);
			_dynamicMask.Target = _btnExit.gameObject;
			_dynamicMask.FadeIn();
            _btnExit.onClick.AddListener(FadeOutBlackPanelExit);
        }

        void FadeOutBlackPanelExit()
        {
			_dynamicMask.FadeOut();
			UserController.Instance.SetTutorialShoppingOk(true);
        }

        IEnumerator my_corrotine()
        {
            yield return new WaitForSeconds(.1f);
            _dialogTween.StartTween();
        }

    }
}
