using System.ComponentModel.DataAnnotations;

namespace DomainModel.Model
{
    public class Category
    {
        [Key]
        public string CategoryName { get; set; }
    }
}
