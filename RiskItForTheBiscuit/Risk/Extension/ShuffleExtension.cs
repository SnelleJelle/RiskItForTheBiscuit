using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RiskItForTheBiscuit.Risk
{
    public static class Extensions
    {
        public static IList<T> Shuffle<T>(this IList<T> input)
        {
            List<T> list = new List<T>(input);
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}
