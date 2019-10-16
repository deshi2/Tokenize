using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    class Tokenizer
    {
        private List<List<StringVariant>> listListOfStringVariants;
        private const int VAR_MAX = 4;    // Пусть количество вложенных списков будет от 1 до 4.
        private ListCounter listCounter;  // Класс, который поможет в обходе наших списков.

        public Tokenizer(int upperListSize)
        {
            this.listListOfStringVariants = generateListListStringVariant(upperListSize);
            listCounter = new ListCounter(this.listListOfStringVariants);
        }

        private List<List<StringVariant>> generateListListStringVariant(int upperListSize)
        {
            List<List<StringVariant>> resultList = new List<List<StringVariant>>();
            for (int i = 0; i < upperListSize; i++)
            {
                Random x = new Random();
                int randomNum = x.Next(1, VAR_MAX);

                List<StringVariant> innerList = new List<StringVariant>();
                for (int j = 0; j < randomNum; j++)
                {
               
                    StringVariant stringVariant = StringVariant.generateRandomInstance();
                    innerList.Add(stringVariant);
                }
                resultList.Add(innerList);
            }

            return resultList;
        }

        public void printListListOfStringVariants()
        {
            Console.WriteLine("[");
            foreach (List<StringVariant> upperItetator in listListOfStringVariants)
            {
                Console.WriteLine("  [");
                foreach(StringVariant innerIterator in upperItetator)
                {
                    Console.Write("    {");
                    String weightToPrint = innerIterator.getWeight().ToString();
                    if (weightToPrint == "")
                    {
                        weightToPrint = "null";
                    }
                    Console.Write(innerIterator.getValue() + ", " + weightToPrint);
                    Console.Write("}");
                    Console.WriteLine(); 
                }
                Console.WriteLine("  ]");
                Console.WriteLine("");
            }
            Console.WriteLine("]");
        }

        public void printListOfStringVariants(List<StringVariant> listOfStringVariant)
        {
            Console.WriteLine("[");
            foreach(StringVariant sv in listOfStringVariant)
            {
                Console.WriteLine("  {" + sv.getValue() + ", " + sv.getWeight() + "}");
            }
            Console.WriteLine("]");
        }

        public List<StringVariant> Variate(double defaultWeight)
        {
            List<StringVariant> resultList = new List<StringVariant>();

            // С помощью нашего класса - счетчика счетчиков списков, "собираем" нужную строку.
            while(true)
            {
                String resultString = "";
                double resultWeight = 1.00;
                for (int i = 0; i < listListOfStringVariants.Count; i++)
                {
                    resultString += listListOfStringVariants[i][listCounter.counters[i][0]].getValue();
                    double curWeightNotNull = defaultWeight;
                    double? curWeight = listListOfStringVariants[i][listCounter.counters[i][0]].getWeight();
         
                    if (curWeight != null)
                    {
                        curWeightNotNull = curWeight.Value;
                    }
                    resultWeight *= curWeightNotNull;

                }
                resultWeight = Math.Round(resultWeight, 2);
                StringVariant sv = new StringVariant(resultString, resultWeight);
                resultList.Add(sv);

                if (!listCounter.iterate())
                {
                    break;
                }

            }

            return resultList;

        }

    }
}
