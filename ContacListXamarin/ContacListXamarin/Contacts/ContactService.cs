using System.Collections.Generic;
using System.Linq;
using ContacListXamarin.Model;
using ContacListXamarin.Services.Database;
using SQLite;
using Xamarin.Forms;

namespace ContacListXamarin.Contacts
{
    public interface IContactService
    {
        void Add(string name);
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

        public void Add(string name)
        {
            var contactItem = new ContactItem { Name = name };
            _connection.Insert(contactItem);
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
    }
}
