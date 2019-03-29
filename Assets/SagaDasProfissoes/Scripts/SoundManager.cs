using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource clickfxSource;     
    public AudioSource efxSource;                   
    [SerializeField] AudioClip[] _musicArray;
    [SerializeField] AudioClip[] _sFxArray;
    //public static SoundManager instance;                 
    [Tooltip("The lowest a sound effect will be randomly pitched.")]
    public float lowPitchRange = .95f;
    [Tooltip("The highest a sound effect will be randomly pitched.")]
    public float highPitchRange = 1.05f;            


    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (SoundManager)FindObjectOfType(typeof(SoundManager));
                if (_instance == null)
                {
                    GameObject go = new GameObject("SoundManager:Singleton");
                    _instance = go.AddComponent<SoundManager>();
                }
            }
            return _instance;
        }
        set
        {
            if (_instance == null)
                _instance = value;
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);

    }
    void Start(){
        PlayMusic(MusicClip.PlayerMenu);
    }

    void OnDisable()
    {
        Instance = null;
    }

    public void PlayMusic(MusicClip clip)
    {
        Debug.Log("Index:" + (int)clip + " name:" + clip.ToString());
        Debug.Log("Array length" + _musicArray.Length);
        musicSource.clip = _musicArray[(int)clip];
        musicSource.Play();
    }

    public void PlayMusic(int clip){
        PlayMusic((MusicClip) clip);
    }

    public void PlayOtherSfx(SFxClip sfxClip)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.clip = _sFxArray[(int)sfxClip];
        efxSource.Play();
    }

    public void PlayOtherSfx(int sfxClip)
    {
        PlayOtherSfx((SFxClip)sfxClip);
    }

    public void PlayClickSfx()
    {
        PlayOtherSfx(SFxClip.ClickButtonMenu);
    }

    void OnSucess(){
        PlayOtherSfx(SFxClip.Plim);
    }

}
