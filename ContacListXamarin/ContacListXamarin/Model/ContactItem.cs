using System;
using SQLite;

namespace ContacListXamarin.Model
{
    [Table("ContactItem")]
    public class ContactItem
    {
        public ContactItem()
        {
            ID = Guid.NewGuid();
        }

        [PrimaryKey]
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
