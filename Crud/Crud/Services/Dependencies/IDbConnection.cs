using SQLite;

namespace Crud.Services.Dependencies
{
    public interface IDbConnection
    {
        SQLiteConnection GetConnection();
    }
}
