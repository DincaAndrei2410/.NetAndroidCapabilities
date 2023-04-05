using System;
using Android.Views;
using Android_Capabilities.Models;
using AndroidX.RecyclerView.Widget;

namespace Android_Capabilities.Location.LocationListComponents
{
	public class LocationsAdapter : RecyclerView.Adapter
	{
        List<LocationModel> _locationModels;

        public LocationsAdapter(List<LocationModel> locationModels)
        {
            _locationModels = locationModels;
        }

        public override int ItemCount => _locationModels.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            LocationViewHolder vh = holder as LocationViewHolder;

            var location = _locationModels[position];

            vh.TimeTextView.Text = $"{location.DateTime.ToLocalTime().ToShortDateString()} -> {location.DateTime.ToLocalTime().ToLongTimeString()}";
            vh.ProcessInfoTextView.Text = $"Process: {location.ProcessId} - User: {location.UserId}";
            vh.LocationInfoTextView.Text = $"Latitude: {location.Latitude}; Longitude: {location.Longitude}; Altitude: {location.Altitude}";
            vh.ProviderInfoTextView.Text = $"Provider: {location.Provider.ToUpper()}";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.location_cell, parent, false);

            LocationViewHolder lvh = new LocationViewHolder(itemView);
            return lvh;
        }
    }
}

