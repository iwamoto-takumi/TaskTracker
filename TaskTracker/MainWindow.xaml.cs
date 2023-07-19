using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace TaskTracker
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        public MainWindow()
        {
            InitializeComponent();

            Tasks = new ObservableCollection<Task>();
            var collectionViewSource = (CollectionViewSource)Resources["SortedTasks"];
            collectionViewSource.Source = Tasks;
            TasksListView.ItemsSource = collectionViewSource.View;

            LoadTasks();
        }

        private void LoadTasks()
        {
            using SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;");
            connection.Open();

            string sql = "SELECT * FROM Tasks WHERE IsComplete = FALSE";

            using SQLiteCommand command = new SQLiteCommand(sql, connection);
            using SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var task = new Task
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Description = reader["Description"].ToString(),
                    IsComplete = Convert.ToBoolean(reader["IsComplete"]),
                    CreatedAt = reader["CreatedAt"] as DateTime?,
                    DeletedAt = reader["DeletedAt"] as DateTime?
                };

                Tasks.Add(task);
            }
        }

        private void TaskHeader_Click(object sender, MouseButtonEventArgs e)
        {
            SortTasks("Description");
        }

        private void CreatedAtHeader_Click(object sender, MouseButtonEventArgs e)
        {
            SortTasks("CreatedAt");
        }

        private void SortTasks(string sortBy)
        {
            var collectionView = (CollectionView)CollectionViewSource.GetDefaultView(TasksListView.ItemsSource);
            collectionView.SortDescriptions.Clear();

            if (_lastSortBy == sortBy)
            {
                _lastSortDirection = _lastSortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else
            {
                _lastSortDirection = ListSortDirection.Ascending;
            }

            collectionView.SortDescriptions.Add(new SortDescription(sortBy, _lastSortDirection));
            _lastSortBy = sortBy;
        }

        private string _lastSortBy = "CreatedAt";
        private ListSortDirection _lastSortDirection = ListSortDirection.Descending;

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskTextBox.Text))
            {
                var newTask = new Task { Description = NewTaskTextBox.Text, IsComplete = false };

                SaveTask(newTask);

                NewTaskTextBox.Clear();

                Tasks.Clear();
                LoadTasks();
            }
        }

        private void SaveTask(Task newTask)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;"))
            {
                connection.Open();

                string sql = "INSERT INTO Tasks (Description, IsComplete, CreatedAt) VALUES (@Description, @IsComplete, @CreatedAt)";

                using SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Description", newTask.Description);
                command.Parameters.AddWithValue("@IsComplete", newTask.IsComplete);
                command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox checkBox)
            {
                if (checkBox.DataContext is Task task)
                {
                    task.IsComplete = true;
                    task.DeletedAt = DateTime.Now;
                    UpdateTask(task);
                    Tasks.Remove(task);
                }
            }

        }

        private void ShowCompletedButton_Click(object sender, RoutedEventArgs e)
        {
            CompletedTasksWindow completedTasksWindow = new CompletedTasksWindow();
            completedTasksWindow.TaskRestored += () =>
            {
                Tasks.Clear();
                LoadTasks();
            };

            completedTasksWindow.ShowDialog();
        }

        private void UpdateTask(Task task)
        {
            using SQLiteConnection connection = new SQLiteConnection("Data Source=TasksDB.sqlite;Version=3;");
            connection.Open();

            string sql = "UPDATE Tasks SET IsComplete = @isComplete, DeletedAt = @deletedAt WHERE Id = @id";

            using SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@isComplete", task.IsComplete);
            command.Parameters.AddWithValue("@deletedAt", task.IsComplete ? DateTime.Now : (object)DBNull.Value);
            command.Parameters.AddWithValue("@id", task.Id);

            command.ExecuteNonQuery();
        }
    }
}
