using FriendsAndroid.Models;
using FriendsAndroid.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsAndroid
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "friends.db";
        public static FriendRepository database;
        public static FriendRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new FriendRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DBListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
