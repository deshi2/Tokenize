using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    class Tokenizer
    {
        private List<List<StringVariant>> listListOfStringVariants;
        
        private const int VAR_MAX = 4; // Пусть количество вложенных списков будет от 1 до 4.

        public Tokenizer(int upperListSize)
        {
            this.listListOfStringVariants = generateListListStringVariant(upperListSize);
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

            for (int i = 0; i < listListOfStringVariants.Count; i++)
            {
                for(int j = 0; j < listListOfStringVariants[i].Count; j++)
                {
                    for(int k = i + 1; k < listListOfStringVariants.Count; k++)
                    {
                        for(int l = 0; l < listListOfStringVariants[k].Count; l++)
                        {
                            String resultString = listListOfStringVariants[i][j].getValue() + listListOfStringVariants[k][l].getValue();

                            double? leftWeight = listListOfStringVariants[i][j].getWeight();
                            double? rightWeight = listListOfStringVariants[k][l].getWeight();
                            double leftMultiplier = defaultWeight;
                            double rightMultiplier = defaultWeight;

                            if (leftWeight != null)
                            {
                                leftMultiplier = leftWeight.Value;
                            }

                            if (rightWeight != null)
                            {
                                rightMultiplier = rightWeight.Value;
                            }

                            double resultWeight = Math.Round(leftMultiplier * rightMultiplier, 2);

                            StringVariant sv = new StringVariant(resultString, resultWeight);
                            resultList.Add(sv);
                        }
                    }
                }
            }

            return resultList;

        }

    }
}
