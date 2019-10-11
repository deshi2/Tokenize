using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    class StringVariant
    {

        private String value;
        private double? weight;

        public const double WEIGHT_MAX = 1.00; // Положим максимальный вес = 1
        public const int VALUE_LENGTH_MAX = 7; // Пусть максимальная длина строки value = 7

        public StringVariant(String value, double? weight)
        {
            this.value = value;

            // Если больше максимального веса, то получаем null
            if (weight <= WEIGHT_MAX)
            {
                this.weight = weight;
            }
        }

        public static StringVariant generateRandomInstance()
        { // фабрика для объекта со случайными полями

            String randomValue;
            double? randomWeight;

            Random x = new Random();
            int randomNum = x.Next(1, VALUE_LENGTH_MAX);

            StringRandomizer stringRandomizer = new StringRandomizer();

            randomValue = stringRandomizer.getRandomString(randomNum);
            randomWeight = generateRandomWeight(WEIGHT_MAX + 0.10); // увеличиваем наш максимальный вес, чтобы получить null

            StringVariant randomInstance;

            randomInstance = new StringVariant(randomValue, randomWeight);

            return randomInstance;
        }

        private static double? generateRandomWeight(double maxWeight)
        {
            double randomWeight;
            Random x = new Random();
            randomWeight = x.NextDouble()*(maxWeight + 0.10); // прибывим 0.1 для того, чтобы генерировать null в диапазоне от 1 до 1.1
            randomWeight = Math.Round(randomWeight, 2);

            if (randomWeight > 1.00) 
            {
                return null;
            }
            else
            {
                return randomWeight;
            }   
        }

        // SETTERS AND GETTERS

        public String getValue()
        {
            return value;
        }

        public void setValue(String value)
        {
            this.value = value;
        }

        public double? getWeight()
        {
            return weight;
        }

        public void setWeight(double? weight)
        {
            this.weight = weight;
        }

    }
}
