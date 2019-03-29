using UnityEngine;
using System;

public class EventListener : MonoBehaviour {
    [SerializeField] string successStr;
    [SerializeField] string failureStr;


    void OnEnable(){
        if(successStr.Length>0)
            EventManager.StartListening(successStr,OnSucessTrigger);
        if (failureStr.Length > 0)
            EventManager.StartListening(failureStr,OnFailureTrigger);
    }

    void OnDisable(){
        if (successStr.Length > 0)
            EventManager.StopListening(successStr, OnSucessTrigger);
        if (failureStr.Length > 0)
            EventManager.StopListening(failureStr, OnFailureTrigger);
    }


    void OnSucessTrigger(){
        try{
            gameObject.SendMessage("OnSucess");
        }
        catch (Exception e){
            Debug.LogException(e, this);
        }
    }

    void OnFailureTrigger(){
        try
        {
            gameObject.SendMessage("OnFailure");
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

    }
}
