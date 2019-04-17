using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace Trilhas.Tutorials
{
    public class CarouselItem : MonoBehaviour
    {
        public void DoMove(float offset, float duration)
		{
			var pos = gameObject.transform.position.x;
			gameObject.transform.DOMoveX(pos + offset, duration).SetEase(Ease.Linear);
		}

		public void SetPosition(float offset)
		{
			var newPosX = gameObject.transform.position.x + offset;
			gameObject.transform.position = new Vector3(newPosX, gameObject.transform.position.y, gameObject.transform.position.z);
		}

    }
}