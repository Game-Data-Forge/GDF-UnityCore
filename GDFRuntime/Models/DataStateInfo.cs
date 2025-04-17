using System;

namespace GDFRuntime
{
    public struct DataStateInfo
    {
        public DataState state;
        public DateTime? saveModificationDate;
        public DateTime? syncModificationDate;
    }
}