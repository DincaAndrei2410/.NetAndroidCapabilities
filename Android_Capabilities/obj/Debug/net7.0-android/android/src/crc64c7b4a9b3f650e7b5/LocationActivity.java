package crc64c7b4a9b3f650e7b5;


public class LocationActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onRequestPermissionsResult:(I[Ljava/lang/String;[I)V:GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler\n" +
			"";
		mono.android.Runtime.register ("Android_Capabilities.Location.LocationActivity, Android_Capabilities", LocationActivity.class, __md_methods);
	}


	public LocationActivity ()
	{
		super ();
		if (getClass () == LocationActivity.class) {
			mono.android.TypeManager.Activate ("Android_Capabilities.Location.LocationActivity, Android_Capabilities", "", this, new java.lang.Object[] {  });
		}
	}


	public LocationActivity (int p0)
	{
		super (p0);
		if (getClass () == LocationActivity.class) {
			mono.android.TypeManager.Activate ("Android_Capabilities.Location.LocationActivity, Android_Capabilities", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2)
	{
		n_onRequestPermissionsResult (p0, p1, p2);
	}

	private native void n_onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2);

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
