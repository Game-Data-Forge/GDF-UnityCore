#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj ApiErrorMessage.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public struct ApiErrorMessage
    {
        public int StatusCode { get; set; }
        public string InnerCode { get; set; }
        public string Message { get; set; }
        public string Help { get; set; }
    }
}