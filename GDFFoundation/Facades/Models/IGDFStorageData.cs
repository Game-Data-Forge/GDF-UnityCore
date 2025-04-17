namespace GDFFoundation
{
    public interface IGDFStorageData : IGDFDbStorage, IGDFWritableSyncableData
    {
        [GDFDbLength(256)]
        public string ClassName { get; set; }
        public string Json { get; set; }
        public int Storage { get; set; }
    }
}


