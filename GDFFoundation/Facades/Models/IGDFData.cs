#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFData.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    public interface IGDFData
    {
        #region Instance fields and properties

        [GDFDbAccess(updateAccess = GDFDbColumnAccess.Deny)]
        public DateTime Creation { get; }

        public long DataVersion { get; }
        public DateTime Modification { get; }
        public bool Trashed { get; set; }

        #endregion

        #region Instance methods

        public object GetReference();

        #endregion
    }
}