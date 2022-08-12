namespace CH_Final.Data
{
    public abstract class DbContext
    {
        protected readonly string ConnectionString;

        protected DbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
