using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    class ListCounter
    {
        public List<List<int>> counters;

        public ListCounter(List<List<StringVariant>> inputList)
        {
            counters = new List<List<int>>();

           for (int i = 0; i < inputList.Count; i++)
            {
                List<int> li = new List<int>();
                li.Add(0);
                li.Add(inputList[i].Count);
                counters.Add(li);
            }
        }
       
        public Boolean iterate() {

            if (!checkIfCounterIsFull())
            {
                for(int i = counters.Count - 1; i >= 0; i--)
                {
                    if (counters[i][0] == (counters[i][1] - 1))
                    {
                        counters[i][0] = 0;
                        continue;
                    }
                    else
                    {
                        counters[i][0]++;
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        private Boolean checkIfCounterIsFull()
        {
            for (int i = 0; i < counters.Count; i++)
            {
                if (counters[i][0] != (counters[i][1] - 1))
                {
                    return false;                    
                }
            }
            
            return true;
        }

        // Данный метод был нужен для отладки.
        public void printCounter()
        {
            System.Console.WriteLine("size: " + counters.Count);
            for (int i = 0; i < counters.Count; i++)
            {
                System.Console.WriteLine("----");
                System.Console.Write(counters[i][0] + " " + counters[i][1]);
            }

        }
    }
}
