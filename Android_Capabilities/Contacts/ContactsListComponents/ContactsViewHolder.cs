using System;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace Android_Capabilities.Contacts.ContactsListComponents
{
    public class ContactsViewHolder : RecyclerView.ViewHolder
    {
        public TextView NameTextView { get; private set; }
        public TextView PhoneTextView { get; private set; }

        public ContactsViewHolder(View itemView) : base(itemView)
        {
            NameTextView = itemView.FindViewById<TextView>(Resource.Id.nameTextView);
            PhoneTextView = itemView.FindViewById<TextView>(Resource.Id.phoneTextView);
        }
    }
}

