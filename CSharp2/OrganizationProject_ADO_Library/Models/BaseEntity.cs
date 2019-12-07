using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrganizationProject_ADO_Library.Models
{
    public class BaseEntity:INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        public bool IsChanged { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
