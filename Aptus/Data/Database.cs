using System.IO;
using SQLite;

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

        public void SaveBioAsync(string bio)
        {
            using (var connection = new SQLiteConnection(DatabasePath, Flags))
            {
                connection.CreateTable<BioModel>();
                connection.Insert(new BioModel { Bio = bio });
            }
        }
    }

    public class BioModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Bio { get; set; }
    }

    public class ExerciseDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ExerciseDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Exercise>().Wait();
        }

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _database.Table<Exercise>().ToListAsync();
        }

        public Task<Exercise> GetExerciseAsync(int id)
        {
            return _database.Table<Exercise>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.Id != 0)
            {
                return _database.UpdateAsync(exercise);
            }
            else
            {
                return _database.InsertAsync(exercise);
            }
        }

        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            return _database.DeleteAsync(exercise);
        }
    }

}

