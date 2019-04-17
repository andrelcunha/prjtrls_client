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
	public class TutorialArena: MonoBehaviour
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
        [SerializeField] TweenController _tweenController;
		TweenEffect _lastTween;

		
		private Button _btnDialogButton
		{
			get{
				return _dialogController.DialogButton;
			}
		}

        [SerializeField] TweenEffect _tweenPopup;
        [SerializeField] ArenaController arenaController;


        [SerializeField] Button _btnPopupOK;
		Button[] _buttons;

        [SerializeField] float _duration;

        private UnityEvent _actionDialogRewind;
		private UnityEvent _firstAction;
       
               

        void Start()
        {
            _lastTween = _tweenController.OnPlay[_tweenController.OnPlay.Length - 1];
			tutorialActive = UserController.Instance.TutorialActive;
            if (_dialogTween.afterRewind.Length < 1)
            {
                _dialogTween.afterRewind = new UnityEvent[] { new UnityEvent() };
            }
            _actionDialogRewind = _dialogTween.afterRewind[0];

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
                    LoadDialog(_dialogs[0]);
                    ShowMentor();
                    _actionDialogRewind.AddListener(delegate {
						DoAction(2);
					});
                    break;

                case 2:
					_actionDialogRewind.RemoveAllListeners();
                    arenaController.GiveTicket(20, true);
                    if (_tweenPopup.afterRewind.Length < 1)
                    {
                        _tweenPopup.afterRewind = new UnityEvent[] { new UnityEvent() };
                    }
                    var nextAction = _tweenPopup.afterRewind[0];
                    nextAction.AddListener(delegate
                    {
                        DoAction(3);
                    });
                    break;

                case 3:
                    _actionDialogRewind.RemoveAllListeners();
                    LoadDialog(_dialogs[1]);
                    ShowMentor();
                    _actionDialogRewind.AddListener(delegate 
                    {
                        DoAction(4);
                    });
                    break;

                case 4:
                    LoadDialog(_dialogs[2]);
                    ShowMentor();
                    _actionDialogRewind.RemoveAllListeners();
                    _actionDialogRewind.AddListener(delegate 
                    {
                        Debug.Log("Dialog is over");
                    });
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

        IEnumerator my_corrotine()
        {
            yield return new WaitForSeconds(.1f);
            _dialogTween.StartTween();
        }

    }
}
