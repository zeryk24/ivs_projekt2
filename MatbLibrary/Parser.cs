using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MatbLibrary
{
    public static class Parser
    {
        /// <summary>
        /// Class for handling binary operations like plus, multiply, etc.
        /// </summary>
        class BinaryOperation
        {
            public BinaryOperation(string _regex, Func<int, int, int> _func)
            {
                regex = new Regex(_regex);
                func = _func;
            }
            //regex patern of operation
            public Regex regex;
            //function for the operation from math library
            public Func<int, int, int> func;
        }
        //All operations supported
        enum Operations
        {
            Plus,
            Minus,
            Mul,
            Div,
        }

        //Dictionary of all binary operations and therir matching object
        static Dictionary<Operations, BinaryOperation> binary_operations;
        static Parser()
        {
            //Patter for double number
            string digit_regex = @"(\-?\d+(?:\.?\d*)?)";

            binary_operations = new Dictionary<Operations, BinaryOperation>();

            binary_operations[Operations.Plus] = 
                new BinaryOperation(digit_regex + @"\+" + digit_regex, Functions.Add);
            binary_operations[Operations.Minus] = 
                new BinaryOperation(digit_regex + @"\-" + digit_regex, Functions.Sub);
            binary_operations[Operations.Mul] =
                new BinaryOperation(digit_regex + @"\*" + digit_regex, Functions.Mul);
            binary_operations[Operations.Div] =
                new BinaryOperation(digit_regex + @"\%" + digit_regex, Functions.Div);
        }

      


        /// <summary>
        /// Parses input string to separete calculations and solves them using the Math library
        /// </summary>
        /// <param name="input">Validated string to calculate</param>
        /// <returns>Returns result of the given calculation</returns>
        public static double Solve(string input)
        {
            input = SolveBrackets(input);
            input = SolveBinaryOperation(input, Operations.Mul);
            input = SolveBinaryOperation(input, Operations.Div);
            input = SolveBinaryOperation(input, Operations.Plus);
            input = SolveBinaryOperation(input, Operations.Minus);
            return double.Parse(input);
        }
        /// <summary>
        /// Validates if input string is in corrent format
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <returns>Retruns true if string is valide, false if not</returns>
        public static bool Validate(string input)
        {
            //TODO
            return true;
        }

        /// <summary>
        /// Finds all apearences of specified operation and replaces then with result
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="oper">Operation to be replaced</param>
        /// <returns>string with operation replaced with results</returns>
        static string SolveBinaryOperation(string input, Operations oper)
        {

            MatchCollection matches = binary_operations[oper].regex.Matches(input);
            foreach (Match match in matches)
            {
                //regex pattern is written so x and y is always in group 1 and 2
                int x = int.Parse(match.Groups[1].Value);
                int y = int.Parse(match.Groups[2].Value);

                //uses function from the math library to calculate result
                int result = binary_operations[oper].func(x, y);

                input = input.Replace(match.Value, result.ToString());
            }
            return input;
        }

        static string SolveBrackets(string input)
        {
            Regex regex = new Regex(@"\(((?:[0-9]|\+|\-|\*|\%)*)\)");
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                int result = (int)Solve(match.Groups[1].Value);
                input = input.Replace(match.Value, result.ToString());
            }
            return input;
        }

    }
}
