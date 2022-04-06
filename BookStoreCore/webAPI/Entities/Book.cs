using System.ComponentModel.DataAnnotations.Schema;
namespace webAPI.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//auto increment ekleme attibute'si
        //! aslında entity framework  core bunu otomatik olarak tanıyor Id ismini gördüğünde auto increment 
        //! olacağını bildiği için bu ayarı yapacaktır. 
        public int bookId { get; set; }
        public string bookTitle { get; set; }
        public DateTime bookRelase { get; set; }
        public int bookPage { get; set; }

        public int genreId { get; set; }
    }
}
