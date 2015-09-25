using System;
using System.Windows.Input;
using ContacListXamarin.Contacts;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class AddContactPage : ContentPage
    {
        readonly IContactService _contactService = new ContactService();
        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; set; }

        public AddContactPage()
        {
            InitializeComponent();
            BindingContext = this;

            AddContactBtn.Clicked += OnAddContactBtnClicked;
            CancelContactBtn.Clicked += OnCancelContactBtnClicked;
        }

        async void OnCancelContactBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


        async void OnAddContactBtnClicked(object sender, EventArgs e)
        {
            _contactService.Add(Name.Text);
            await Navigation.PopAsync();
        }
    }
}
