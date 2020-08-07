using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeFacility
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#26495c"),
                BarTextColor = Color.White
            };
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
