using UnityEngine;
using UnityEngine.UI;
using Trilhas.Utilities;
using Trilhas.JsonFormat;

[RequireComponent(typeof(CanvasGroup))]
public class MessageManager : MonoBehaviour {
    [SerializeField] Text messageText;
    private CanvasGroup canvasGroup;
    private string _message;
    private Connection _conn;

    public string Message
    {
        get { return _message; }
        set
        {
            if (value != _message)
            {
                _message = value;
                messageText.text = _message;
            }
            if (value.Length > 0)
            {
                if (canvasGroup.alpha < 1)
                {
                    canvasGroup.alpha = 1f;
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                }
            }else{
                if (canvasGroup.alpha >0)
                {
                    canvasGroup.alpha = 0f;
                    canvasGroup.interactable = false;
                    canvasGroup.blocksRaycasts = false;
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        _conn = Connection.Instance;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void OnFailure(){
        var jsonStr = _conn.JsonResponse;
        JsonResponse jsonRx;
		try
		{
			jsonRx = JsonUtility.FromJson<JsonResponse>(jsonStr);
			if (jsonRx.erros.Count > 0)

				foreach (var erro in jsonRx.erros)
				{
					Debug.Log("ERRO:" + erro.mensagem);
					Message += _message + erro.mensagem;
				}
		}
		catch (System.Exception e)
		{
			//Debug.LogException(e, this);
			Debug.Log("There was an exception!");
		}

    }

    void OnSucess()
    {
        CleanAndClose();
    }

    public void CleanAndClose(){
        Message = "";
    }
}
