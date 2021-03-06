﻿using ContacListXamarin.Contacts;
using ContacListXamarin.Views;
using Xamarin.Forms;

namespace ContacListXamarin
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            DependencyService.Register<ContactService>();
            MainPage = new NavigationPage(new ContactListPage());
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
