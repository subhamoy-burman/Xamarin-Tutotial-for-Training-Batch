﻿using System;
using BookSwap.Local.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSwap.Local
{
    public partial class App : Application
    {
        public static BooksViewModel MainViewModel = new BooksViewModel();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
