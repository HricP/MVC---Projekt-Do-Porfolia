using System.ComponentModel.DataAnnotations;

namespace MVC___31._05._2023.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }    
    }
}
