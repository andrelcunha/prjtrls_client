using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionsController : MonoBehaviour {

    [SerializeField] CheckBoxController checkBoxMusic;
    [SerializeField] CheckBoxController checkBoxSFx;
    DataController _dataController;

    void Start () {
        _dataController = DataController.Instance;
        //LoadOptions();
    }
    
    void Update () {
        
    }

    public void SaveOptions(){
        _dataController.Options.musicEnable = checkBoxMusic.isChecked;
        _dataController.Options.soundFxEnable = checkBoxSFx.isChecked;
        _dataController.SaveOptions();
    }

    public void LoadOptions()
    {
        _dataController.Loadptions();
        checkBoxMusic.isChecked = _dataController.Options.musicEnable;
        checkBoxSFx.isChecked = _dataController.Options.soundFxEnable;
    }
}
