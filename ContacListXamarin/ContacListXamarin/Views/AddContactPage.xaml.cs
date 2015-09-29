using System;
using System.Collections.ObjectModel;
using ContacListXamarin.Model;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class AddContactPage : ContentPage
    {
        private readonly ObservableCollection<ContactItem> _contacts;

        public AddContactPage(ObservableCollection<ContactItem> contacts)
        {
            _contacts = contacts;
            InitializeComponent();
            var vm = new ContactViewModel(contacts);
            vm.ItemAdded += OnBtnClicked;
            vm.ItemCanceled += OnBtnClicked;
            BindingContext = vm;
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
