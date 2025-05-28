#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj PoolItem.cs create at 2025/03/25 11:03:36
// ©2024-2025 idéMobi SARL FRANCE

#endregion

namespace GDFFoundation
{
    public abstract class PoolItem : IPoolItem
    {
        #region Static methods

        static public void Release(IPoolItem poolItem)
        {
            poolItem.Pool?.Release(poolItem);
        }

        #endregion

        #region Instance fields and properties

        #region From interface IPoolItem

        public Pool Pool { get; set; }

        #endregion

        #endregion

        #region Instance methods

        #region From interface IPoolItem

        public void Dispose()
        {
            Release(this);
        }

        public abstract void OnPooled();
        public abstract void OnReleased();

        #endregion

        #endregion
    }
}