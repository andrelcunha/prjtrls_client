using UnityEngine;
using DG.Tweening;

namespace Trilhas.Controller
{
	public class CameraFocusController : MonoBehaviour
	{
		[SerializeField] Transform _target;
		[SerializeField] float _duration;
		[SerializeField] float _minZ;
		[SerializeField] float _maxZ;

		public Transform Target
		{
			get
			{
				return _target;
			}

			set
			{
				_target = value;
			}
		}

		public float Duration
		{
			get
			{
				return _duration;
			}

			set
			{
				_duration = value;
			}
		}

		public void DoFocus()
		{
			DoFocus(true);
		}

		public void DoFocus(bool zoomIn)
		{
			float posZ = zoomIn ? _maxZ : _minZ;
			Vector3 pos = new Vector3(Target.position.x, Target.position.y, posZ);
			gameObject.transform.DOMove(pos, Duration).SetEase(Ease.Linear);
		}

		public void SetPosition(float offset)
		{
			float newPosX = gameObject.transform.position.x + offset;
			gameObject.transform.position = new Vector3(newPosX, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}