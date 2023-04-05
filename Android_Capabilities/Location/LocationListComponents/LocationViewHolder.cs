using System;
using Android.Runtime;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Android_Capabilities.Location.LocationListComponents
{
	public class LocationViewHolder : RecyclerView.ViewHolder
	{
        public TextView TimeTextView { get; private set; }
        public TextView ProcessInfoTextView { get; private set; }
        public TextView LocationInfoTextView { get; private set; }
        public TextView ProviderInfoTextView { get; private set; }

        public LocationViewHolder(View itemView) : base(itemView)
        {
            TimeTextView = itemView.FindViewById<TextView>(Resource.Id.timeTextView);
            ProcessInfoTextView = itemView.FindViewById<TextView>(Resource.Id.processTextView);
            LocationInfoTextView = itemView.FindViewById<TextView>(Resource.Id.locationDetailsTextView);
            ProviderInfoTextView = itemView.FindViewById<TextView>(Resource.Id.providerTextView);
        }

    }
}

