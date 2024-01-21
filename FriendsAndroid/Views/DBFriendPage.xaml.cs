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
    public partial class DBFriendPage : ContentPage
    {
        public DBFriendPage()
        {
            InitializeComponent();
        }



        private async void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;

            if (string.IsNullOrEmpty(friend.Name) || string.IsNullOrEmpty(friend.Email) || string.IsNullOrEmpty(friend.Phone))
            {
                await DisplayAlert("Validation Error", "Name, Email, and Phone are required.", "OK");
                return;
            }
            // Display a confirmation dialog
            bool answer = await DisplayAlert("Confirmation", $"Save the following data?\n\nName: {friend.Name}\nEmail: {friend.Email}\nPhone: {friend.Phone}", "Yes", "No");

            // Check user's answer
            if (answer)
            {
                App.Database.SaveItem(friend);

                // Display a success message with a green checkmark
                await DisplayAlert("Success", "Data saved successfully \u2714", "OK");

                await this.Navigation.PopAsync();
            }
        }





        private async void DeleteFriend(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirm Deletion", "Are you sure you want to delete this friend?", "Yes", "No");
            if (answer)
            {
                var friend = (Friend)BindingContext;
                App.Database.Delete(friend.Id);
                this.Navigation.PopAsync();
            }
        }


        private async void Cancel(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            if (friend != null && (IsFriendModified(friend) || !AreAllFieldsEmpty(friend)))
            {
                bool answer = await DisplayAlert("", "Are you sure you want to cancel?", "Yes", "No");
                if (!answer)
                    return;
            }

            this.Navigation.PopAsync();
        }

        private bool IsFriendModified(Friend friend)
        {
            return !string.IsNullOrEmpty(friend.Name) || !string.IsNullOrEmpty(friend.Email) || !string.IsNullOrEmpty(friend.Phone);
        }

        private bool AreAllFieldsEmpty(Friend friend)
        {
            return string.IsNullOrEmpty(friend.Name) && string.IsNullOrEmpty(friend.Email) && string.IsNullOrEmpty(friend.Phone);
        }


    }
}