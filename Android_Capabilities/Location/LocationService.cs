using System;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android_Capabilities.Mappers;
using Android_Capabilities.Models;
using Android_Capabilities.Services;
using AndroidX.Core.Location;
using Java.Interop;
using Java.Security;

namespace Android_Capabilities.Location
{
	public class LocationService
	{
		private readonly LocationManager? _locationManager;
		List<string> _availableProviders;

        GeolocationListener _listener;

        public LocationService()
		{
            _locationManager = (LocationManager?)Application.Context.GetSystemService(Context.LocationService);
			_availableProviders = _locationManager?.GetProviders(false).ToList() ?? new List<string>();
        }

		public void GetLocation()
		{
            var isLocationEnabled = LocationManagerCompat.IsLocationEnabled(_locationManager);

            if(_listener != null) {
                _locationManager.RemoveUpdates(_listener);
            }

            List<Android.Locations.Location?> locations = new List<Android.Locations.Location?>();

            _listener ??= new GeolocationListener();

            foreach (var provider in _availableProviders)
            {
                locations.Add(_locationManager?.GetLastKnownLocation(provider));

                var request = new LocationRequestCompat.Builder(100).SetMinUpdateIntervalMillis(1000).Build();
                LocationManagerCompat.RequestLocationUpdates(_locationManager!, provider, request, _listener, Looper.MyLooper() ?? Looper.MainLooper!);
            }
        }
    }

    public class GeolocationListener : Java.Lang.Object, ILocationListenerCompat
    {
        readonly FileService _fileService;

        public GeolocationListener()
        {
            _fileService = new FileService();
        }

        public async void OnLocationChanged(Android.Locations.Location location)
        {
            var sharedLocation = LocationMapper.Map(location, Process.MyPid(), Process.MyUid());
            System.Diagnostics.Debug.WriteLine(sharedLocation);

            try
            {
                await _fileService.WriteLocationToFile(sharedLocation);
            }
            catch {
                //log exception
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string? provider, [GeneratedEnum] Availability status, Bundle? extras)
        {
        }

    }
}

