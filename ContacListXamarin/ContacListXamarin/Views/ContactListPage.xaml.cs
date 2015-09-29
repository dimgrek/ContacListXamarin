using System;
using ContacListXamarin.Contacts;
using ContacListXamarin.Model;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class ContactListPage : ContentPage
    {
        private ContacListViewModel _vm;

        public ContactListPage()
        {
            _vm = new ContacListViewModel(DependencyService.Get<IContactService>());
            BindingContext = _vm;
            _vm.AddItemClicked += OnAddBtnClicked;
            _vm.ItemSelected += OnItemSelected;
            InitializeComponent();
        }

        async void OnItemSelected(object sender, ItemSelectedEventArgs e)
        {
            await Navigation.PushAsync(new ContactViewPage(e.Id));
        }

        async void OnAddBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactPage(_vm.Contacts));
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (_vm.OnSelectionCommand.CanExecute(e))
                _vm.OnSelectionCommand.Execute(e);
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as ContactItem;
            var args = new SelectedItemChangedEventArgs(item);

            if (_vm.DeleteCommand.CanExecute(args))
                _vm.DeleteCommand.Execute(args);
        }
    }
}
