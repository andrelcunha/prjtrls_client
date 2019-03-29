using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardSummary : MonoBehaviour
{

	[SerializeField] Text _valueText;
	[SerializeField] Text _bonusText;
	[SerializeField] Text _totalText;

	[SerializeField] int _valueInt;
	[SerializeField] int _bonusInt;
	int _totalInt;

	[SerializeField] bool _doUpdate;

	public int ValueInt
	{
		get
		{
			return _valueInt;
		}

		set
		{
			_valueInt = value;
			SetText(_valueInt, _valueText);
		}
	}

	public int BonusInt
	{
		get
		{
			return _bonusInt;
		}

		set
		{
			_bonusInt = value;
			SetText(_bonusInt, _bonusText);

		}
	}

	public int TotalInt
	{
		get
		{
			return _totalInt;
		}

		set
		{
			_totalInt = value;
			SetText(_totalInt, _totalText);
		}
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (_doUpdate)
		{
			SetFields(_valueInt, _bonusInt);
		}
	}

	void SetText(int num, Text txt)
	{
		txt.text = num.ToString();
	}

	void SetFields(int value, int bonus)
	{
		ValueInt = value;
		BonusInt = bonus;
		TotalInt = value + bonus;
	}
}
