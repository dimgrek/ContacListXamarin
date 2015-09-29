﻿ using System.Collections.Generic;
 using System.Linq;
 using ContacListXamarin.Model;
 using ContacListXamarin.Services.Database;
 using SQLite;
 using Xamarin.Forms;

namespace ContacListXamarin.Contacts
{
    public interface IContactService
    {
        void Add(ContactItem item);
        void Delete(ContactItem contactItem);
        IEnumerable<ContactItem> GetThings();
    }

    public class ContactService:IContactService
    {
        private readonly SQLiteConnection _connection;

        public ContactService()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<ContactItem>();
        }

        public IEnumerable<ContactItem> GetThings()
        {
            var contacts = _connection.Table<ContactItem>().ToList();
            return contacts;
        }

        public void Add(ContactItem item)
        {
            _connection.Insert(item);
        }

        public void Delete(ContactItem contactItem)
        {
            _connection.Delete(contactItem);
            _connection.UpdateAll(_connection.Table<ContactItem>());
        }
    }
}
