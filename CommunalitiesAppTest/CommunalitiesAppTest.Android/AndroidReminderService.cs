using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using HomeFacility;
using Xamarin.Forms;

[assembly: Dependency(typeof(HomeFacility.Droid.AndroidReminderService))]
namespace HomeFacility.Droid
{
     public class AndroidReminderService : IReminderService
    {
        public string Remind(DateTime dateTime, string title, string message)
        {

            Intent alarmIntent = new Intent(Android.App.Application.Context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("message", message);
            alarmIntent.PutExtra("title", title);

            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Android.App.Application.Context.GetSystemService(Context.AlarmService);
            //Android.App.Application.Context
            //TODO: For demo set after 5 seconds.
            //var timefornotification = (long)(dateTime - new DateTime(1970, 1, 1, Int16.Parse(dateTime.Hour.ToString()), Int16.Parse(dateTime.Minute.ToString()), Int16.Parse(dateTime.Second.ToString()))).TotalMilliseconds;
            DateTimeOffset dateOffsetValue = DateTimeOffset.Parse(dateTime.ToString());
            var timefornotification = dateOffsetValue.ToUnixTimeMilliseconds();
            alarmManager.Set(AlarmType.RtcWakeup, timefornotification, pendingIntent);
            return "fuck";
        }
    }
}