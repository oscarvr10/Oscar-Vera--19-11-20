using System.Threading.Tasks;
using Xamarin.Forms;

namespace Crud.Services
{
    public class NavigationService : INavigationService
    {
        private Page MainPage { get => Application.Current.MainPage; }

        public NavigationService()
        {
        }
        
        public async Task PopAsync()
        {
            await MainPage.Navigation.PopAsync();
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task DisplayAlertAsync(string title, string message, string ok)
        {
            await MainPage.DisplayAlert(title, message, ok);
        }

        public async Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }
    }
}
