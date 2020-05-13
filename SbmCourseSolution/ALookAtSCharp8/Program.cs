#nullable enable
using System;

namespace ALookAtSCharp8
{
    internal class Program
    {
        private static string _x;

        static Program()
        {
            _x = "";
        }

        private static void Main(string[] args)
        {
            //var demo = new BeforeCS8();
            //try
            //{
            //    demo.Demo();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            //Console.ReadKey();

            var me = new SomeClassDefiningAPerson("Kurt","Claeys");

        }

        private static int Get(SomeClassDefiningAPerson person)
        {
            Console.WriteLine(person.LastName + " " + _x);
            return 1;

        }
    }
}
