using Android;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android_Capabilities.Services;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using System.Linq;

namespace Android_Capabilities.Location;

[Activity(Label = "LocationActivity", Theme = "@style/AppTheme.NoActionBar")]
public class LocationActivity : AppCompatActivity
{
    const int REQUEST_LOCATION_INT = 1232;

    LocationService _locationService;

    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetContentView(Resource.Layout.location);

        Button startLocationButton = FindViewById<Button>(Resource.Id.start_location_button);
        startLocationButton.Click += StartLocationButtonOnClick;

        Button startBackgroundLocationButton = FindViewById<Button>(Resource.Id.start_background_service);
        startBackgroundLocationButton.Click += StartBackgroundLocationService;

        Button seeLocationsButton = FindViewById<Button>(Resource.Id.see_locations_button);
        seeLocationsButton.Click += NavigateToLocationListButton;

        Button startForegroundLocationButton = FindViewById<Button>(Resource.Id.start_foreground_service);
        startForegroundLocationButton.Click += StartForegroundLocationService;

        var locationPermission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation);

        if (locationPermission != Permission.Granted){
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, REQUEST_LOCATION_INT);
        }
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        if (requestCode == REQUEST_LOCATION_INT)
        {
            if ((grantResults.Length == 2) && (grantResults[0] == Permission.Granted))
            {
                if(grantResults[1] != Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation, Manifest.Permission.AccessBackgroundLocation }, REQUEST_LOCATION_INT);
                    return;
                }

                Toast.MakeText(this, "Location Permission granted", ToastLength.Short)?.Show();
            }
            else
            {
                Toast.MakeText(this, "Location Permission denied", ToastLength.Short)?.Show();
            }
        }
        else
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    private void StartLocationButtonOnClick(object? sender, EventArgs e)
    {
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == (int)Permission.Granted ||
            ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessCoarseLocation) == (int)Permission.Granted)
        {
            _locationService ??= new LocationService();
            _locationService.GetLocation();
        }
    }

    private void StartBackgroundLocationService(object? sender, EventArgs e)
    {
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessBackgroundLocation) != Permission.Granted)
        {
            StartActivity(new Intent(
                            Android.Provider.Settings.ActionApplicationDetailsSettings,
                            Android.Net.Uri.Parse("package:" + Android.App.Application.Context.PackageName)));
        }
        else
        {
            var intent = new Intent(this, typeof(BackgroundLocationService));
            StartService(intent);
        }
    }

    private void NavigateToLocationListButton(object? sender, EventArgs e)
    {
        StartActivity(new Intent(this, typeof(LocationListActivity)));
    }

    private void StartForegroundLocationService(object? sender, EventArgs e)
    {
        StartForegroundService(new Intent(this, typeof(ForegroundLocationService)));
    }
}
