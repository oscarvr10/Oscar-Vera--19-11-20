using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Crud.Models;
using Crud.Services;
using Crud.Views;
using Xamarin.Forms;

namespace Crud.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Properties
        private ITaskService _taskService { get; set; }
        private INavigationService _navigationService { get; set; }

        public ObservableCollection<TaskModel> TaskList { get; set; } = new ObservableCollection<TaskModel>();

        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                SetValue(ref _selectedTask, value);
                GoToTaskDetailCommand?.Execute(_selectedTask);
            }
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get => _isEmpty;
            set => SetValue(ref _isEmpty, value);
        }
        #endregion

        #region Commands

        public ICommand AddTaskCommand { get; private set; }
        public ICommand GoToTaskDetailCommand { get; private set; }
        public ICommand DeleteTaskCommand { get; private set; }
        public ICommand CompleteTaskCommand { get; private set; }

        #endregion

        public HomeViewModel(ITaskService taskService, INavigationService navigationService)
        {
            _taskService = taskService;
            _navigationService = navigationService;
            Title = "Mis Tareas";
            SetCommands();
        }

        #region Methods

        private void SetCommands()
        {
            AddTaskCommand = new Command(() => AddTask());
            GoToTaskDetailCommand = new Command<TaskModel>((obj) => GoToTaskDetail(obj));
            DeleteTaskCommand = new Command<TaskModel>(async(task) => await DeleteTask(task));
            CompleteTaskCommand = new Command<TaskModel>(async (task) => await CompleteTask(task));
        }
        private async Task DeleteTask(TaskModel task)
        {
            IsBusy = true;
            var taskIsDeleted = _taskService.DeleteTask(task);
            if (taskIsDeleted)
            {
                await _navigationService.DisplayAlertAsync("Mis Tareas", "La tarea fue eliminada exitosamente", "Aceptar");
                GetAllTasks();
            }
            IsBusy = false;
        }

        private void GoToTaskDetail(TaskModel obj)
        {
            if (obj == null)
                return;

            var page = new TaskDetailPage(obj.TaskID);
            _navigationService.PushAsync(page);
        }

        private void AddTask()
        {
            var page = new TaskDetailPage(0);
            _navigationService.PushAsync(page);
        }

        private async Task CompleteTask(TaskModel task)
        {
            task.IsCompleted =true;
            var isCompleted = _taskService.UpdateTask(task);
            if (isCompleted)
                await _navigationService.DisplayAlertAsync("Mis Tareas", "Tarea completada", "Aceptar");
        }

        public async void GetAllTasks()
        {
            IsBusy = true;
            if(TaskList?.Count > 0)
                TaskList.Clear();
            
            var tasks = _taskService.GetAllTask();
            foreach (var task in tasks)
            {
                TaskList.Add(task);
            }

            IsEmpty = TaskList.Count == 0;
            IsBusy = false;
        }

        #endregion
    }
}
