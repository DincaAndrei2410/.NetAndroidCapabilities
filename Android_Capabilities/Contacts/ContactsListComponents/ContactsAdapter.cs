using System;
using Android.Views;
using Android_Capabilities.Location.LocationListComponents;
using Android_Capabilities.ModelsShared;
using AndroidX.RecyclerView.Widget;

namespace Android_Capabilities.Contacts.ContactsListComponents
{
	public class ContactsAdapter : RecyclerView.Adapter
	{
        List<Contact> _contacts;

        public ContactsAdapter(List<Contact> contacts)
		{
            _contacts = contacts;
        }

        public override int ItemCount => _contacts.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ContactsViewHolder vh = holder as ContactsViewHolder;

            var contact = _contacts[position];

            vh.NameTextView.Text = $"Name: {contact.DisplayName}";
            vh.PhoneTextView.Text = $"Phone: {contact.PhoneNumber}";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                       Inflate(Resource.Layout.contact_cell, parent, false);

            ContactsViewHolder cvh = new ContactsViewHolder(itemView);
            return cvh;
        }
    }
}

