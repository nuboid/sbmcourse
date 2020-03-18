using System;

namespace MyApplication.DomainServices.UseCases
{
    class Program
    {
        //https://softwareengineering.stackexchange.com/questions/330428/ddd-repositories-in-application-or-domain-service
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            //Delete the database first.
            System.IO.File.Delete("TestDatabase.db");
            
            Console.WriteLine("UseCases");

            DeliveryPlanning.Init();
            
            DeliveryPlanning.PlanDelivery();

            Console.WriteLine("--------- done --------- ");
            Console.ReadKey();
        }
    }
}
