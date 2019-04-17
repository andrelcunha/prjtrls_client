using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class FlapController : MonoBehaviour {
    [SerializeField] Image[] flapImages;
    [SerializeField] float interval = 0.02f;
    float current_time = 0f;
    int index;
    int last;
    [SerializeField] bool flag_stop;
    private bool isStopped = true;
    private Image[] main_flaps;

    public bool Flag_stop
    {
        get
        {
            return flag_stop;
        }

        set
        {
            flag_stop = value;
        }
    }

    // Use this for initialization
    void Start () {
        //flapImages = GetComponentsInChildren<Image>();
        last = flapImages.Length - 1;
        index = last;
        foreach ( var flap in flapImages)
        {
            flap.enabled = false;
        }
        flapImages[index].enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        isStopped &= flag_stop;
        if (!isStopped)
        {
            StopOnInput();
            if (current_time > interval)
            {
                if (flag_stop && ((index) % 3 == 0))
                {
                    isStopped = true;
                    try
                    {
                        var eixo = flapImages[index].GetComponent<FlapEixo>().Eixo.ToString();
                        Debug.LogFormat("index: {0}, eixo: {1}", index, eixo);
                    }
                    catch {
                        Debug.Log("index: " + index);
                    }
                }
                else { 
                    flapImages[index].enabled = false;
                    index = index == 0 ? last : index - 1;
                    flapImages[index].enabled = true;
                    current_time = 0;
                }
            }
            else
            {
                current_time += Time.deltaTime;
            }
        }
    }
    void StopOnInput()
    {
        if (Input.anyKeyDown)
        {
            flag_stop = true;
        }
    }
}
