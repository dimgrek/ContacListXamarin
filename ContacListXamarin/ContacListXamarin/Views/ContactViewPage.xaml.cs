using System;
using ContacListXamarin.Contacts;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class ContactViewPage : ContentPage
    {
        private readonly ContacListViewModel _contacListViewModel;
        private readonly IContactService _contactService = new ContactService();

        public ContactViewPage(Guid id, ContacListViewModel contacListViewModel)
        {
            _contacListViewModel = contacListViewModel;
            InitializeComponent();
            var vm = new ContactViewModel(id, DependencyService.Get<IContactService>());
            vm.ItemDeleted += OnBtnClicked;
            vm.WhatItemDeleted += _contacListViewModel.Delete;
            BindingContext = vm;
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
