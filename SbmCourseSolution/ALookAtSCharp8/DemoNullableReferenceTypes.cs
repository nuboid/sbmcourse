using System;
#nullable enable
namespace ALookAtSCharp8
{
    public class DemoNullableReferenceTypes
    {
        static void SomeOtherMethod(string s)
        {
            Console.WriteLine(s.Length);
        }
        static void SomeMethod(string[] args)
        {
            string s = (args.Length > 0) ? args[0] : null;

            SomeOtherMethod(s);
        }
    }
}