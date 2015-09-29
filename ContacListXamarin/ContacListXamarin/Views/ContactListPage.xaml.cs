using System;
using ContacListXamarin.Contacts;
using ContacListXamarin.Model;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class ContactListPage : ContentPage
    {
        readonly IContactService _contactService = new ContactService();
        private ContacListViewModel _vm;

        public ContactListPage()
        {
            _vm = new ContacListViewModel(DependencyService.Get<IContactService>());
            BindingContext = _vm;
            _vm.AddItemClicked += GoToAddContactPage;
            InitializeComponent();
            ContactList.ItemSelected += OnSelection;
        }

        async void GoToAddContactPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactPage());
        }

        protected override void OnAppearing()
        {
            _vm.Update();
            var contact = _contactService.GetThings();
            ContactList.ItemsSource = contact;
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var contactToDelete = (ContactItem)((MenuItem)sender).CommandParameter;
            _contactService.Delete(contactToDelete);
            var contact = _contactService.GetThings();
            ContactList.ItemsSource = contact;
        }


        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var contactItem = e.SelectedItem as ContactItem;
            if (contactItem == null)
                return;
            await Navigation.PushAsync(new ContactViewPage(contactItem.ID));
        }
    }
}
