using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Data.Models
{
    public class Classes: BasicData<int>
    {
       
        [Required]
        public string Class_Name { get; set; }
    }
}
