using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _2MuchPines.PlugglableTweens;

namespace Trilhas.Controller
{
    public class DialogController : MonoBehaviour
    {

        [SerializeField] Dialog dialogo;
        [SerializeField] TextMeshProUGUI _text;
        [SerializeField] TweenEffect effect;
        [SerializeField] GameObject button;
        [SerializeField] Image mentorImage;
        [SerializeField] AllMentors allMentorsData;


        private Button _dialogButton;

        private int _index = -1;

        private void Start() {
            SetMentorImage(0);
        }

        public Dialog Dialogo
        {
            get
            {
                return dialogo;
            }

            set
            {
                dialogo = value;
            }
        }

        public TweenEffect Effect
        {
            get
            {
                return effect;
            }
        }

        public Button DialogButton
        {
            get
            {
                if (_dialogButton == null)
                {
                    _dialogButton = button.GetComponent<Button>();
                }
                return _dialogButton;
            }

            set
            {
                _dialogButton = value;
            }
        }

        public void LoadNext()
        {
            if (_index < dialogo.dialogArray.Length - 1)
            {
                _index++;
                LoadDialogContent();
                SetMentorImage(_index);
            }
            else
            {
                _text.SetText("");
                button.SetActive(false);
                Effect.RewindTween(0);
            }

        }

        void LoadDialogContent()
        {
            var content = dialogo.dialogArray[_index];
            _text.SetText(content);
        }

        public void ResetIndex()
        {
            _index = -1;
            button.SetActive(true);
            SetMentorImage(0);
        }

        void SetMentorImage(int index)
        {
            if (index < dialogo.mentorMoods.Length)
            {
                MentorMood mentorMood = dialogo.mentorMoods[index];
                mentorImage.sprite = allMentorsData.
                    MentorByName(dialogo.mentor).
                    SpriteMoodByName(mentorMood);
            }
            else
            {
                throw new System.IndexOutOfRangeException("Index out of bounds:" + index.ToString());
            }


        }
    }
}
