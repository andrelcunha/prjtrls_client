//
//  MonoBehaviourSingleton.cs
//
//  Author:
//       Andre Luis da Cunha <andreluiscunha81@gmail.com>
//
//  Copyright (c) 2017 Andre Luis da Cunha, 2MuchPines Studio.
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using UnityEngine;

namespace _2MuchPines.Templates
{
	public class MonoBehaviourSingleton<T> : MonoBehaviour
		where T : Component
	{
		private static T _instance;
		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					var objs = FindObjectsOfType(typeof(T)) as T[];
					if (objs.Length > 0)
						_instance = objs[0];
					if (objs.Length > 1)
					{
						Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
					}
					if (_instance == null)
					{
						GameObject obj = new GameObject
						{
							hideFlags = HideFlags.HideAndDontSave,
							name = typeof(T).Name + ":Singleton"
						};
						_instance = obj.AddComponent<T>();
					}
				}
				return _instance;
			}
		}
	}


	public class MonoBehaviourSingletonPersistent<T> : MonoBehaviour
		where T : Component
	{
		public static T Instance { get; private set; }

		public virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = this as T;
				DontDestroyOnLoad(this);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}