using UnityEngine;
using UnityEngine.Events;
using TMPro;
using _2MuchPines.PlugglableTweens;


namespace Trilhas.Controller
{
    public class TicketsPopUpController:MonoBehaviour
    {

        [SerializeField] TweenEffect _warningPopup;
        [SerializeField] string popupMsg = "Você recebeu {0} Arena Tickets!";
        private TextMeshProUGUI _warningTMPro;
        private CanvasGroup canvasGroup;

        void Aweke()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        void Start()
        {
            SetTween();
        }

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

        public void DisplayReceivedTickets(int ticketsAmount)
        {
            WarningTMPro.text = string.Format(popupMsg, ticketsAmount);
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
            _warningPopup.StartTween();
        }

        public void HideTickets()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        void SetTween()
        {
            if (_warningPopup.afterRewind.Length == 0)
            {
                _warningPopup.afterRewind = new UnityEvent[1];
                _warningPopup.afterRewind[0] = new UnityEvent();
            }
            _warningPopup.afterRewind[0].AddListener(HideTickets);
        }
    }
}
