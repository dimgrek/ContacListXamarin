using ContacListXamarin.Contacts;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class ContactViewPage : ContentPage
    {
        public ContactViewPage(int id)
        {
            InitializeComponent();
            var vm = new ContactViewModel(id, DependencyService.Get<IContactService>());
            BindingContext = vm;
        }
    }
}
