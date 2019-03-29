using System;
namespace Trilhas.Tutorials
{
    [Serializable]
    public class TutorialData
    {
        public bool[] boolArray;
        int status;
    
        void GetStatus()
        {
            int val = 0;
            for (int i = 0; i < boolArray.Length; i++)
            {
                val += boolArray[i] ? 1 << i : 0;
            }
        }


    }

    
}
