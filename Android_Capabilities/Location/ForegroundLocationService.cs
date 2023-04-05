using System;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.Core.App;

namespace Android_Capabilities.Location
{
	[Service(ForegroundServiceType = Android.Content.PM.ForegroundService.TypeLocation)]
	public class ForegroundLocationService : Service
	{
        private const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
        private const string foregroundChannelId = "9001";

        LocationService _locationService;

        public ForegroundLocationService()
		{
            _locationService = new LocationService();
        }

        public override IBinder? OnBind(Intent? intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            var context = Application.Context;

            var mainActivityIntent = new Intent(context, typeof(MainActivity));
            var pendingIntent = PendingIntent.GetActivity(context, 10012, mainActivityIntent, PendingIntentFlags.UpdateCurrent);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var notifManager = this.GetSystemService(Context.NotificationService) as NotificationManager;
                notifManager.CreateNotificationChannel(new NotificationChannel(foregroundChannelId, "Android Capabilities", NotificationImportance.High));
            }

            //TODO: Document that you always need to provide title, (text) and icon in order for this to work
            var notification = new NotificationCompat.Builder(context, foregroundChannelId)
                    .SetContentTitle("Android Capabilities")
                    .SetContentText("Running Foreground Service")
                    .SetSmallIcon(Resource.Drawable.add)
                    .SetOngoing(true)
                    .SetContentIntent(pendingIntent)
                    .Build();

            StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);

            _locationService.GetLocation();

            return StartCommandResult.Sticky;
        }

    }
}

