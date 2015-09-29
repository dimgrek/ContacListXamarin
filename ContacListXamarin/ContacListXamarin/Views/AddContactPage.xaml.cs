using System;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class AddContactPage : ContentPage
    {
        private readonly ContacListViewModel _contactsViewModel;

        public AddContactPage(ContacListViewModel contactsViewModel)
        {
            InitializeComponent();
            _contactsViewModel = contactsViewModel;
            var vm = new ContactViewModel();
            vm.ItemAdded += _contactsViewModel.OnNewItemAdded;
            vm.ItemSaved += OnBtnClicked;
            vm.ItemCanceled += OnBtnClicked;
            BindingContext = vm;
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
