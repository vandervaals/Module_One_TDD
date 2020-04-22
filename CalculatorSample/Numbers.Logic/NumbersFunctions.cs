using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Logic
{
    public static class NumbersFunctions
    {
        public static int[] SearchNumbers(int sum, int capacity)
        {
            if (sum < 0 || capacity < 0)
                throw new ArgumentException("Not vaid input params");

            int count = 0;
            int min = int.MaxValue;
            int max = 0;
            int temp = 0;

            int start = (int)Math.Pow(10, capacity - 1);
            int end = (int)Math.Pow(10, capacity) - 1;

            for (int i = start; i <= end;)
            {
                temp = GetDigitSum(i);
                if (temp == sum)
                {
                    count++;

                    if (min > i)
                        min = i;

                    if (max < i)
                        max = i;

                    i += 9;
                    continue;
                }

                i++;
            }

            return count == 0 ? new int[0] : new int[] { count, min, max };
        }

        private static int GetDigitSum(int number)
        {
            int sum = 0;

            while (number != 0)
            {
                sum += number % 10;
                number = number / 10;
            }

            return sum;
        }
    }
}
