using System;
using System.IO;
using ContacListXamarin.Services.Database;
using SQLite;
using ThingsILove.iOS.Services.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteTouch))]
namespace ThingsILove.iOS.Services.Database
{
    public class SQLiteTouch : ISQLite
    {
        SQLiteConnection ISQLite.GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }

}
