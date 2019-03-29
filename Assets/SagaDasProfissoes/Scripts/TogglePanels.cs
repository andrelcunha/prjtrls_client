using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanels : MonoBehaviour
{

	[SerializeField] GameObject _panelA;
	[SerializeField] GameObject _panelB;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ExecuteTogglePanels()
	{

		_panelB.SetActive(_panelA.activeSelf);
		_panelA.SetActive(!_panelA.activeSelf);
	}
}
