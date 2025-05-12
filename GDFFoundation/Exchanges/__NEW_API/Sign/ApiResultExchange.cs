#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ApiResultExchange.cs create at 2025/05/06 17:05:33
// ©2024-2025 idéMobi SARL FRANCE

#endregion

using System;

namespace GDFFoundation
{
    [Serializable]
    public class ApiResultExchange : IApiResult
    {
        public string Status { get; set; } = "ok";
        public bool Success { get; set; } = true;
    }
}