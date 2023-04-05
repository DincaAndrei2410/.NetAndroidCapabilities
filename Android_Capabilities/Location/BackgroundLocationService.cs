using System;
using Android.Content;
using Android.OS;
using Android.Runtime;

namespace Android_Capabilities.Location
{
    [Service(Exported =false, Process = ":android_capabilities_external")]
	public class BackgroundLocationService : Service
    {
        LocationService _locationService;

        public BackgroundLocationService()
		{
            _locationService ??= new LocationService();
        }

        public override IBinder? OnBind(Intent? intent)
        {
            throw new NotImplementedException();
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent? intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _locationService.GetLocation();
            return StartCommandResult.Sticky;
        }
    }
}

