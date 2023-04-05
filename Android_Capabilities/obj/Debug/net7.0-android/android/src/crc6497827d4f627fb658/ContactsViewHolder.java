package crc6497827d4f627fb658;


public class ContactsViewHolder
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Android_Capabilities.Contacts.ContactsListComponents.ContactsViewHolder, Android_Capabilities", ContactsViewHolder.class, __md_methods);
	}


	public ContactsViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == ContactsViewHolder.class) {
			mono.android.TypeManager.Activate ("Android_Capabilities.Contacts.ContactsListComponents.ContactsViewHolder, Android_Capabilities", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
