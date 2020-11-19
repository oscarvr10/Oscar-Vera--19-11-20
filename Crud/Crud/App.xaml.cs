using Crud.Views;
using Xamarin.Forms;

namespace Crud
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var homePage = new HomePage();
            MainPage = new NavigationPage(homePage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
