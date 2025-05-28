#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IDeviceSign.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IDeviceSign
    {
        #region Instance fields and properties

        public string UniqueIdentifier { set; get; }

        #endregion
    }
}