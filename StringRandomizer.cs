using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    class StringRandomizer
    {
        public StringRandomizer()
        {

        }
        public String getRandomString(int length)
        {
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] resultArray = new char[length];

            for (int i = 0; i < length; i++)
            {
                Random x = new Random();
                int randomNum = x.Next(26);
                resultArray[i] = chars[randomNum];
            }
            
            return new String(resultArray);
        }


    }
}
