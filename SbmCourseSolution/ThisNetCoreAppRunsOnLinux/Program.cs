using System;

namespace ThisNetCoreAppRunsOnLinux
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Environment.OSVersion.Platform.ToString());
        }
    }
}
