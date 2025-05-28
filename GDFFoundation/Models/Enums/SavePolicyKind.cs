#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj SavePolicyKind.cs create at 2025/03/27 21:03:09
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public enum SavePolicyKind
    {
        LocalOnly,
        LocalOrCloud,
        CloudOnly,
    }
}