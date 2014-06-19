using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        string conn_str = "Server=s12R2\\SQLEXPRESS;Database=demos;Trusted_Connection=True;";
        public IList<Contact> GetAllContacts()
        {
            DataContext db = new DataContext(conn_str);
            Table<Contact>from_db = db.GetTable<Contact>();
            
            IList<Contact>contacts = new List<Contact>();

            foreach (Contact contact in from_db)
            {
                contacts.Add(contact);
            }
            return contacts;
        }

        public bool SaveContact(Contact contact)
        {
            ContactDataContext db = new ContactDataContext(conn_str);
            db.Contacts.InsertOnSubmit(contact);
            try {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }

    public class ContactDataContext : DataContext
    {
        public Table<Contact> Contacts;

        public ContactDataContext(string connection) : base(connection) { }
    }
}