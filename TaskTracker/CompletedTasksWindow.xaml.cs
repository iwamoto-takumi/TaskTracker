using System;
using System.Data.SQLite;
using System.Windows;

namespace TaskTracker
{
    public partial class CompletedTasksWindow : Window
    {
        public event Action TaskRestored;

        public CompletedTasksWindow()
        {
            InitializeComponent();
            LoadCompletedTasks();
        }

        private void LoadCompletedTasks()
        {
            using SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;");
            connection.Open();

            string sql = "SELECT Id, Description, IsComplete, DeletedAt FROM Tasks WHERE DeletedAt IS NOT NULL ORDER BY DeletedAt DESC";

            using SQLiteCommand command = new SQLiteCommand(sql, connection);
            using SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var task = new Task
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Description = reader["Description"].ToString(),
                    IsComplete = Convert.ToBoolean(reader["IsComplete"]),
                    DeletedAt = reader["DeletedAt"] as DateTime?
                };
                CompletedTasksListView.Items.Add(task);
            }
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            Task? selectedTask = CompletedTasksListView.SelectedItem as Task;

            if (selectedTask != null)
            {
                selectedTask.IsComplete = false;
                selectedTask.DeletedAt = null;
                UpdateTask(selectedTask);

                CompletedTasksListView.Items.Remove(selectedTask);

                TaskRestored?.Invoke();
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            Task? selectedTask = CompletedTasksListView.SelectedItem as Task;

            if (selectedTask != null)
            {
                DeleteTask(selectedTask);

                CompletedTasksListView.Items.Remove(selectedTask);
            }
        }

        private void UpdateTask(Task task)
        {
            using SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;");
            connection.Open();

            string sql = "UPDATE Tasks SET Description = @Description, IsComplete = @IsComplete, DeletedAt = @DeletedAt WHERE Id = @Id";
            using SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@IsComplete", task.IsComplete);
            command.Parameters.AddWithValue("@DeletedAt", task.DeletedAt.HasValue ? $"'{task.DeletedAt.Value:yyyy-MM-dd HH:mm:ss}'" : null);
            command.Parameters.AddWithValue("@id", task.Id);
            command.ExecuteNonQuery();
        }

        private void DeleteTask(Task task)
        {
            using SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;");
            connection.Open();

            string sql = "DELETE FROM Tasks WHERE Id = @Id";
            using SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", task.Id);
            command.ExecuteNonQuery();
        }
    }
}
