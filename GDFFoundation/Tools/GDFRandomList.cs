#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GDFRandomList.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion


#region

using System;
using System.Collections.Generic;

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Represents a static class for shuffling the elements of a given list.
    /// </summary>
    public static class GDFRandomList
    {
        #region Static fields and properties

        /// <summary>
        ///     A wrapper class for the <see cref="System.Random" /> class.
        /// </summary>
        static readonly Random KRandom = new Random();

        #endregion

        #region Static methods

        /// <summary>
        ///     Shuffles the elements of the given list in random order.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="sList">The list to be shuffled.</param>
        public static void Shuffle<T>(this IList<T> sList)
        {
            int tN = sList.Count;
            while (tN > 1)
            {
                tN--;
                int tK = KRandom.Next(tN + 1);
                T tValue = sList[tK];
                sList[tK] = sList[tN];
                sList[tN] = tValue;
            }
        }

        #endregion
    }
}