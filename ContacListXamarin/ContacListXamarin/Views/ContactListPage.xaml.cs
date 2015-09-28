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

        public ContactListPage()
        {
            InitializeComponent();
            var vm = new ContacListViewModel(DependencyService.Get<IContactService>(), Navigation);
            BindingContext = vm;
            ContactList.ItemSelected += OnSelection;
        }

        
        public void OnDelete(object sender, EventArgs e)
        {
            //TODO: cast sender to MenuItem, show nice UIAlert
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }


        async void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var contactItem = e.SelectedItem as ContactItem;
            if (contactItem == null)
                return;
            ((ListView)sender).SelectedItem = null;
            await Navigation.PushAsync(new ContactViewPage(contactItem.ID));

        }
    }
}
