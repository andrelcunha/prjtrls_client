using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trilhas.Controller
{
	public class RewardController : MonoBehaviour
	{
		[SerializeField] RewardSummary[] rewards;


		public enum RewardName
		{
			ENG,
			HUM,
			NEG,
			SAU,
			SESUs
		};
	}
}
