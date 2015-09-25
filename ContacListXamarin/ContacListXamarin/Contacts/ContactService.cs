﻿using System.Collections.Generic;
using System.Linq;
using ContacListXamarin.Model;
using ContacListXamarin.Services.Database;
using SQLite;
using Xamarin.Forms;

namespace ContacListXamarin.Contacts
{
    public interface IContactService
    {
        void Add(string name, string lastName, string address, string email, string telephone, string company);
        void Delete(int id);
        IEnumerable<string> GetThings();
    }

    public class ContactService:IContactService
    {
        private readonly SQLiteConnection _connection;

        public ContactService()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<ContactItem>();
        }

        public void Delete(int id)
        {
            _connection.Delete(id);
        }

        public IEnumerable<string> GetThings()
        {
            var contacts = _connection.Table<ContactItem>().ToList();
            return contacts.Select(contact => $"{contact.Name} {contact.LastName}").ToList();
        }

        public void Add(string name, string lastName, string address, string email, string telephone, string company)
        {
            var contactItem = new ContactItem
            {
                Name = name,
                LastName = lastName,
                Address = address,
                Company = company,
                Telephone = telephone,
                Email = email
            };
            _connection.Insert(contactItem);
        }
    }
}
