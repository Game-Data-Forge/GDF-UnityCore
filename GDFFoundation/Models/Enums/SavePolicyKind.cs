using System;

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