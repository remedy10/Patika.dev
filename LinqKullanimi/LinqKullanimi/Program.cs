// See https://aka.ms/new-console-template for more information
using LinqKullanimi.DbOperations;
using LinqKullanimi.Entities;

DataGenerator.Initialize();
StudentDbContext studentDbContext = new();
var students = studentDbContext.Students.ToList<Student>;
List<Student> studentList = studentDbContext.Students.ToList();
#region StudentList
Console.WriteLine("---Students--");
studentList.ForEach(
    student =>
        Console.WriteLine(
            "| ID={0} | Name={1} | Surname={2} | ClassId={3} |",
            student.Id,
            student.Name,
            student.Surname,
            student.classId
        )
);
#endregion
//! Kendimce önemli görüdüğüm methodları burada yazıyorum.
#region Find()
Console.WriteLine("---Find--");
var student = studentDbContext.Students.Find(7);
Console.WriteLine(student.Name.ToString());
Console.WriteLine("Hello, World!");
#endregion
#region ToList()
Console.WriteLine("---ToList--");
var studentlist = studentDbContext.Students.Where(s => s.classId == 2).ToList();
foreach (var item in studentlist)
{
    Console.WriteLine(
        "| ID={0} | Name={1} | Surname={2} | ClassId={3} |",
        item.Id,
        item.Name,
        item.Surname,
        item.classId
    );
}
#endregion
#region OrderBy(Asc) & OrderBy(Desc)
Console.WriteLine("OrderBy(Asc)");
var x = studentDbContext.Students.OrderBy(s => s.classId).ToList();
x.ForEach(
    y =>
        Console.WriteLine(
            "| ID={0} | Name={1} | Surname={2} | ClassId={3} |",
            y.Id,
            y.Name,
            y.Surname,
            y.classId
        )
);
Console.WriteLine("OrderBy(Desc)");
var y = studentDbContext.Students.OrderByDescending(s => s.classId).ToList();
y.ForEach(
    z =>
        Console.WriteLine(
            "| ID={0} | Name={1} | Surname={2} | ClassId={3} |",
            z.Id,
            z.Name,
            z.Surname,
            z.classId
        )
);
#endregion
#region GroupBy()
var groupBy=studentDbContext.Students.GroupBy(studentx=>studentx.classId).ToList();

//? Sıkıldım be

#endregion

