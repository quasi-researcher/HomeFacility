using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HomeFacility
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSettings : ContentPage
    {
        public PageSettings()
        {
            InitializeComponent();
            string filepath_phone = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "phone_disp.txt");
            if (File.Exists(filepath_phone))
            {
                phone_disp.Text = File.ReadAllText(filepath_phone);
            }
            else
            {
                File.WriteAllText(filepath_phone, "+79111111111");
                phone_disp.Text = File.ReadAllText(filepath_phone);
            }
            string filepath_eislog = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eis_login.txt");
            if (File.Exists(filepath_eislog))
            {
                eis_login.Text = File.ReadAllText(filepath_eislog);
            }
            else
            {
                File.WriteAllText(filepath_eislog, "user@email.ru");
                eis_login.Text = File.ReadAllText(filepath_eislog);
            }
            string filepath_eispwd = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eis_pwd.txt");
            if (File.Exists(filepath_eispwd))
            {
                eis_pwd.Text = File.ReadAllText(filepath_eispwd);
            }
            else
            {
                File.WriteAllText(filepath_eispwd, "querty");
                eis_pwd.Text = File.ReadAllText(filepath_eispwd);
            }
            string filepath_rkslog = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "rks_login.txt");
            if (File.Exists(filepath_rkslog))
            {
                rks_login.Text = File.ReadAllText(filepath_rkslog);
            }
            else
            {
                File.WriteAllText(filepath_rkslog, "user@email.ru");
                rks_login.Text = File.ReadAllText(filepath_rkslog);
            }
            string filepath_rkspwd = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "rks_pwd.txt");
            if (File.Exists(filepath_rkspwd))
            {
                rks_pwd.Text = File.ReadAllText(filepath_rkspwd);
            }
            else
            {
                File.WriteAllText(filepath_rkspwd, "querty");
                rks_pwd.Text = File.ReadAllText(filepath_rkspwd);
            }

        }

        
        private void notify_Clicked(object sender, EventArgs e)
        {
            var reminderON = DependencyService.Get<IReminderService>();
            char sep = ' ';
            String[] strtodate = notify_at.Text.Split(sep);
            int[] inttodate=new int[6];
            int i = 0;
            foreach (string s in strtodate)
            {
                inttodate[i] = int.Parse(s);
                i++;
            }
            DateTime notify_at_date = new DateTime(inttodate[0], inttodate[1], inttodate[2], inttodate[3], inttodate[4], inttodate[5]);
            string f=reminderON.Remind(notify_at_date, "ТСЖ Дом на Коротком", "Не забудьте подать показания счетчиков");
            DisplayAlert("ТСЖ Дом на Коротком", notify_at_date.ToString(), "OK");
        }

        private void new_phone_Clicked(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "phone_disp.txt");
            File.WriteAllText(filepath, phone_disp.Text);
            DisplayAlert("ТСЖ Дом на Коротком", "Настройки сохранены", "OK");
            phone_disp.Text = File.ReadAllText(filepath);
        }

        private void eis_cred_Clicked(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eis_login.txt");
            File.WriteAllText(filepath, eis_login.Text);
            eis_login.Text = File.ReadAllText(filepath);
            filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eis_pwd.txt");
            File.WriteAllText(filepath, eis_pwd.Text);
            eis_pwd.Text = File.ReadAllText(filepath);
            eis_pwd.IsPassword = true;
            DisplayAlert("ТСЖ Дом на Коротком", "Настройки сохранены", "OK");
            
        }

        private void ShowPwdEis(object sender, EventArgs args)
        {
            eis_pwd.IsPassword = eis_pwd.IsPassword ? false : true;
        }
        private void rks_cred_Clicked(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "rks_login.txt");
            File.WriteAllText(filepath, rks_login.Text);
            rks_login.Text = File.ReadAllText(filepath);
            filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "rks_pwd.txt");
            File.WriteAllText(filepath, rks_pwd.Text);
            rks_pwd.Text = File.ReadAllText(filepath);
            rks_pwd.IsPassword = true;
            DisplayAlert("ТСЖ Дом на Коротком", "Настройки сохранены", "OK");

        }

        private void ShowPwdRks(object sender, EventArgs args)
        {
            rks_pwd.IsPassword = rks_pwd.IsPassword ? false : true;
        }

        
    }
}