#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IApiResult.cs create at 2025/05/06 17:05:33
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public interface IApiResult
    {
        public string Status { get; set; }
        public bool Success { get; set; }
    }
}