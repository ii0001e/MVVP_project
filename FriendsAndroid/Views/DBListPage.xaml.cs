using FriendsAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        //обработка нажатия элемента в списке
        //proccess pressing element in the list
        private async void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            DBFriendPage friendPage = new DBFriendPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }

        //обработка нажатия кнопки добавления
        //proccess pressing the button for adding 

        private async void CreateFriend(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            DBFriendPage friendPage = new DBFriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }
    }
}