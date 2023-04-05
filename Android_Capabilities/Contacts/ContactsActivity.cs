using Android;
using Android.Content.PM;
using Android.Runtime;
using Android_Capabilities.Contacts.ContactsListComponents;
using Android_Capabilities.Location.LocationListComponents;
using Android_Capabilities.Services;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using AndroidX.RecyclerView.Widget;
using static Android.Provider.ContactsContract;

namespace Android_Capabilities.Contacts;

[Activity(Label = "ContactsActivity", Theme = "@style/AppTheme.NoActionBar")]
public class ContactsActivity : AppCompatActivity
{
    const int REQUEST_CONTACTS_INT = 1232;

    ContactsService _contactsService;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Create your application here

        SetContentView(Resource.Layout.contacts);

        var contactsRecycler = FindViewById<RecyclerView>(Resource.Id.contacts_recycler_view);

        var mLayoutManager = new LinearLayoutManager(this);
        contactsRecycler.SetLayoutManager(mLayoutManager);

        var locationPermission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadContacts);

        if (locationPermission != Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadContacts }, REQUEST_CONTACTS_INT);
        }

        _contactsService ??= new ContactsService();
        _contactsService.GetContacts(this);

        contactsRecycler.SetAdapter(new ContactsAdapter(_contactsService.GetContacts(this)));
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        if (requestCode == REQUEST_CONTACTS_INT)
        {
            if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
            {
                Toast.MakeText(this, " Contacts Permission granted", ToastLength.Short)?.Show();
            }
            else
            {
                Toast.MakeText(this, "Contacts Permission denied", ToastLength.Short)?.Show();
            }
        }
        else
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
