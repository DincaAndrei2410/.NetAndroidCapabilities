package crc649dafd96ba9b2f926;


public class LocationViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Android_Capabilities.Location.LocationListComponents.LocationViewHolder, Android_Capabilities", LocationViewHolder.class, __md_methods);
	}


	public LocationViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == LocationViewHolder.class) {
			mono.android.TypeManager.Activate ("Android_Capabilities.Location.LocationListComponents.LocationViewHolder, Android_Capabilities", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
