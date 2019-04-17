using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                 
public class SwapButtonController : MonoBehaviour
{
	SwapButton[] swapButtonsArray;
    Button[] buttonsArray;
	[SerializeField]private int _current;

	#region Properties
    public bool isPressed
    {
        get
        {
            return GetPressed();
        }
        set
        {
            SetPressed(value);
        }

    }

    public int Current
    {
        get { return _current; }
        set
        {
            if (value != _current)
            {
                _current = value;
            }
        }
    }
	#endregion

    void Start()
    {
		swapButtonsArray = GetComponentsInChildren<SwapButton>();
        buttonsArray = GetComponentsInChildren<Button>();
        SetListeners();
		SetPressed();
    }


    void SetListeners()
    {
        foreach (var button in buttonsArray)
        {
			button.onClick.AddListener(delegate { SetPressed(button.gameObject); });
            
        }
    }

	public void SetPressed(GameObject go)
    {
		if (go.GetComponent<SwapButton>().IsPressed)
            return;
		/*
		go.GetComponent<SwapButton>().IsPressed = true;
		int newCurrent = 0;
		for (int i = 0; i < swapButtonsArray.Length;i++)
		{
			if (swapButtonsArray[i].gameObject.GetInstanceID() == go.GetInstanceID())
			{
				Debug.Log("Aqui");
				newCurrent = i;
				//swapButtonsArray[i].IsPressed = true;
				swapButtonsArray[i].Press();
			}else if (Current  == i )
			{
				Debug.Log("Aqui tb");
				//swapButtonsArray[i].IsPressed = false;
				swapButtonsArray[i].Press();
			}
		}
		Current = newCurrent;
        */
        foreach (var cb in swapButtonsArray)
        {
            cb.Press();
        }
    }

	private bool GetPressed()
    {
		return swapButtonsArray[0].IsPressed && !swapButtonsArray[1].IsPressed;
    }

	public void SetPressed(bool value)
    {
		swapButtonsArray[0].IsPressed = value;
		swapButtonsArray[1].IsPressed = !value;
        /*
		for (int i = 0; i < swapButtonsArray.Length; i++)
        {
            swapButtonsArray[i].IsPressed = i != Current;
            swapButtonsArray[i].Press();
        }*/
    }

	public void SetPressed(){
		for (int i = 0; i < swapButtonsArray.Length; i++)
        {
			swapButtonsArray[i].IsPressed = i != Current;
            swapButtonsArray[i].Press();
        }
	}

}
