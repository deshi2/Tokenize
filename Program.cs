using System;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Tokenizer tokenizer = new Tokenizer(3);
            Console.WriteLine("Current tokenizer: ");
            tokenizer.printListListOfStringVariants();
            Console.WriteLine("");

            List<StringVariant> listOfVariants = tokenizer.Variate(1);
            Console.WriteLine("Result variants: ");
            tokenizer.printListOfStringVariants(listOfVariants);
        }
    }
}
