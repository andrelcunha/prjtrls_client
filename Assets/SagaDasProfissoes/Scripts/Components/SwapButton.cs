using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class SwapButton : MonoBehaviour {
	[SerializeField] bool _isPressed;
	Button _button;
	#region Properties
    public bool IsPressed
    {
        get { return _isPressed; }
        set
        {
			if (_isPressed !=value)
            {
                Press();
            }
        }
    }
    #endregion


	void Awake()
    {
		_button = GetComponent<Button>();
		SetPressed(_isPressed);
    }

	public void Press()
    {
        _isPressed = !_isPressed;
		SetPressed(_isPressed);
    }

	private void SetPressed(bool isVisible)
    {
		_button.interactable = !isVisible;
		Debug.Log("isVisible:" + _button.interactable.ToString());
    }
}
