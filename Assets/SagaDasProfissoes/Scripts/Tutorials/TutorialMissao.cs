using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using _2MuchPines.PlugglableTweens;
using DG.Tweening;
using UnityEngine.UI;
using Trilhas.Controller;

namespace Trilhas.Tutorials
{
	public class TutorialMissao : MonoBehaviour
	{
		[SerializeField] bool tutorialActive;
		[SerializeField] bool _playOnAwake;

		[SerializeField] DialogController _dialogController;

		[SerializeField] Dialog[] _dialogs;

		[SerializeField] TweenEffect _dialogTween;

		[SerializeField] CanvasGroup _blackPanelMissions;
		[SerializeField] CanvasGroup _blackPanelAceitar;
		[SerializeField] CanvasGroup _btnAceitar;
		[SerializeField] CanvasGroup _btnMochila;
		[SerializeField] CanvasGroup _btnMission;


		CanvasGroup[] _buttons;

		[SerializeField] float _duration;

		//[SerializeField] private UnityAction action1;
		private UnityAction action2;

		private Button _btnMissionButton;
		private Button _btnAceitarButton;

		private UnityEvent _action;

		[SerializeField] Button _btnDialogButton;


		enum ButtonName
		{
			missao,
			aceitar,
			mochila
		};

		void Start()
		{
			_buttons = new CanvasGroup[] { _btnMission, _btnAceitar, _btnMochila };
			try
			{
				_btnMissionButton = _btnMission.GetComponent<Button>();
				_btnAceitarButton = _btnAceitar.GetComponent<Button>();
			}
			catch (System.Exception e) {
				Debug.LogWarning("Exception" + e);
			}
			if (_dialogTween.onRewind.Length < 1)
            {
				_dialogTween.onRewind = new UnityEvent[] { new UnityEvent() };			
            }
			_action = _dialogTween.onRewind[_dialogTween.onRewind.Length - 1];

			if (_playOnAwake)
			{
				DoAction(1);
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
                    LoadDialog(_dialogs[0]);
					ShowMentor();
					_action.AddListener(FadeInBlackPanelMission);
					break;
                    
				case 2:
					//show black mask over mission
					//EnableButton((int)ButtonName.missao);
					//_blackPanelMissions.blocksRaycasts = false;
					//_blackPanelMissions.DOFade(1, _duration);
					//_action.RemoveListener(FadeInBlackPanelMission);
					//_btnMissionButton.onClick.AddListener(FadeOutBlackPanelMission);
					break;

				case 3:
					//FadeOutBlackPanelMission();
                    //Hide black mask and show second dialog
					//_blackPanelMissions.interactable = false;
					//_blackPanelMissions.DOFade(0, _duration);
					//LoadDialog(_dialogs[0]);
                    //ShowMentor();
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
					//Debug.LogWarningFormat("Action {0} not found",sequence);
					break;
			}
		}

		void ShowMentor(){
			_dialogTween.StartTween();
		}

		void LoadDialog(Dialog dialog){
			_dialogController.Dialogo = dialog;
		}

        void EnableButton(int val)
		{
			for (int i = 0; i < _buttons.Length;i++)
			{
				if (i==val)
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
			foreach(var btn in _buttons)
			{
				btn.blocksRaycasts = true;
			}
        }

		void FadeInBlackPanelMission()
        {
			_action.RemoveAllListeners();
			EnableButton((int)ButtonName.missao);
            _blackPanelMissions.blocksRaycasts = false;
            _blackPanelMissions.DOFade(1, _duration);
			_btnMissionButton.onClick.AddListener(FadeOutBlackPanelMission);

			//_action.RemoveListener(FadeInBlackPanelMission);

			_action.AddListener(FadeInBlackPanelAceitar);
			//Debug.Log(_action.)
		}
        
        void FadeOutBlackPanelMission()
		{
			_btnMissionButton.onClick.RemoveListener(FadeOutBlackPanelMission);
			Debug.Log("Called Panel Mission");
			_blackPanelMissions.DOFade(0, _duration);
			_dialogController.ResetIndex();
            LoadDialog(_dialogs[1]);
            ShowMentor();         
		}

		void FadeInBlackPanelAceitar()
		{
			Debug.Log("Called panel Aceitar");
			EnableButton((int)ButtonName.aceitar);
            _blackPanelAceitar.blocksRaycasts = false;
            _blackPanelAceitar.DOFade(1, _duration);
			_btnAceitarButton.onClick.AddListener(FadeOutBlackPanelAceitar);
		}

		void FadeOutBlackPanelAceitar()
        {
			Debug.Log("Called button Aceitar");
            _blackPanelAceitar.DOFade(0, _duration);
        }
	}
}
