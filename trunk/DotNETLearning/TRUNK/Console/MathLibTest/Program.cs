using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLibTest
{
    class Program
    {
        private static List<int> _preQuitArticleDayCounter = new List<int>();
        static void Main(string[] args)
        {
            //TestMidpointRounding();

            ArticleDivider(7, 11);
            //Print p = new Print();
            //p.print(31);
        }

        private static void ArticleDivider(int articleCount, int days)
        {
            if (articleCount <= 1)
            {
                //Finish on list
                _preQuitArticleDayCounter.Add(days);
            }
            else
            {
                var tempArticle = (int)Math.Round(((decimal)articleCount / 2), MidpointRounding.AwayFromZero);
                var tempDays = (int)Math.Round(((decimal)days / 2), MidpointRounding.AwayFromZero);
                ArticleDivider(tempArticle, tempDays);
                ArticleDivider(articleCount - tempArticle, days - tempDays);
            }

        }

        private static void TestMidpointRounding()
        {
            // AwayFromZero - When a number is halfway between two others, it is rounded toward the nearest number that is away from zero.
            var r1 = Math.Round(-3.5, MidpointRounding.AwayFromZero);
            // ToEven - When a number is halfway between two others, it is rounded toward the nearest even number.
            var r2 = Math.Round(-3.5, MidpointRounding.ToEven);


            // AwayFromZero - When a number is halfway between two others, it is rounded toward the nearest number that is away from zero.
            var r3 = Math.Round(-2.5, MidpointRounding.AwayFromZero);
            // ToEven - When a number is halfway between two others, it is rounded toward the nearest even number.
            var r4 = Math.Round(-2.5, MidpointRounding.ToEven);

            Console.WriteLine("AwayFromZero (-3.5) : {0} \r\nToEven (-3.5) : {1}", r1, r2);
            Console.WriteLine("AwayFromZero (-2.5) : {0} \r\nToEven (-2.5) : {1}", r3, r4);
        }
    }

    class Print
    {
        public void print(int n)
        {
            if (n >= 10)
                print(n / 10);
            Console.Write(n % 10);
        }
    }
}
