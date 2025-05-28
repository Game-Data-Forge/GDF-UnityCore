#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj IPoolItem.cs create at 2025/02/10 17:02:17
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;

#endregion

namespace GDFFoundation
{
    public interface IPoolItem : IDisposable
    {
        #region Instance fields and properties

        public Pool Pool { get; set; }

        #endregion

        #region Instance methods

        public void OnPooled();
        public void OnReleased();

        #endregion
    }
}