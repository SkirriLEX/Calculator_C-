using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculate
    {
        private static char[] action = { '*', '/', '+', '-' };

        public static string compute(string equation_line)
        {
            int counter, startCounter;
            counter = startCounter = 0;


            equation_line = filter(equation_line);

            for (int i = 0; i < equation_line.Length; i++)
            {
                if (equation_line[i].Equals('('))
                {
                    if (counter == 0)
                    {
                        startCounter = i;
                    }
                    counter++;
                }
                if (equation_line[i].Equals(')'))
                {
                    counter--;
                    if (counter == 0)
                    {
                        string line = equation_line.Substring(startCounter + 1, i - startCounter - 1);
                        equation_line = equation_line.Replace("(" + line + ")", Calculate.compute(line));
                    }

                }
            }
            string[] parseNumber = equation_line.Split(new char[] { '+', '-', '/', '*', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] parseAction = equation_line.Split(parseNumber, StringSplitOptions.RemoveEmptyEntries);

            if (parseNumber.Length > 1)
            {
                for (int ch = 0; ch < action.Length; ch++)
                {
                    string line = parseNumber[0] + action[ch] + parseNumber[0 + 1];
                    equation_line = equation_line.Replace(line, comparare(parseNumber[0], parseNumber[0], action[ch]));
                }
                equation_line = compute(equation_line);
            }            
            return equation_line;
        }

        private static string filter(string equation_line)
        {
            char[] filterSymbol = { '+', '-', '/', '*', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '(', ')' };
            string[] filtered_line = equation_line.Split(filterSymbol, StringSplitOptions.RemoveEmptyEntries);

            if (filtered_line.Length > 0)
            {
                equation_line = equation_line.Replace(filtered_line[0], string.Empty);
                equation_line = filter(equation_line);
            }
            return equation_line;
        }

        private static string comparare(string num_1, string num_2, char action)
        {
            string answer = "";

            return answer;
        }

        private static string calc(string line)
        {
            return "xleb";
        }
    }
}
