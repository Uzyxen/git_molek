using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace git_molek.Models
{
    public class DayMood
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MoodEnum Mood { get; set; }
    }
}
