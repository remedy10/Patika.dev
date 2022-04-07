using System.ComponentModel.DataAnnotations.Schema;

namespace webAPI.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NameAndSurname { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
