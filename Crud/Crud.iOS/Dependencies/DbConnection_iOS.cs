using System;
using System.IO;
using Crud.iOS.Dependencies;
using Crud.Services.Dependencies;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbConnection_iOS))]
namespace Crud.iOS.Dependencies
{
    public class DbConnection_iOS : IDbConnection
    {
        public DbConnection_iOS()
        {
        }

        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dbPath = Path.Combine(documentsPath, "MyDB.db3");

            return new SQLiteConnection(dbPath);
        }
    }
}
