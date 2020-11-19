using System.Threading.Tasks;
using Xamarin.Forms;

namespace Crud.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task PopAsync();
        Task<bool> DisplayAlertAsync(string title, string message, string ok, string cancel);
        Task DisplayAlertAsync(string title, string message, string ok);
    }
}
