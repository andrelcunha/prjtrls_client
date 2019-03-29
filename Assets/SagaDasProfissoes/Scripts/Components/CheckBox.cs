using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(CanvasGroup))]

public class CheckBox : MonoBehaviour {

    Image checkMark;
    CanvasGroup canvasGroup;
    [SerializeField] bool _isChecked;

    #region Properties
    public bool IsChecked
    {
        get { return _isChecked; }
        set
        {
            if (value != _isChecked)
            {
                Check();
            }
        }
    }
    #endregion

    void Awake(){
        checkMark = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();
        SetAlpha(_isChecked); 
    }

	void Start () {
       
	}


    public void Check(){
        _isChecked = !_isChecked;
        SetAlpha(_isChecked);
    }

    /// <summary>
    /// Sets the alpha.
    /// </summary>
    /// <param name="isVisible">If set to <c>true</c> is visible.</param>
    private void SetAlpha(bool isVisible){
        float alpha = _isChecked ? 1 : 0;
        canvasGroup.alpha = alpha;
    }
}
