using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Data.Models
{
    public class Countries:BasicData<int>
    {
        
        [Required]
        public string Name { get; set; }
    }
}
