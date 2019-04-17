using UnityEngine;
using _2MuchPines.Templates;
using System;
using System.Linq;
using Trilhas.JsonFormat;
using TMPro;

namespace Trilhas.Components.MenuMochila
{
	public class MochilaSlotController:MonoBehaviourSingleton<MochilaSlotController>
    {
		[SerializeField] MochilaSlot[] _slots;
		[SerializeField] TextMeshProUGUI[] _bonusTMPro;
		[SerializeField] MochilaSlot[] _avaliableSlots;

        #region Properties
		public int BonusEng 
		{ 
			get
			{
				EixoNome eixo = EixoNome.ENGENHARIA;
				return GetBonus(eixo);
			}

		}

		public int BonusHum 
		{
			get
            {
				EixoNome eixo = EixoNome.HUMANAS;
				return GetBonus(eixo);
            }
		}
		public int BonusNeg 
		{
			get
            {
				EixoNome eixo = EixoNome.NEGOCIOS;
				return GetBonus(eixo);
            }
		}

		public int BonusSau 
		{
			get
            {
				EixoNome eixo = EixoNome.SAUDE;
				return GetBonus(eixo);
            }
		}

		public MochilaSlot[] AvaliableSlots
        {
            get
            {
				//return _slots.Where(field => field.Status == MochilaSlotStatus.empty).ToArray();
				if (_avaliableSlots == null)
				{
					UpdateAvaliableSlots();
				}
				return _avaliableSlots;
            }
        }

		public MochilaSlot[] Slots
		{
			get
			{
				return _slots;
			}

			set
			{
				_slots = value;
			}
		}
		#endregion
        
        void Awake()
		{
			//UpdateBonusPanel();
		}

        void Start()
		{
			//UpdateBonusPanel();
		}

		public bool EquipItem(Mochila item)
        {
            
            if (AvaliableSlots.Length == 0)
            {
                Debug.Log("there is no room avaliable");
				return false;
            }
            else
            {
                var slot = AvaliableSlots.First();
                slot.ItemMochila = item;
				UpdateBonusPanel();
				UpdateAvaliableSlots();
				return true;
            }
        }

		public int GetBonus(EixoNome eixo)
        {
            int bns = _slots.Where(field => field.Status == MochilaSlotStatus.full)
                                .Select((item) => item.ItemMochila)
                                .Where((item) => item.eixo == eixo)
                                 .Select((x) => x.bonus).Sum();
            return bns;
        }

        private void UpdateBonusPanel()
		{
			_bonusTMPro[(int)EixoNome.ENGENHARIA].text = BonusEng.ToString();
			_bonusTMPro[(int)EixoNome.HUMANAS].text = BonusHum.ToString();
			_bonusTMPro[(int)EixoNome.NEGOCIOS].text = BonusNeg.ToString();
			_bonusTMPro[(int)EixoNome.SAUDE].text = BonusSau.ToString();
		}

        public void UpdateAvaliableSlots()
		{
			_avaliableSlots = _slots.Where(field => field.Status == MochilaSlotStatus.empty).ToArray();
			Debug.Log("Avaliable: " + AvaliableSlots.Length);

		}


    }
}
