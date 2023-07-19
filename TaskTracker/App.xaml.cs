using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskTracker
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string dbPath = System.IO.Path.Combine(Environment.CurrentDirectory, "TasksDB.sqlite");

            if (!System.IO.File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);

                using SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;");
                connection.Open();

                string sql = "CREATE TABLE Tasks (Id INTEGER PRIMARY KEY AUTOINCREMENT, Description TEXT NOT NULL, IsComplete BOOLEAN NOT NULL, CreatedAt DATETIME, DeletedAt DATETIME)";

                using SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}
