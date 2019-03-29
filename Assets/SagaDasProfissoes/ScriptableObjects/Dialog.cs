using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "DialogData", menuName = "Dialog Data", order = 1)]
public class Dialog : ScriptableObject
{
    //public string objectName = "Dialog";
    public string[] dialogArray;
    public MentorMood[] mentorMoods;
	public MentorName mentor;
}