using System;
using System.Collections;
using System.Collections.Generic;

namespace GDFRuntime
{
    public class GameSaves : IEnumerable<byte>
    {
        static private readonly byte[] _flags = new byte[8] {
            0b00000001, 0b00000010, 0b00000100, 0b00001000, 0b00010000, 0b00100000, 0b01000000, 0b10000000
        };
        static public byte[] buffer = new byte[32];

        static public void EmptyBuffer()
        {
            Array.Fill(buffer, (byte)0);
        }

        public int Count => _data.Count;

        private HashSet<byte> _data = new HashSet<byte> ();

        public void Add(byte gameSave)
        {
            _data.Add(gameSave);
        }

        public void Remove(byte gameSave)
        {
            _data.Remove(gameSave);
        }

        public void WriteBuffer()
        {
            EmptyBuffer();

            foreach (byte gameSave in _data)
            {
                int index1 = 31 - gameSave / 8;
                int index2 = gameSave % 8;
                buffer[index1] |= _flags[index2];
            }
        }

        public void ReadBuffer()
        {
            for (int i = 0; i < 32; i ++)
            {
                if (buffer[i] == 0)
                {
                    continue;
                }

                for (int j = 0; j < 8; j++)
                {
                    if ((buffer[i] & _flags[j]) != _flags[j])
                    {
                        continue;
                    }
                    _data.Add((byte)((31-i) * 8 + j));
                }
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}