using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ContacListXamarin.Contacts;
using ContacListXamarin.Model;
using Xamarin.Forms;

namespace ContacListXamarin.ViewModels
{
    public class ContacListViewModel
    {
        public ContacListViewModel(IContactService service)
        {
            Contacts = new ObservableCollection<ContactItem>(service.GetThings());
            AddCommand = new Command(Add);
            DeleteCommand = new Command<SelectedItemChangedEventArgs>(Delete);
            OnSelectionCommand = new Command<SelectedItemChangedEventArgs>(OnSelection);
        }

        public ObservableCollection<ContactItem> Contacts { get; set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand OnSelectionCommand { get; private set; }
        public event EventHandler AddItemClicked;
        public event EventHandler<ItemSelectedEventArgs> ItemSelected;
        public event EventHandler<ItemSelectedEventArgs> ItemDeleted;

        public void Update()
        {
            Contacts = Contacts;
        }

        private void Add()
        {
            AddItemClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Delete(SelectedItemChangedEventArgs e)
        {
            var contactItem = e.SelectedItem as ContactItem;
            if (contactItem == null)
                return;

            Contacts.Remove(Contacts.Single(o => o.ID == contactItem.ID));
            ItemDeleted?.Invoke(this, new ItemSelectedEventArgs { Id = contactItem.ID });
        }

        private void OnSelection(SelectedItemChangedEventArgs e)
        {
            var contactItem = e.SelectedItem as ContactItem;
            if (contactItem == null)
                return;

            ItemSelected?.Invoke(this, new ItemSelectedEventArgs { Id = contactItem.ID });
        }

        public void OnNewItemAdded(object sender, ContactItemEventArgs e)
        {
            Contacts.Add(e.ContactItem);
        }
    }

    public class ItemSelectedEventArgs
    {
        public int Id { get; set; }
    }
}
