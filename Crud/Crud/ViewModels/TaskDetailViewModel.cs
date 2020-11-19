using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Crud.Models;
using Crud.Services;
using Xamarin.Forms;

namespace Crud.ViewModels
{
    public class TaskDetailViewModel : ViewModelBase
    {
        #region Properties
        private ITaskService _taskService { get; set; }
        private INavigationService _navigationService { get; set; }

        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set =>SetValue(ref _selectedTask, value);
        }

        private string _taskTitle;
        public string TaskTitle
        {
            get => _taskTitle;
            set => SetValue(ref _taskTitle, value);
        }

        private string _taskDescription;
        public string TaskDescription
        {
            get => _taskDescription;
            set => SetValue(ref _taskDescription, value);
        }

        private bool _taskCompleted;
        public bool TaskCompleted
        {
            get => _taskCompleted;
            set => SetValue(ref _taskCompleted, value);
        }

        private bool _isEdit;
        public bool IsEdit
        {
            get => _isEdit;
            set => SetValue(ref _isEdit, value);
        }
        #endregion

        #region Commands

        public ICommand SaveTaskCommand { get; private set; }
        public ICommand GoBackCommand { get; private set; }

        #endregion

        public TaskDetailViewModel(ITaskService taskService, INavigationService navigationService, int taskId)
        {
            Title = taskId == 0 ? "Nueva Tarea" : "Detalle de Tarea";
            IsEdit = taskId == 0 ? false : true;
            _taskService = taskService;
            _navigationService = navigationService;
            SetCommands();
            SetTaskDetail(taskId);
        }

        #region Methods

        private void SetCommands()
        {
            SaveTaskCommand = new Command(async() => await SaveTask());
        }

        private void SetTaskDetail(int taskId)
        {
            if (taskId == 0)
                return;

            SelectedTask = _taskService.GetTask(taskId);
            TaskTitle = SelectedTask.Title;
            TaskDescription = SelectedTask.Description;
            TaskCompleted = SelectedTask.IsCompleted;
        }

        private async Task SaveTask()
        {
            SelectedTask = new TaskModel
            {
                TaskID = IsEdit ? SelectedTask.TaskID : 0,
                Title = TaskTitle,
                Description = TaskDescription,
                IsCompleted = TaskCompleted                
            };

            try
            {
                string message = string.Empty;
                if (IsEdit)
                {
                    message = "Tarea actualizada exitosamente.";
                    _taskService.UpdateTask(SelectedTask);
                }
                else
                {
                    message = "Tarea creada exitosamente.";
                    _taskService.AddTask(SelectedTask);
                }

                await _navigationService.DisplayAlertAsync("Mis Tareas", message, "Aceptar");
                await _navigationService.PopAsync();
            }
            catch (Exception ex)
            {
                await _navigationService.DisplayAlertAsync("Error", ex.Message, "Aceptar");
            }
        }

        #endregion
    }
}
