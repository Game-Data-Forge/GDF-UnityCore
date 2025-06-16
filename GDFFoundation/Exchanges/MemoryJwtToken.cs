#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj MemoryJwtToken.cs create at 2025/05/12 10:05:34
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class MemoryJwtToken
    {
        #region Instance fields and properties

        public long Account { get; set; }
        public short Channel { get; set; }
        public Country Country { get; set; }
        public ProjectEnvironment Environment { get; set; }
        public long Project { get; set; }
        public int Range { get; set; }
        public string Token { get; set; }
        public DateTime LastSync { get; set; }

        #endregion

        #region Instance constructors and destructors

        public MemoryJwtToken()
        {
            Project = 0;
            Channel = 0;
            Account = 0;
            Range = 0;
            Token = string.Empty;
            LastSync = GDFDatetime.Now;
        }

        #endregion

        #region Instance methods

        public bool IsValid()
        {
            return Project != 0 && Channel > 0 && Account != 0 && Range != 0 && !string.IsNullOrEmpty(Token);
        }

        #endregion
    }
}