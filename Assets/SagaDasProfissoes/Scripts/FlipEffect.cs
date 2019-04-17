using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class FlipEffect : MonoBehaviour
{

	[SerializeField] private RectTransform rect;
	[SerializeField] bool doFlip;
	[SerializeField] float _90Degrees;
	[SerializeField] float _duration;
	[SerializeField] float _finalAngle;
	[Tooltip("Function called after rewind")]
	[SerializeField] UnityEvent on90Degrees;

	float halfway;

	bool _isFaceUp = true;

	//AvatarSetup avatarSetup;
	void Awake()
	{
		//avatarSetup = GetComponentInChildren<AvatarSetup>();
		//halfway = _finalAngle / 2;
		halfway = _90Degrees;
	}

	void Update()
	{
		if (doFlip)
		{
			doFlip = false;
			Flip();
		}
	}

	public void Flip()
	{

		//var tmp = rect.eulerAngles.y;
		var tmp = _isFaceUp ? _finalAngle : 0f;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(rect.DORotate(new Vector3(0, halfway, 0), _duration));
		//sequence.AppendCallback(avatarSetup.ChangeGender);
		sequence.AppendCallback(PlayOn90Degrees);
		sequence.Append(rect.DORotate(new Vector3(0, tmp, 0), _duration));
		//_finalAngle = tmp;
		Debug.Log("tmp: " + tmp);
		_isFaceUp = !_isFaceUp;


	}

	void Detect90Degrees()
	{
		//if (rect.eulerAngles == new Vector3(0, _90Degrees, 0))
		//avatarSetup.ChangeGender();

	}

	void PlayOn90Degrees()
	{
		Debug.Log("Play after");
		if (on90Degrees.GetPersistentEventCount() == 0)
		{
			Debug.Log("No callback to execute.");
			return;
		}
		else
		{
			on90Degrees.Invoke();
			return;
		}

	}

}
