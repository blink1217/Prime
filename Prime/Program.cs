using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = IsPrime(3);
            Console.WriteLine(p.ToString());
            Console.ReadLine(); 

        }
        public static bool IsPrime(int input)
        {
            // Your code goes here
            var inputAsString = input.ToString();
            switch (inputAsString.Substring(inputAsString.Length - 1))
            {
                case "2":
                    return false;
                case "4":
                    return false;
                case "5":
                    return false;
                case "6":
                    return false;
                case "8":
                    return false;
                case "0":
                    return false;
            }

            string s = "10";
            int re = input;
            while (s.Length > 1)
            {
                re = RecursiveSum(re);
                s = re.ToString(); 
            }
            if (re == 9)
                return false;

            int RecursiveSum(int inp)
            {
                int res = inp % 9;
                return (res == 0 && inp > 0) ? 9 : res;
            }

            if (inputAsString.Length == 1)
            {
                if(input % 7 == 0)
                {
                    return false; 
                }
                return true;
            }
            else
            {
                int i = Int32.Parse(inputAsString.Substring(0, inputAsString.Length - 2));
                int last = Int32.Parse(inputAsString.Substring(inputAsString.Length - 1));

                if ((i - 2 * last) % 7 == 0)
                    return false;

                var inputAsArray = inputAsString.ToCharArray().ToList();

                int result = 0;
                int index = 1;
                while (inputAsArray.Count != 0)
                {
                    if (index % 2 == 0)
                    {
                        result += inputAsArray[0];
                        inputAsArray.RemoveAt(0);
                        index++;
                    }
                    else
                    {
                        result -= inputAsArray[0];
                        inputAsArray.RemoveAt(0);
                        index++;
                    }
                }
                if (result % 11 == 0)
                    return false;

                if (input != 1)
                    return true;

                return true;
            }

        }


    }
}
