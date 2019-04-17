using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                 
public class CheckBoxController : MonoBehaviour {
    /*
    [Header("Checkbox configuration")]
    [Tooltip("This checkbox group is boolean?")]
    [SerializeField]
    bool _isBoolean = true;
    [Tooltip("First box is 'True'?")]
    [SerializeField]
    bool _isFirstTrue = true;
    */
    CheckBox[] checkboxArray;
    Button[] buttonsArray;
    private int _current;


    public bool isChecked
    {
        get
        {
            return GetChecked();
        }
        set 
        {
            SetChecked(value);        
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

    void Start () {
        checkboxArray = GetComponentsInChildren<CheckBox>();
        buttonsArray = GetComponentsInChildren<Button>();
        SetListeners();
        //checkboxArray[_current].Check();
    }
    

    void SetListeners(){
        foreach (var button in buttonsArray)
        {
            button.onClick.AddListener(delegate { SetChecked(button.gameObject); });

        }
    }

    public void SetChecked(GameObject gameObject)
    {
        if (gameObject.GetComponent<CheckBox>().IsChecked)
            return;
        foreach (var cb in checkboxArray)
        {
            cb.Check();
        }
    }

    private bool GetChecked(){
        return checkboxArray[0].IsChecked && !checkboxArray[1].IsChecked;
    }

    public void SetChecked(bool value)
    {
        checkboxArray[0].IsChecked = value;
        checkboxArray[1].IsChecked = !value;
    }

}
