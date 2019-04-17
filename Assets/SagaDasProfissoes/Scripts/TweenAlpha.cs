using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class TweenAlpha : MonoBehaviour
{
	private CanvasGroup _canvas;

	[SerializeField] float _duration;
	[SerializeField] float _initialAlpha;
	float _currentAlpha;

	[SerializeField] bool _initialInteractable;
	[SerializeField] bool _initialBlockRaycasts;
	bool _isOn;



	#region Properties
	public bool IsOn
	{
		get
		{
			return _isOn;
		}

		set
		{

			if (value != _isOn)
			{
				_isOn = value;
				InitialInteractable = !InitialInteractable;
				InitialBlockRaycasts = !InitialBlockRaycasts;
			}

		}
	}

	public bool InitialInteractable
	{
		get
		{
			return _initialInteractable;
		}

		set
		{
			_initialInteractable = value;
			_canvas.interactable = value;
		}
	}

	public bool InitialBlockRaycasts
	{
		get
		{
			return _initialBlockRaycasts;
		}

		set
		{
			_initialBlockRaycasts = value;
			_canvas.blocksRaycasts = value;
		}
	}

	#endregion
	void Awake()
	{
		_canvas = GetComponent<CanvasGroup>();
	}

	// Use this for initialization
	void Start()
	{
		_currentAlpha = _initialAlpha;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ToggleCanvas()
	{

		_currentAlpha = _currentAlpha < 1f ? 1f : 0f;
		_canvas.DOFade(_currentAlpha, _duration);
		IsOn = !IsOn;
	}

}
