using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeContent : MonoBehaviour {
	[SerializeField] string newContent;
	[SerializeField] GameObject textContainer;
	private TextMeshPro warningText;

	// Use this for initialization
	void Start () {
		warningText = GetComponent<TextMeshPro>();
	}

	public void ChangeText()
	{
		warningText.text = newContent;
	}

}
