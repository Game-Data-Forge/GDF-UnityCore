#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj GroupCounter.cs create at 2025/04/03 09:04:09
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    /// <summary>
    ///     Holds a counted group of data.
    /// </summary>
    /// <typeparam name="T">The type of data to be counted.</typeparam>
    public struct GroupCounter<T>
    {
        public T item;
        public int count;

        public GroupCounter(T item, int count)
        {
            this.item = item;
            this.count = count;
        }
    }
}