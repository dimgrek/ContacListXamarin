using SQLite;

namespace ContacListXamarin.Services.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
