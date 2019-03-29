using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Trilhas;

[CreateAssetMenu(fileName = "AllMentors", menuName = "All Mentors Data", order = 3)]
public class AllMentors : ScriptableObject
{
    public Mentor empresaria;
    public Mentor engenharia1;
    public Mentor engenharia2;
    public Mentor humanas;
    public Mentor negocios;
    public Mentor saude;
    public Mentor mestre;

    public Mentor MentorByName(MentorName name)
    {
        switch(name)
        {
            case MentorName.EMPRESARIA:
                return empresaria;
            case MentorName.ENGENHARIA1:
                return engenharia1;
            case MentorName.ENGENHARIA2:
                return engenharia2;
            case MentorName.HUMANAS:
                return humanas;
            case MentorName.NEGOCIOS:
                return negocios;
            case MentorName.SAUDE:
                return saude;
            case MentorName.MESTRE:
                return mestre;
            default:
                throw new System.ArgumentException("Value does not exists in MentorName", name.ToString());
        }
    }

}
