using UnityEngine;
using Trilhas;

[CreateAssetMenu(fileName = "Mentor", menuName = "Mentor Data", order = 2)]
public class Mentor: ScriptableObject
{  
    public Sprite happy;
    public Sprite angry;
    public Sprite normal;
    public Sprite sad;


    public Sprite SpriteMoodByName(MentorMood name)
    {
        switch (name)
        {
            case MentorMood.HAPPY:
                return happy;
            case MentorMood.ANGRY:
                return angry;
            case MentorMood.NORMAL:
                return normal;
            case MentorMood.SAD:
                return sad;
            default:
                throw new System.ArgumentException("Value does not exists in MentorName", name.ToString());
        }
    }

}
