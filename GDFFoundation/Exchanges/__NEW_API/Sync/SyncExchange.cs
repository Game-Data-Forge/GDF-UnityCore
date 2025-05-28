#region Copyright

// Game-Data-Forge Solution
// Written by CONTART Jean-François & BOULOGNE Quentin
// GDFFoundation.csproj SyncExchange.cs create at 2025/03/26 17:03:12
// ©2024-2025 idéMobi SARL FRANCE

#endregion

#region

using System;
using GDFStandardModels;

#endregion

namespace GDFFoundation
{
    [Serializable]
    public class SyncStudioDataExchangeUp : GDFNewSyncInformation
    {
    }

    [Serializable]
    public class SyncStudioDataExchangeDown : GDFNewSyncInformation
    {
        #region Instance fields and properties

        public GDFStudioDataStorage[] StudioDataStorageArray { set; get; }

        #endregion
    }

    [Serializable]
    public class SyncPlayerDataExchangeUp : GDFNewSyncInformation
    {
        #region Instance fields and properties

        public GDFPlayerDataStorage[] PlayerDataStorageArray { set; get; }

        #endregion
    }

    [Serializable]
    public class SyncPlayerDataExchangeDown : GDFNewSyncInformation
    {
        #region Instance fields and properties

        public GDFPlayerDataStorage[] PlayerDataStorageArray { set; get; }

        #endregion
    }

    [Serializable]
    public class SyncVolatileDataExchangeUp
    {
        #region Instance fields and properties

        public GDFVolatileAction[] VolatileActionArray { set; get; }
        public GDFVolatileAmount[] VolatileAmountArray { set; get; }
        public GDFVolatileBoolean[] VolatileBooleanArray { set; get; }
        public GDFVolatileDuration[] VolatileDurationArray { set; get; }
        public GDFVolatileEnum[] VolatileEnumArray { set; get; }
        public GDFVolatileException[] VolatileExceptionArray { set; get; }
        public GDFVolatileQuantity[] VolatileQuantityArray { set; get; }

        #endregion
    }

    [Serializable]
    public class SyncExchangeUp
    {
        #region Instance fields and properties

        public SyncPlayerDataExchangeUp PlayerDataExchange { set; get; }
        public SyncStudioDataExchangeUp StudioDataExchange { set; get; }
        public SyncVolatileDataExchangeUp VolatileDataExchange { set; get; }

        #endregion
    }

    [Serializable]
    public class SyncExchangeDown
    {
        #region Instance fields and properties

        public SyncPlayerDataExchangeDown PlayerDataExchange { set; get; }
        public SyncStudioDataExchangeDown StudioDataExchange { set; get; }

        #endregion
    }
}