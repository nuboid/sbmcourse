using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.IO;

namespace MyResearch.MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MongoDB");

            //var dbClient = new MongoClient("mongodb://localhost:27017");

            //var dbList = dbClient.ListDatabases().ToList();

            //Console.WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    Console.WriteLine(db);
            //}

            var bookService = new BookService("mongodb://localhost:27017", "nuboidtest", "MyCollection");

            bookService.Create(new Book()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Author ="Jef Nys",
                BookName= "Jommeke 57 - Het geheim van Macu Ancapa",
                Category ="Strips",
                Price  = 3.14d 
            });

            bookService.Create(new Book()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Author = "Yuval Noah Harari",
                BookName = "21 Lessons for the 21st Century",
                Category = "History",
                Price = 3.14d
            });

            bookService.Create(new Book()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Author = "Lonely Planet",
                BookName = "Epic Hikes of the World",
                Category = "Hikes",
                Price = 3.14d
            });

            

            Console.WriteLine("Done");

            Console.ReadKey();
        }
    }
}
