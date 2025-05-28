#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj StringBase64Extension.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace GDFFoundation
{
    static public class StringBase64Extension
    {
        #region Static fields and properties

        static readonly private char[] _DEF_CHARS = new char[]
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '+',
            '/'
        };

        static readonly private char[] _URL_CHARS = new char[]
        {
            'A',
            'B',
            'C',
            'D',
            'E',
            'F',
            'G',
            'H',
            'I',
            'J',
            'K',
            'L',
            'M',
            'N',
            'O',
            'P',
            'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z',
            'a',
            'b',
            'c',
            'd',
            'e',
            'f',
            'g',
            'h',
            'i',
            'j',
            'k',
            'l',
            'm',
            'n',
            'o',
            'p',
            'q',
            'r',
            's',
            't',
            'u',
            'v',
            'w',
            'x',
            'y',
            'z',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '-',
            '_'
        };

        #endregion

        #region Static methods

        static private int FindIndex(char[] chars, char value)
        {
            int index = Array.IndexOf(chars, value);
            if (index < 0)
            {
                throw new Exception("The Base 64 string contains invalid characters !");
            }

            return index;
        }

        static public string FromBase64(this string self)
        {
            if (self.Length % 4 != 0)
            {
                throw new Exception("The length of the Base 64 string is invalid !");
            }

            List<byte> bytes = new List<byte>();

            int i = 0;
            while (i < self.Length)
            {
                byte count = 0;
                int index = FindIndex(_DEF_CHARS, self[i]);
                int current = index << 18;
                i++;

                index = FindIndex(_DEF_CHARS, self[i]);
                current |= index << 12;
                i++;

                if (self[i] != '=')
                {
                    index = FindIndex(_DEF_CHARS, self[i]);
                    current |= index << 6;
                    count++;
                }

                i++;

                if (self[i] != '=')
                {
                    index = FindIndex(_DEF_CHARS, self[i]);
                    current |= index;
                    count++;
                }

                i++;

                bytes.Add((byte)(current >> 16));

                switch (count)
                {
                    case 2:
                        bytes.Add((byte)(current >> 8));
                        bytes.Add((byte)current);
                    break;
                    case 1:
                        bytes.Add((byte)(current >> 8));
                    break;
                }
            }

            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        static public string FromBase64URL(this string self)
        {
            List<byte> bytes = new List<byte>();

            int i = 0;
            while (i < self.Length)
            {
                byte count = 0;
                int index = FindIndex(_URL_CHARS, self[i]);
                int current = index << 18;
                i++;

                index = FindIndex(_URL_CHARS, self[i]);
                current |= index << 12;
                i++;

                if (i < self.Length)
                {
                    index = FindIndex(_URL_CHARS, self[i]);
                    current |= index << 6;
                    count++;
                }

                i++;

                if (i < self.Length)
                {
                    index = FindIndex(_URL_CHARS, self[i]);
                    current |= index;
                    count++;
                }

                i++;

                bytes.Add((byte)(current >> 16));

                switch (count)
                {
                    case 2:
                        bytes.Add((byte)(current >> 8));
                        bytes.Add((byte)current);
                    break;
                    case 1:
                        bytes.Add((byte)(current >> 8));
                    break;
                }
            }

            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        static public string ToBase64(this string self)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;

            byte[] bytes = Encoding.UTF8.GetBytes(self);

            while (i < bytes.Length)
            {
                byte count = 0;
                int current = bytes[i] << 16;
                i++;

                if (i < bytes.Length)
                {
                    count++;
                    current |= bytes[i] << 8;
                }

                i++;

                if (i < bytes.Length)
                {
                    count++;
                    current |= bytes[i];
                }

                i++;

                builder.Append(_DEF_CHARS[current >> 18]);
                builder.Append(_DEF_CHARS[(current >> 12) & 0b111111]);

                switch (count)
                {
                    case 2:
                        builder.Append(_DEF_CHARS[(current >> 6) & 0b111111]);
                        builder.Append(_DEF_CHARS[current & 0b111111]);
                    break;
                    case 1:
                        builder.Append(_DEF_CHARS[(current >> 6) & 0b111111]);
                        builder.Append('=');
                    break;
                    default:
                        builder.Append('=');
                        builder.Append('=');
                    break;
                }
            }

            return builder.ToString();
        }

        static public string ToBase64URL(this string self)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;

            byte[] bytes = Encoding.UTF8.GetBytes(self);

            while (i < bytes.Length)
            {
                byte count = 0;
                int current = bytes[i] << 16;
                i++;

                if (i < bytes.Length)
                {
                    count++;
                    current |= bytes[i] << 8;
                }

                i++;

                if (i < bytes.Length)
                {
                    count++;
                    current |= bytes[i];
                }

                i++;

                builder.Append(_URL_CHARS[current >> 18]);
                builder.Append(_URL_CHARS[(current >> 12) & 0b111111]);

                switch (count)
                {
                    case 2:
                        builder.Append(_URL_CHARS[(current >> 6) & 0b111111]);
                        builder.Append(_URL_CHARS[current & 0b111111]);
                    break;
                    case 1:
                        builder.Append(_URL_CHARS[(current >> 6) & 0b111111]);
                    break;
                }
            }

            return builder.ToString();
        }

        #endregion
    }
}