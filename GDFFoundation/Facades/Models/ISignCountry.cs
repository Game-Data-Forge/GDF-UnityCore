#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ISignCountry.cs create at 2025/03/26 17:03:59
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface ISignCountry
    {
        #region Instance fields and properties

        public Country Country { set; get; }

        #endregion
    }

    public interface IProjectPublicKey
    {
        #region Instance fields and properties

        public string ProjectPublicKey { set; get; }

        #endregion
    }

    public interface IProjectSecretHash
    {
        #region Instance fields and properties

        public string ProjectSecretHash { set; get; }

        #endregion
    }
}