using System;
using UnityEngine;
using UnityEngine.UI;
//using System.Linq;

public class MissionPointManager:MonoBehaviour
{
	MissionPoint[] missions;
	[SerializeField] bool _initialVisibility;


    void Awake()
	{
		missions = gameObject.GetComponentsInChildren <MissionPoint>();

	}

    void Start()
	{
		foreach (var mission in missions)
        {
            mission.IsVisible = _initialVisibility;
        }
	}

	public void ToggleVisibility(bool useTween = false)
	{
		foreach(var mission in missions)
		{
			mission.ToggleVisibility(useTween);
		}
	}
}

