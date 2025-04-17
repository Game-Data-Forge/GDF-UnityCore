namespace GDFFoundation
{
    /// <summary>
    /// Holds a counted group of data.
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

