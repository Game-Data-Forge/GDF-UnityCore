#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ApiResultExchange.cs create at 2025/05/06 17:05:33
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class ApiResultExchange : IApiResult
    {
        #region Instance fields and properties

        #region From interface IApiResult

        public string Status { get; set; } = "ok";
        public bool Success { get; set; } = true;

        #endregion

        #endregion
    }
}