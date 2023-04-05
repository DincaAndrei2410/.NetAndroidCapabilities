using System;
using Android.Database;
using Android.Provider;
using Android_Capabilities.ModelsShared;
using AndroidX.Loader.Content;
using static Android.Provider.ContactsContract;

namespace Android_Capabilities.Contacts
{
	public class ContactsService
	{
		public List<Contact> GetContacts(Android.Content.Context context)
		{
			var uri = CommonDataKinds.Phone.ContentUri;

            var loader = new CursorLoader(context, uri, null, null, null, null);
            var cursor = (ICursor)loader.LoadInBackground();

            var contactList = new List<Contact>();
            if (cursor.MoveToFirst())
            {
                do
                {
                    contactList.Add(new Contact
                    {
                        PhoneNumber = cursor.GetString(cursor.GetColumnIndex(CommonDataKinds.Phone.Number)),
                        Id = cursor.GetLong(cursor.GetColumnIndex("name_raw_contact_id")),
                        DisplayName = cursor.GetString(cursor.GetColumnIndex("display_name"))
                    });
                } while (cursor.MoveToNext());
            }

            return contactList;
        }
	}
}

