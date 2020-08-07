using System;
using System.IO;
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
using Android.Graphics;
using Xamarin.Forms;

namespace HomeFacility.Droid
{
    [BroadcastReceiver(Enabled =true)]
    public class AlarmReceiver : BroadcastReceiver
    {
        public const string CHANNEL = "homefacility_notify";
        public override void OnReceive(Context context, Intent intent)
        {

            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var notIntent = new Intent(context, typeof(MainActivity));
            var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            //var manager = NotificationManagerCompat.From(context);

            
            var chan = new NotificationChannel(CHANNEL, "Notification", NotificationImportance.High)
            {
                LockscreenVisibility = NotificationVisibility.Public
            };

            int resourceId;
            resourceId = Resource.Drawable.icon;

            //Generate a notification with just short text and small icon
            var builder = new NotificationCompat.Builder(context)
                            .SetContentIntent(contentIntent)
                            .SetSmallIcon(Resource.Drawable.home_ico)
                            .SetContentTitle(title)
                            .SetContentText(message)
                            .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                            .SetChannelId(CHANNEL)
                            .SetAutoCancel(true);
            //.SetVisibility(NotificationVisibility.Public);


            NotificationManager manager = (NotificationManager)Android.App.Application.Context.GetSystemService(Context.NotificationService);
            manager.CreateNotificationChannel(chan);

            var notification = builder.Build();
            manager.Notify(0, notification);
            
        }
    }
}