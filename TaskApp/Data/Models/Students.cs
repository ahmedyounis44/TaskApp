using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Data.Models
{
    public class Students:BasicData<int>
    {
        
        public int Country_Id { get; set; }
        [ForeignKey("Country_Id")]
        public Countries CountryData { get; set; }

       
        public int Class_Id { get; set; }
        [ForeignKey("Class_Id")]
        public Classes ClassData { get; set; }


        [Required]
        public string Name { get; set; }

        public string ? Image { get; set; }

        [Required]
        public DateTime Date_Of_Birth { get; set; }


    }
}
