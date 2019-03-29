//
//  FixBackground.cs
//
//  Author:
//       Andre Luis da Cunha <andreluiscunha81@gmail.com>
//
//  Copyright (c) 2018 Andre Luis da Cunha, 2MuchPines Studio.
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

namespace _2MuchPines.InvertedMask
{
	public class FixMaskBackground:MonoBehaviour
	{
		[SerializeField]Transform _mask;
                
        void Update()
		{
			bool sameX = (int)_mask.localPosition.RoundToInt().x == (int)-gameObject.transform.localPosition.RoundToInt().x;
			bool sameY = (int)_mask.localPosition.RoundToInt().y == (int)-gameObject.transform.localPosition.RoundToInt().y;
			if (! (sameX && sameY))
			    FixPosition();

		}
		void FixPosition()
        {
			float newPosX = _mask.localPosition.x;
			float newPosY = _mask.localPosition.y;
            gameObject.transform.localPosition = new Vector3(-newPosX, -newPosY, gameObject.transform.localPosition.z);		
        }
	}
}
