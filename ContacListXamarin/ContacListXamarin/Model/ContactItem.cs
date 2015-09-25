using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContacListXamarin.Annotations;
using SQLite;

namespace ContacListXamarin.Model
{
    [Table("ContactItem")]
    public class ContactItem : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged();
            } 
        }

        public string LastName { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
