using Crud.Repository;
using Crud.Services;
using Crud.Services.Dependencies;
using Crud.ViewModels;
using Xamarin.Forms;

namespace Crud.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            SetBindingContext();
        }

        private void SetBindingContext()
        {
            var taskRepository = new TaskRepository(DependencyService.Get<IDbConnection>());
            var taskService = new TaskService(taskRepository);
            var navigationService = new NavigationService();
            BindingContext = new HomeViewModel(taskService, navigationService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as HomeViewModel;
            viewModel.GetAllTasks();
        }
    }
}
