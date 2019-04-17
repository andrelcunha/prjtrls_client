using System;
using UnityEngine;
using Trilhas.Tutorials;

namespace Trilhas.Controller
{
	public class MapController : MonoBehaviour
	{
		[SerializeField] TutorialMap _tutorial;
		public void AnimationComplete()
		{
			if (_tutorial != null)
			{
				_tutorial.DoAction(1);
			}
		}
	}
}