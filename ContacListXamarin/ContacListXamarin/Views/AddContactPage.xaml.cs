using System;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage()
        {
            InitializeComponent();
            var vm = new ContactViewModel();
            vm.ItemAdded += GoToPreviousPage;
            vm.ItemCanceled += GoToPreviousPage;
            BindingContext = vm;
        }

        async void GoToPreviousPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
