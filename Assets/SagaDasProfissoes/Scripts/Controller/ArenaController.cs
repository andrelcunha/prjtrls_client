using UnityEngine;
//using UnityEngine.UI;
using TMPro;

namespace Trilhas.Controller
{    
    public class ArenaController : MonoBehaviour
	{
		private UserController _userController;
		
        [SerializeField] TicketsPopUpController _ticketsController;
        [SerializeField] TextMeshProUGUI _ticketTMPro;

        void Start()
		{
            _userController = UserController.Instance;
        }

        public void GiveTicket(int ticketsAmount, bool display=false)
        {
            _userController.Tickets += ticketsAmount;
            _userController.SyncUser();
            _ticketsController.DisplayReceivedTickets(ticketsAmount);        
        }

        void UpdateTicketGauge()
        {
            int t = _userController.User.tickets;
            _ticketTMPro.text = t > 0 ? t.ToString() : "";
        }
    }
}

