namespace ExpressionTreeDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using System.Threading;


    class Program
    {
        static Task[] tasks = new Task[4];
        static Barrier barrier = null;

        static void Main(string[] args)
        {
            barrier = new Barrier(tasks.Length, x =>
            {
                Console.WriteLine("***************************");
                Console.WriteLine("Current barrier number: {0}", x.CurrentPhaseNumber);
                Console.WriteLine("***************************");
            });

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {

                });
            }



            /*
            Expression<Func<int, int, int>> expression = (a, b) => a + b;

            BinaryExpression body = (BinaryExpression)expression.Body;
            ParameterExpression left = (ParameterExpression)body.Left;
            ParameterExpression right = (ParameterExpression)body.Right;
            Console.WriteLine("expression body: " + expression.Body);

            Console.WriteLine(" The left part of the expression: " +
              "{0}{4} The NodeType: {1}{4} The right part: {2}{4} The Type: {3}{4}",
              left.Name, body.NodeType, right.Name, body.Type, Environment.NewLine);

            Console.WriteLine("Param 1: {0}, Param 2: {1}", expression.Parameters[0], expression.Parameters[1]);

            int result = expression.Compile()(3, 5);
            Console.WriteLine(result);

            */

            //List<string> s = new List<string> { "abc", "def" };

            //s.Where(x => x.Length > 1 && x.Contains('a')).ToList().ForEach(x => Console.Write(x));

            //string str = "test";

            //Console.WriteLine("{0} : {1}", GetName(() => str.Length), str.Length);


            //PrintProperty(() => str.Length);

            //int a = 11;
            //Console.WriteLine((a/2.2d));
            //Console.WriteLine((decimal)a/2);

            bool test = GetTFromString<bool>("true");

            Console.WriteLine(test);

        }

        private static T GetTFromString<T>(string myString)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(myString));
        }

        public static string GetName<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression)e.Body;
            return member.Member.Name;
        }

        public static void PrintProperty<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression)e.Body;
            string propertyName = member.Member.Name;
            T value = e.Compile()();
            Console.WriteLine("{0} : {1}", propertyName, value);
        }

        public static void PrintPropertyAndObject<T>(Expression<Func<T>> e)
        {
            MemberExpression member = (MemberExpression)e.Body;
        }
    }
}
