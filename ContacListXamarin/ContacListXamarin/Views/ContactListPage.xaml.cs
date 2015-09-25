using System;
using System.Windows.Input;
using ContacListXamarin.Contacts;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class ContactListPage : ContentPage
    {
        readonly IContactService _contactService = new ContactService();

        public ContactListPage()
        {
            InitializeComponent();
            AddCommand = new Command(Add);
            BindingContext = this;
        }

        public ICommand AddCommand { get; private set; }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            var contacts = _contactService.GetThings();
            ContactList.ItemsSource = contacts;
            ContactList.ItemSelected += OnSelection;
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

        async void Add()
        {
            await Navigation.PushAsync(new AddContactPage());
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}
