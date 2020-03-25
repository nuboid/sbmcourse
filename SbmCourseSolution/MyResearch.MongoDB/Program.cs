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


            //ListDatabases();
            //RunStats();
            DeleteAllDocumentsInCollection();
            InsertDocumentsWithBookService();
            FindDocument();
            
            Console.WriteLine("Done");

            Console.ReadKey();
        }

        private static void ListDatabases()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
        private static void RunStats()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase db = dbClient.GetDatabase("nuboidtest");

            var command = new BsonDocument { { "dbstats", 1 } };
            var result = db.RunCommand<BsonDocument>(command);
            Console.WriteLine(result.ToJson());
        }

        private static void DeleteAllDocumentsInCollection()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase db = dbClient.GetDatabase("nuboidtest");

            var collection = db.GetCollection<Book>("MyCollection");
            collection.DeleteMany(c => true);
        }
        private static void FindDocument()
        {
            var dbClient = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase db = dbClient.GetDatabase("nuboidtest");
            var collection = db.GetCollection<BsonDocument>("MyCollection");

            var filter = Builders<BsonDocument>.Filter.Eq("Category", "History");

            foreach (var doc in collection.Find(filter).ToList())
            {
                Console.WriteLine(doc.ToString());
            }
                
            
        }
        private static void InsertDocumentsWithBookService()
        {
            var bookService = new BookService("mongodb://localhost:27017", "nuboidtest", "MyCollection");

            bookService.Create(new Book()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Author = "Jef Nys",
                BookName = "Jommeke 57 - Het geheim van Macu Ancapa",
                Category = "Strips",
                Price = 3.14d
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

            bookService.Create(new Book()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Author = "Yuval Noah Harari",
                BookName = "Sapiens - A Brief History of Humankind",
                Category = "History",
                Price = 3.14d
            });
        }
    }
}
