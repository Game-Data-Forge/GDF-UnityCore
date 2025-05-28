#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IGDFStorageData.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IGDFStorageData : IGDFDbStorage, IGDFWritableSyncableData
    {
        #region Instance fields and properties

        [GDFDbLength(256)] public string ClassName { get; set; }

        public string Json { get; set; }
        public int Storage { get; set; }

        #endregion
    }
}