using System.IO;
using SQLite;
using Aptus.Models;

namespace Aptus.Data
{
    public class Database
    {
        public const string DatabaseFilename = "Aptus.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public async Task SaveBioAsync(string bio)
        {
           var connection = new SQLiteConnection(DatabasePath, Flags);
            connection.CreateTable<BioModel>();
            connection.Insert(new BioModel { Bio = bio });
        }
    }


    public class BioModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Bio { get; set; }
    }

}

