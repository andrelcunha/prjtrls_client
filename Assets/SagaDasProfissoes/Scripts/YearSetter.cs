using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YearSetter : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] string stringMask;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    
    public void SetYear(int year)
    {
        textMesh.text = string.Format(stringMask, year.ToString());
    }
}
