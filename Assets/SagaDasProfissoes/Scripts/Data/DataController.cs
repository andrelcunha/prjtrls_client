using System.IO;
//using _2MuchPines.Templates;
using UnityEngine;
using Trilhas.JsonFormat;


public class DataController : MonoBehaviour
{

    private GameOptions _options;
	//private UserAvatar _avatar;
	private User _user;

    //private PlayerProgress playerProgress;
    private string gameDataFileName = "data.json";

    #region Singleton
    
    private static DataController _instance;

    public static DataController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (DataController)FindObjectOfType(typeof(DataController));
                if (_instance == null)
                {
                    GameObject go = new GameObject("DataController:Singleton");
                    _instance = go.AddComponent<DataController>();
                }
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    
    #endregion

    #region Properties
    public GameOptions Options
    {
        get { return _options; }
        set
        {
            if (value != _options)
            {
                _options = value;
            }
        }
    }

	public User User
	{
		get
		{
			if(_user == null){
				LoadUser();
			}
			return _user;
		}

		set
		{
			_user = value;
			SaveUser();
		}
	}

	#endregion
  
	void Awake()
    {
        Instance = this;
    }

    void OnDisable()
    {
        Instance = null;
    }  

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        //_options = new GameOptions();
		//_user = new User();
    }

    #region Public Members
    public void Loadptions()
    {
        string optionsAsJson;
        if (PlayerPrefs.HasKey("GameOptions"))
        {
            optionsAsJson = PlayerPrefs.GetString("GameOptions");
        }
        else
        {
            optionsAsJson = Uteis.LoadJson("options");
        }
        _options = JsonUtility.FromJson<GameOptions>(optionsAsJson);
    }

    public void SaveOptions()
    {
        string optionsAsJson = JsonUtility.ToJson(_options);
        //Debug.Log(optionsAsJson);
        PlayerPrefs.SetString("GameOptions", optionsAsJson);
		PlayerPrefs.Save();
    }

	public void LoadUser(){
		string userAsJson;
        if (PlayerPrefs.HasKey("User"))
        {
			userAsJson = PlayerPrefs.GetString("User");
        }
        else
        {
			userAsJson = Uteis.LoadJson("usuario");

        }
		_user = JsonUtility.FromJson<User>(userAsJson);
	}
    
	public static void LoadUser(out User user)
    {
        string userAsJson;
        if (PlayerPrefs.HasKey("User"))
        {
            userAsJson = PlayerPrefs.GetString("User");
        }
        else
        {
            userAsJson = Uteis.LoadJson("usuario");

        }
        user = JsonUtility.FromJson<User>(userAsJson);
    }

	public static void SaveUser(User user)
    {
		string userAsJson = JsonUtility.ToJson(user);
        PlayerPrefs.SetString("User", userAsJson);
        PlayerPrefs.Save();
		Uteis.SaveJson("usuario", userAsJson);
    }

    #endregion


	private void SaveUser()
    {
		SaveUser(_user);
    }
}
