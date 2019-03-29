using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using _2MuchPines.PlugglableTweens;
using DG.Tweening;
using UnityEngine.UI;
using _2MuchPines.Templates;
using Trilhas.Controller;

namespace Trilhas.Tutorials
{
	public class TutorialMap : MonoBehaviourSingleton<TutorialMap>
    {
        [SerializeField] 
		bool _tutorialActive;
        //[SerializeField] 
		bool _playOnAwake;

        [SerializeField] DialogController _dialogController;

        [SerializeField] Dialog[] _dialogs;

        [SerializeField] TweenEffect _dialogTween;
		[SerializeField] TweenEffect _carouselTween;

		[SerializeField] CarouselController _carousel;

		[SerializeField] Transform _firstMissonTransform;

		[SerializeField] Button _btnDialogButton;

		[SerializeField] CameraFocusController camController;

		[SerializeField] CanvasGroup _btnAvatar;
		[SerializeField] CanvasGroup _btnCart;
		[SerializeField] CanvasGroup _btnArena;

		[SerializeField] CanvasGroup _blackPanelAvatar;
        [SerializeField] CanvasGroup _blackPanelCart;
		[SerializeField] CanvasGroup _blackPanelArena;
		CanvasGroup[] _buttons;


		private Button _btnAvatarButton;
		private Button _btnCartButton;
		private Button _btnArenaButton;


		[SerializeField] float _duration;
        

		private UnityEvent _action; 
		private UnityEvent _actionCarousel;

		//private bool _firstMissionCompleted;
		//private bool _shoppingCompleted;

		enum ButtonName
		{
			avatar,
			cart,
			arena
		};

		void Start()
        {
			_tutorialActive = UserController.Instance.TutorialActive;
			//_firstMissionCompleted = UserController.Instance.TutorialMissionOk;
			//_shoppingCompleted = UserController.Instance.TutorialShoppingOk;
			_buttons = new CanvasGroup[] { _btnAvatar, _btnCart, _btnArena };
			_btnAvatarButton = _btnAvatar.GetComponent<Button>();
			_btnCartButton = _btnCart.GetComponent<Button>();
			_btnArenaButton = _btnArena.GetComponent<Button>();

			if (_dialogTween.onRewind.Length < 1)
            {
				_dialogTween.onRewind = new UnityEvent[] { new UnityEvent() };
            }
			_action = _dialogTween.onRewind[_dialogTween.onRewind.Length - 1];


			if (_carouselTween.onRewind.Length < 1)
            {
				_carouselTween.onRewind = new UnityEvent[] { new UnityEvent() };
            }           
			_actionCarousel = _carouselTween.onRewind[_carouselTween.onRewind.Length - 1];


            if (_playOnAwake)
            {
                DoAction(1);
            }         
        }

        public void DoAction(int sequence)
        {
            if (!_tutorialActive)
                return;
            switch (sequence)
            {
                case 1:
					switch ((int)UserController.Instance.TutorialState)
					{
						case (int)TutorialState.ATIVO:
							LoadDialog(_dialogs[0]);
							ShowMentor();
							_action.AddListener(FadeInPopUp);
							break;
						case (int)TutorialState.PRIMEIRA_MISSAO:
							LoadDialog(_dialogs[2]);
							ShowMentor();
							_action.AddListener(FadeInBlackPanelCart);
							break;
						case (int)TutorialState.LOJA:
							LoadDialog(_dialogs[3]);
							ShowMentor();
							_action.AddListener(FadeInBlackPanelAvatar);
							break;
						case (int)TutorialState.MOCHILA:
							LoadDialog(_dialogs[4]);
							ShowMentor();
							_action.AddListener(FadeInBlackPanelAvatar);
							break;
					}

                    break;
                    
                case 2:
					FadeOutPopUp();
                    break;     
				
				case 3:
                    //Show first dialog
                    LoadDialog(_dialogs[2]);
                    ShowMentor();
                    _action.AddListener(FadeInPopUp);
                    break;
                default:
                    Debug.LogWarningFormat("Action {0} not found",sequence);
                    break;
            }
        }

        void ShowMentor()
        {
            _dialogTween.StartTween();
        }

        void LoadDialog(Dialog dialog)
        {
            _dialogController.Dialogo = dialog;
        }
  
        void FadeInPopUp()
        {
            _action.RemoveAllListeners();
			_action.AddListener(MissionFocus);

			_actionCarousel.RemoveAllListeners();
			_actionCarousel.AddListener(FadeOutPopUp);
			_carousel.SetVisible(true);
			_carouselTween.StartTween();
        }

        void FadeOutPopUp()
        {
			LoadDialog(_dialogs[1]);
			_dialogController.ResetIndex();
			_carousel.SetVisible(false);
             ShowMentor();
        }

        void MissionFocus()
        {
            Debug.Log("Foco na missao!");
			camController.Target = _firstMissonTransform;
			camController.DoFocus();
        }

		void FadeInBlackPanelCart()
        {
            Debug.Log("Called panel cart");
			EnableButton((int)ButtonName.cart);
			_blackPanelCart.blocksRaycasts = false;
			_blackPanelCart.DOFade(1, _duration);
			_btnCartButton.onClick.AddListener(FadeOutBlackPanelCart);
        }

        void FadeOutBlackPanelCart()
        {
            Debug.Log("Called button cart");
			_blackPanelCart.DOFade(0, _duration);

        }

		void FadeInBlackPanelAvatar()
        {
            Debug.Log("Called panel Avatar");
			EnableButton((int)ButtonName.avatar);
			_blackPanelAvatar.blocksRaycasts = false;
			_blackPanelAvatar.DOFade(1, _duration);
			_btnAvatarButton.onClick.AddListener(FadeOutBlackPanelAvatar);
        }

		void FadeOutBlackPanelAvatar()
        {
            Debug.Log("Called button Avatar");
			_blackPanelAvatar.DOFade(0, _duration);

        }

		void EnableButton(int val)
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                if (i == val)
                {
                    _buttons[i].blocksRaycasts = true;
                }
                else
                {
                    _buttons[i].blocksRaycasts = false;
                }
            }
        }

        void EnableAllButtons()
        {
            foreach (var btn in _buttons)
            {
                btn.blocksRaycasts = true;
            }
        }
  
    }
}
