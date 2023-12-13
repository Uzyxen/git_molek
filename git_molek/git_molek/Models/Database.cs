﻿using SQLite;
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

        public Task<DayMood> GetLastDayMood()
        {
            return _database.Table<DayMood>().Where(d => d.Date != DateTime.Now.Date).OrderByDescending(d => d.Date).FirstOrDefaultAsync();
        }

        public Task<DayMood> GetDayMood(DateTime dateTime)
        {
            return _database.Table<DayMood>().Where(d => d.Date == dateTime).FirstOrDefaultAsync();
        }

        public Task<List<DayMood>> GetDayMoods()
        {
            return _database.Table<DayMood>().OrderByDescending(d => d.Date).ToListAsync();
        }
    }
}
