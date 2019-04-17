using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MissionPoint:MonoBehaviour
{
    [SerializeField] Sprite _missionLocked;
    [SerializeField] Sprite _missionUnlocked;
    [SerializeField] Sprite _missionActive;
    [SerializeField] Sprite _missionComplete;
    [SerializeField] MissionStatus status;
    Color _fullColor;
    [SerializeField] Color _paleColor;
    [SerializeField] float _duration;
    private Image missionPointImage;
    [SerializeField] bool _isVisible;

    public bool IsVisible
    {
        get
        {
            return _isVisible;
        }

        set
        {
            _isVisible = value;
            SetVisibility();
        }
    }

    private void Awake(){
        missionPointImage = GetComponent<Image>();
        _fullColor = missionPointImage.color;
    }

    private void Start()
    {
        SetStatusIcon();
		//SetVisibility();      
    }
    
    private void SetStatusIcon()
    {
        switch (status)
        {
            case MissionStatus.locked:
                missionPointImage.sprite = _missionLocked;
                break;
            case MissionStatus.unlocked:
                missionPointImage.sprite = _missionUnlocked;
                break;
            case MissionStatus.active:
                missionPointImage.sprite = _missionActive;
                break;
            case MissionStatus.complete:
                missionPointImage.sprite = _missionComplete;
                break;
        }
         
    }

    public void ToggleVisibility(bool useTween=false)
    {
		_isVisible = !_isVisible;
		if (useTween)
        {
            TweenVisibility();
        }
        else
        {
            SetVisibility();
        }
    }

    public void SetVisibility()
    {
        Color newColor = IsVisible ? _fullColor : _paleColor;
        missionPointImage.color = newColor;
    }
    
    public void TweenVisibility()
    {
        Color newColor = IsVisible ? _fullColor : _paleColor;
        missionPointImage.DOColor(newColor, _duration);
    }    
    
}

