using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Data.Models
{
    public class BasicData<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
