using Android.Content;
using Android.Content.PM;
using Android_Capabilities.Contacts;
using Android_Capabilities.Location;
using AndroidX.AppCompat.App;

[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessBackgroundLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.ForegroundService)]
[assembly: UsesPermission(Android.Manifest.Permission.ReadContacts)]

namespace Android_Capabilities;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, LaunchMode = LaunchMode.SingleTask)]
public class MainActivity : AppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        Button locationButton = FindViewById<Button>(Resource.Id.location_button);
        locationButton.Click += LocationButtonOnClick;

        Button contactsButton = FindViewById<Button>(Resource.Id.contacts_button);
        contactsButton.Click += ContactsButtonOnClick;

    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
    }

    private void LocationButtonOnClick(object? sender, EventArgs e)
    {
        StartActivity(new Android.Content.Intent(this, typeof(LocationActivity)));
    }

    private void ContactsButtonOnClick(object? sender, EventArgs e)
    {
        StartActivity(new Android.Content.Intent(this, typeof(ContactsActivity)));
    }
}
