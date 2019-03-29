using UnityEngine;
using TMPro;
using _2MuchPines.Unity_Timer;

public class Timer2TextMesh : MonoBehaviour {

    [SerializeField] Timer _timer;
    [SerializeField] TextMeshProUGUI _textMP;
    string minutes;
    string seconds;

    void Start () {

	}

	void Update () {
        _textMP.SetText( Float2String(_timer.TimeLeft));
	}

  string Float2String(float timer)
  {
      minutes = Mathf.Floor(timer / 60).ToString("00");
      seconds = (timer % 60).ToString("00");
      return string.Format("{0}:{1}", minutes, seconds);
  }
}
