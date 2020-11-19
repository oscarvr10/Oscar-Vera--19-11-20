using System;
using System.IO;
using Crud.Droid.Dependencies;
using Crud.Services.Dependencies;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbConnection_Android))]
namespace Crud.Droid.Dependencies
{
    public class DbConnection_Android : IDbConnection
    {
        public DbConnection_Android()
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
