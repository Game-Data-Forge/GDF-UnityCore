using System.Collections;
using System.Collections.Generic;

namespace GDFRuntime
{
    public class PlayerReferenceStorage : IEnumerable<byte>
    {
        public string Reference { get; set; }
        public string Classname { get; set; }
        public int Count => GameSaves.Count;

        private HashSet<byte> GameSaves = new HashSet<byte> ();

        public void Add(byte gameSave)
        {
            GameSaves.Add(gameSave);
        }

        public void Remove(byte gameSave)
        {
            GameSaves.Remove(gameSave);
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return GameSaves.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}