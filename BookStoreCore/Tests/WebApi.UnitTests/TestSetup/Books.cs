using System;
using webAPI.DBOperations;
using webAPI.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    bookTitle = "Lord of the Rings",
                    bookPage = 1100,
                    bookRelase = new DateTime(1972, 01, 01),
                    AuthorId = 1,
                    genreId = 3 //Fantasy
                },
                new Book
                {
                    bookTitle = "Hobbit",
                    bookPage = 400,
                    bookRelase = new DateTime(1937, 05, 07),
                    AuthorId = 1,
                    genreId = 3 //Fantasy
                },
                new Book
                {
                    bookTitle = "Dublorün Dilemması",
                    bookPage = 200,
                    bookRelase = new DateTime(2010, 01, 01),
                    AuthorId = 3,
                    genreId = 8 //Action
                },
                new Book
                {
                    bookTitle = "Ruhi Mücerret",
                    bookPage = 318,
                    bookRelase = new DateTime(2013, 01, 01),
                    AuthorId = 3,
                    genreId = 7 //Detective
                },
                new Book
                {
                    bookTitle = "Beyaz Diş",
                    bookPage = 258,
                    bookRelase = new DateTime(1906, 01, 01),
                    AuthorId = 4,
                    genreId = 8 //Action
                }
            );
        }
    }
}
