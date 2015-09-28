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
            _vm = new ContacListViewModel(DependencyService.Get<IContactService>(), Navigation);
            BindingContext = _vm;
            InitializeComponent();
            ContactList.ItemSelected += OnSelection;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var contact = _contactService.GetThings();
            ContactList.ItemsSource = contact;
        }

        public void OnDelete(object sender, EventArgs e)
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
            //((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new ContactViewPage(contactItem.ID, Navigation));
        }
    }
}
