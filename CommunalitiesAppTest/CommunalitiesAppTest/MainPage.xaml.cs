using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace HomeFacility
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            string disp_phone = "0000000000";
            string filepath_phone = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "phone_disp.txt");
            if (File.Exists(filepath_phone))
            {
                disp_phone = File.ReadAllText(filepath_phone);
            }
            PhoneDialer.Open(disp_phone);
        }

        private async void btnToLK_Click(object sender, EventArgs e) //MPTEK
        {
            var uri = new Uri("https://lk.eis24.me/cabinet");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
                    
        private async void btnEmail_Click(object sender, EventArgs e) //RKSENergo
        {
            var uri = new Uri("https://lk.rks-energo.ru");
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        private async void settings_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageSettings());
        }

        private async void about_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAbout());
        }

        
}
}
