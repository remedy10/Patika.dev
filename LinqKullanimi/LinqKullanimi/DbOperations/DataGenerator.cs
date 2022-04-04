using LinqKullanimi.Entities;

namespace LinqKullanimi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize()
        {
            using (var context = new StudentDbContext())
            {
                if (context.Students.Any())
                    return;
                context.Students.AddRange(
                    new Student()
                    {
                        Name = "Şerif",
                        Surname = "Gülemez",
                        classId = 1
                    },
                    new Student()
                    {
                        Name = "Mehmet",
                        Surname = "Eskimiş",
                        classId = 1
                    },
                    new Student()
                    {
                        Name = "Hasan",
                        Surname = "Bora",
                        classId = 2
                    },
                    new Student()
                    {
                        Name = "Seyfullah",
                        Surname = "Taşcı",
                        classId = 2
                    },
                    new Student()
                    {
                        Name = "Buse",
                        Surname = "İşler",
                        classId = 1
                    },
                    new Student()
                    {
                        Name = "Ezgişah",
                        Surname = "Bakır",
                        classId = 1
                    },
                    new Student()
                    {
                        Name = "İsmail",
                        
                        Surname = "Düşer",
                        classId = 1
                    }
                );
                context.SaveChanges();
            }
        } //verilerimiz oluşturuyoruz bunu program.cs içinde kullanım
        //program ayağa kalktıgında otomatik olarak atanmasını sağlayacağız.
    }
}
