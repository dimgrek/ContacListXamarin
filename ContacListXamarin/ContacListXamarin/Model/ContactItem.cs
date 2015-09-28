using SQLite;

namespace ContacListXamarin.Model
{
    [Table("ContactItem")]
    public class ContactItem 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
