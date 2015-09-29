using System;
using ContacListXamarin.ViewModels;
using Xamarin.Forms;

namespace ContacListXamarin.Views
{
    public partial class AddContactPage : ContentPage
    {
        private readonly ContacListViewModel _contactsListViewModel;

        public AddContactPage(ContacListViewModel contactsListViewModel)
        {
            InitializeComponent();
            _contactsListViewModel = contactsListViewModel;
            var vm = new ContactViewModel();
            vm.ItemAdded += _contactsListViewModel.OnNewItemAdded;
            vm.ItemSaved += OnBtnClicked;
            vm.ItemCanceled += OnBtnClicked;
            vm.WhatItemDeleted += _contactsListViewModel.Delete;
            vm.ItemDeleted += OnBtnClicked;
            BindingContext = vm;
        }

        async void OnBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
