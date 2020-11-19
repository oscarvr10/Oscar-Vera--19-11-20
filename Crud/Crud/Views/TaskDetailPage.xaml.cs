using Crud.Models;
using Crud.Repository;
using Crud.Services;
using Crud.Services.Dependencies;
using Crud.ViewModels;
using Xamarin.Forms;

namespace Crud.Views
{
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage(int taskId)
        {
            InitializeComponent();
            SetBindingContext(taskId);
        }   

        private void SetBindingContext(int taskId)
        {
            var taskRepository = new TaskRepository(DependencyService.Get<IDbConnection>());
            var taskService = new TaskService(taskRepository);
            var navigationService = new NavigationService();
            BindingContext = new TaskDetailViewModel(taskService, navigationService, taskId);
        }
    }
}
