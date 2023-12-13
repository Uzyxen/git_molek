using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace git_molek.Models
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<DayMood>();
        }

        public Task<int> InsertDayMoodAsync(DayMood dayMood)
        {
            return _database.InsertAsync(dayMood);
        }
    }
}
