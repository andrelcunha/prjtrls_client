using UnityEngine;

using _2MuchPines.Templates;
using UnityEngine.Events;
using DG.Tweening;
using _2MuchPines.PlugglableTweens;

namespace Trilhas.Controller
{
	public class TweenController:MonoBehaviourSingleton<TweenController>
    {
		
		[Header("Tweener callbacks")]
		[Tooltip("Function called on normal play")]
		[SerializeField] 
		TweenEffect[] onPlay;

        public TweenEffect[] OnPlay
        {
            get
            {
                return onPlay;
            }
        }

        [Tooltip("Play on Awake")]
        [SerializeField]
        bool _playOnAwake;
		[SerializeField]
		float delay;
		[SerializeField]
		float Duration=1;

        [Tooltip("Reverse Callback Array on Rewind")]
        [SerializeField] 
        bool _reverseOnRewind;

		private Sequence LocalSequence;

        void Awake()
		{

			ConfigSequence(out LocalSequence);
			//ConfigRewindSequence(out RewindSequence);
		}

		private void Start() {
			if (_playOnAwake)
			{
				ExecuteSequence();
			}
		}

        void ConfigSequence(out Sequence sequence)
		{
			sequence = DOTween.Sequence();
			foreach (var step in onPlay)
			{
				step.SetDelay(delay);
				sequence.AppendInterval(delay);
				sequence.AppendCallback(delegate
				{
					step.StartTween();
				});
				
			}
			sequence.TogglePause();

		}
		void ConfigRewindSequence(out Sequence sequence)
		{
			sequence = DOTween.Sequence();
			sequence.AppendInterval(0);
			if(_reverseOnRewind)
			{
                foreach (var step in onPlay)
                {
					step.SetDelay(delay);
                    if (step.EaseFunction == Ease.OutElastic)
                        step.EaseFunction = Ease.InBack;
					step.moveDuration = Duration;
					step.rotateDuration = Duration;
					step.scaleDuration = Duration;
					step.fadeDuration = Duration; 
					sequence.PrependInterval(delay);
                    sequence.PrependCallback(delegate
					{
						step.RewindTween();
					});
				}
			}
			else
			{
				for( int i = 0; i < onPlay.Length; i++)
				{
					onPlay[i].SetDelay(delay);
					
					sequence.AppendInterval(delay);
					sequence.AppendCallback(delegate
					{
						onPlay[i].RewindTween();
					});
				}
			}
			sequence.TogglePause();

		}

        public void ExecuteSequence()
		{
			LocalSequence.TogglePause();
		}

		 public void ExecuteRewind()
		{
			ConfigRewindSequence(out LocalSequence);
			LocalSequence.TogglePause();
		}
    }
}
