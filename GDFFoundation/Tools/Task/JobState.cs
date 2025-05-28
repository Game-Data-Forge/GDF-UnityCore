#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj JobState.cs create at 2025/05/15 11:05:03
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public enum JobState
    {
        Pending = 0,
        Running = 1,
        Success = 2,
        Failure = 3,
        Cancelled = 4,
    }
}