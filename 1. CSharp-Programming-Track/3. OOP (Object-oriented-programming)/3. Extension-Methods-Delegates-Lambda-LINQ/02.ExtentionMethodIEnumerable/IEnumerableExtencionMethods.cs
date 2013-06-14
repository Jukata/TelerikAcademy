using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExtentionMethodIEnumerable
{
    public static class IEnumerableExtencionMethods
    {
        //calculating sum
        public static T Sum<T>(this IEnumerable<T> sequence)
        {
            dynamic sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
            }
            return sum;
        }

        //calculating product
        public static T Product<T>(this IEnumerable<T> sequence)
        {
            dynamic product = 1;
            foreach (var item in sequence)
            {
                product *= item;
            }
            return product;
        }

        //calculatin minimum
        public static T Min<T>(this IEnumerable<T> sequence)
        {
            dynamic min = int.MaxValue;
            foreach (var item in sequence)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> sequence)
        {
            dynamic max = int.MinValue;
            foreach (var item in sequence)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        public static T Average<T>(this IEnumerable<T> sequence)
        {
            dynamic average = 0;
            dynamic sum = 0;
            int counter = 0;
            foreach (var item in sequence)
            {
                sum += item;
                counter++;
            }

            return average = sum / counter;
        }
    }
}
