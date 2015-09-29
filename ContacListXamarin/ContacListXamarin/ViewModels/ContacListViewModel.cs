using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ContacListXamarin.Contacts;
using ContacListXamarin.Model;
using Xamarin.Forms;

namespace ContacListXamarin.ViewModels
{
    public class ContacListViewModel
    {
        private readonly IContactService _service;

        public ContacListViewModel(IContactService service)
        {
            _service = service;
            Contacts = new ObservableCollection<ContactItem>(_service.GetThings());
            AddCommand = new Command(Add);
        }

        public ObservableCollection<ContactItem> Contacts { get; set; }

        public ICommand AddCommand { get; private set; }
        public event EventHandler AddItemClicked;

        public void Update()
        {
            Contacts = new ObservableCollection<ContactItem>(_service.GetThings());
        }

        private void Add()
        {
            AddItemClicked.Invoke(this, EventArgs.Empty);
        }
    }
}
