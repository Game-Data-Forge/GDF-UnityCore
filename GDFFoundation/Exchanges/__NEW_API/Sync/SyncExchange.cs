using System;
using GDFStandardModels;

namespace GDFFoundation
{
    [Serializable]
    public class SyncStudioDataExchangeUp : GDFNewSyncInformation
    {
    }

    [Serializable]
    public class SyncStudioDataExchangeDown : GDFNewSyncInformation
    {
        public GDFStudioDataStorage[] StudioDataStorageArray { set; get; }
    }

    [Serializable]
    public class SyncPlayerDataExchangeUp : GDFNewSyncInformation
    {
        public GDFPlayerDataStorage[] PlayerDataStorageArray { set; get; }
    }

    [Serializable]
    public class SyncPlayerDataExchangeDown : GDFNewSyncInformation
    {
        public GDFPlayerDataStorage[] PlayerDataStorageArray { set; get; }
    }

    [Serializable]
    public class SyncVolatileDataExchangeUp
    {
        public GDFVolatileAction[] VolatileActionArray { set; get; }
        public GDFVolatileAmount[] VolatileAmountArray { set; get; }
        public GDFVolatileBoolean[] VolatileBooleanArray { set; get; }
        public GDFVolatileDuration[] VolatileDurationArray { set; get; }
        public GDFVolatileEnum[] VolatileEnumArray { set; get; }
        public GDFVolatileException[] VolatileExceptionArray { set; get; }
        public GDFVolatileQuantity[] VolatileQuantityArray { set; get; }
    }

    [Serializable]
    public class SyncExchangeUp
    {
        public SyncPlayerDataExchangeUp PlayerDataExchange { set; get; }
        public SyncStudioDataExchangeUp StudioDataExchange { set; get; }
        public SyncVolatileDataExchangeUp VolatileDataExchange { set; get; }
    }

    [Serializable]
    public class SyncExchangeDown
    {
        public SyncPlayerDataExchangeDown PlayerDataExchange { set; get; }
        public SyncStudioDataExchangeDown StudioDataExchange { set; get; }
    }
}