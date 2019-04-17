using UnityEngine;
using System.Collections.Generic;

namespace _2MuchPines.Tools
{
	public static class ExtensionMethods
    {
        /// <summary>
        /// Draws the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="array">Array.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T _DrawElement<T>(this T[] array)
        {
            int i = Random.Range(0, array.Length);
            return array[i];
        }

        /// <summary>
        /// Draws the element.
        /// </summary>
        /// <returns>The element.</returns>
        /// <param name="list">List.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T _DrawElement<T>(this List<T> list)
        {
            int i = Random.Range(0, list.Count);
            return list[i];
        }

        /// <summary>
        /// Draws the element and deletes it from genericList.
        /// </summary>
        /// <returns>The element with deletion.</returns>
        /// <param name="list">List.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T _DrawElementWithDeletion<T>(this List<T> list)
        {
            int i = Random.Range(0, list.Count);
            var tmp = list[i];
            list.RemoveAt(i);
            return tmp;
        }

        /// <summary>
        /// Normalizes the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="name">Name.</param>
        /// <param name="replace_space_with_underscore">If set to <c>true</c> replace space with underscore.</param>
        public static string NormalizeString(this string name, bool replace_space_with_underscore = false)
        {
            name = name.ToLower();
            if (replace_space_with_underscore)
                name = name.Replace(" ", "_");
            else
                name = name.Replace(" ", "");
            name = name.Replace("á", "a");
            name = name.Replace("à", "a");
            name = name.Replace("ã", "a");
            name = name.Replace("â", "a");
            name = name.Replace("Á", "A");
            name = name.Replace("À", "A");
            name = name.Replace("Ã", "A");
            name = name.Replace("Â", "A");

            name = name.Replace("é", "e");
            name = name.Replace("è", "e");
            name = name.Replace("ê", "e");

            name = name.Replace("í", "i");
            name = name.Replace("Í", "I");

            name = name.Replace("ó", "o");
            name = name.Replace("õ", "o");

            name = name.Replace("ç", "c");
            name = name.Replace("Ç", "c");

            return name.Normalize();
        }


        /// <summary>
        /// Pop the specified element in the index of  genericList.
        /// </summary>
        /// <returns>Selected element.</returns>
        /// <param name="genericList">Generic list.</param>
        /// <param name="index">Index.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Pop<T>(this List<T> genericList, int index = 0)
        {
            var temp = genericList[index];
            genericList.RemoveAt(index);
            return temp;
        }
    }
}
