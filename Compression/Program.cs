using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter string to compress: ");
                Console.WriteLine(compress(Console.ReadLine()));//AABBAACCBBCC
            }
        }
        static int lastVal = 0;
        static string compress(String input)
        {
            bool hasChanged = false;
            string output = "";
            Dictionary<string, int> hasOccured = new Dictionary<string, int>();
            for (int i = 0; i < input.Length; i +=2)
            {
                if (input.Length - i > 1)
                {
                    String temp = input.Substring(i, 2);
                    if (!hasOccured.ContainsKey(temp)) { hasOccured.Add(temp, lastVal); lastVal++; }
                    else
                    {
                        temp = Convert.ToString(hasOccured[temp]);
                        hasChanged = true;
                    }
                    output += temp;
                }
                else output += input.Substring(i, 1);
            }
           //Console.WriteLine(output + " : " + hasChanged);
            if (hasChanged) return compress(output);
           else return output;
        }
    }
}