using Android.Service.QuickSettings;
using Android_Capabilities.Location.LocationListComponents;
using Android_Capabilities.Services;
using AndroidX.RecyclerView.Widget;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace Android_Capabilities.Location;

[Activity(Label = "LocationListActivity", Theme = "@style/AppTheme.NoActionBar")]
public class LocationListActivity : Activity
{
    RecyclerView _recyclerView;
    FileService fileService;

    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetContentView(Resource.Layout.retrieved_locations_page);

        _recyclerView = FindViewById<RecyclerView>(Resource.Id.locations_recycler_view);

        var mLayoutManager = new LinearLayoutManager(this);
        _recyclerView.SetLayoutManager(mLayoutManager);

        fileService ??= new FileService();
        _recyclerView.SetAdapter(new LocationsAdapter(await fileService.ReadLocationsFromFile()));
    }
}
