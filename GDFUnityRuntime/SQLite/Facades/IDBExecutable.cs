namespace GDFUnity
{
    public interface IDBExecutable
    {
        public void Exec(string sql);
        public T ExecScalar<T>(string sql);
    }
}
