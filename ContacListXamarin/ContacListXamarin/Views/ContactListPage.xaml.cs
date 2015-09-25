using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class ContactListPage : ContentPage
    {
        public ContactListPage()
        {
            InitializeComponent();
            addContactBtn.Clicked += OnAddThingsButtonClicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var items = _thingsService.GetThings();
            ThingsILoveList.ItemsSource = items;
        }


        async void OnAddThingsButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactPage());
        }
    
    }
}
