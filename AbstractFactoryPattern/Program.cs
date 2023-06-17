using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        //Öncelik ürünle ilgili tasarımlarla başlamak.

        static void Main(string[] args)
        {
            Factory factory = new Factory(new InterbaseFactory());
            factory.Start();

            Console.WriteLine("");

            Factory factory1 = new Factory(new Db2Factory());
            factory1.Start();
        }
    }
}
