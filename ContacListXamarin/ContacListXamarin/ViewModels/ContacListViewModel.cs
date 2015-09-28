using System.Collections.ObjectModel;
using System.Windows.Input;
using ContacListXamarin.Contacts;
using ContacListXamarin.Model;
using ContacListXamarin.Views;
using Xamarin.Forms;

namespace ContacListXamarin.ViewModels
{
    public class ContacListViewModel
    {
        private readonly INavigation _navigation;
        private readonly IContactService _service;


        public ContacListViewModel(IContactService service, INavigation navigation)
        {
            _service = service;
            _navigation = navigation;
            Contacts = new ObservableCollection<ContactItem>(_service.GetThings());
            AddCommand = new Command(Add);
        }

        public ObservableCollection<ContactItem> Contacts { get; set; }

        public ICommand AddCommand { get; private set; }

        async void Add()
        {
            await _navigation.PushAsync(new AddContactPage());
        }
    }
}
