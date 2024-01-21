using FriendsAndroid.VeiwModels;
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
    public partial class FriendListPage : ContentPage
    {
        public FriendListPage()
        {
            InitializeComponent();
            BindingContext = new FriendsListViewModel() { Navigation = this.Navigation };
        }
    }
}