using System;
using webAPI.DBOperations;
using webAPI.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthor(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author
                {
                    NameAndSurname = "JRR Tolkien",
                    DateOfBirth = new DateTime(1892, 01, 03) //1
                },
                new Author
                {
                    NameAndSurname = "Chris Tolkien",
                    DateOfBirth = new DateTime(1924, 11, 21) //2
                },
                new Author
                {
                    NameAndSurname = "Murat Menteş",
                    DateOfBirth = new DateTime(1974, 09, 01) //3
                },
                new Author
                {
                    NameAndSurname = "Jack London",
                    DateOfBirth = new DateTime(1876, 01, 12) //4
                }
            );
        }
    }
}
