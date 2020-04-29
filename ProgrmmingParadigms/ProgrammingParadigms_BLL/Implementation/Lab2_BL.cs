using ProgrammingParadigms_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingParadigms_BLL.Implementation
{
    public class Lab2_BL : ILab2_BL
    {
        public async Task<string> GetResultAsync(string list, int n)
        {
            return await Task.Run(() => GetResult(GetList(list), n));
        }

        public string GetResult(List<int> list, int n)
        {
            int r, delta = (list.Count / n)*n == list.Count ? list.Count / n : (list.Count / n)+1;
            var result = "([ ";
            r = delta;
            for (int i = 0; i < list.Count; i++)
            {
                if (i == r)
                {
                    r += delta;
                    result += $"], [ {list[i]}, ";
                }
                else if (i + 1 == r)
                {
                    result += $"{list[i]} ";
                }
                else
                {
                    result += list.Count -1 == i ? $"{list[i]} ": $"{list[i]}, ";
                }

            }

            result += "])";

            return result;
        }

        

        private List<int> GetList(string data)
        {
            string input = data;
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input is empty!");
            }

            var numbers = input.Split(',', ';').Where(x => !string.IsNullOrWhiteSpace(x));

            if (numbers.All(x => int.TryParse(x, out int res)))
            {
                List<int> list = new List<int>();
                for (int i = 0; i < numbers.Count(); i++)
                {
                    list.Add(int.Parse(numbers.ElementAt(i)));
                }

                return list;
            }
            else
            {
                throw new ArgumentException("Incorrect input numbers!");
            }
        }

   
    }
}
