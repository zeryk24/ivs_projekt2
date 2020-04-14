using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace MatbLibrary
{
    public static class Parser
    {
        /// <summary>
        /// Class for handling binary operations like plus, multiply, etc.
        /// </summary>
        class Operation
        {
            public Operation(string _regex, Func<double, double, double> _func)
            {
                regex = new Regex(_regex);
                binFunc = _func;
                type = Operation_type.Binary;
            }

            public Operation(string _regex, Func<double, double> _func)
            {
                regex = new Regex(_regex);
                unFunc = _func;
                type = Operation_type.Unary;
            }

            public Operation_type type;

            //regex patern of operation
            public Regex regex;
            //function for the operation from math library
            //binary function (two parameters)
            public Func<double, double, double> binFunc;
            //unary function (one parametr
            public Func<double, double> unFunc;
        }
        //All operations supported
        enum Operations
        {
            Plus,
            Minus,
            Mul,
            Div,
            Pow,
            Sqrt,
            Fac,
            NLog,
        }
        enum Operation_type
        {
            Binary,
            Unary
        }
        //Dictionary of all binary operations and therir matching object
        static Dictionary<Operations, Operation> operation_list;
        static Parser()
        {
            //Patter for double number
            string digit_regex = @"((?:\-|\+)?\d+(?:\.?\d*)?)";

            operation_list = new Dictionary<Operations, Operation>();
            //unary
            operation_list[Operations.Fac] =
                new Operation(digit_regex + @"\!", Functions.Fact);
            operation_list[Operations.NLog] =
                new Operation(@"ln" + digit_regex, Functions.NatLog);

            //binary operations
            operation_list[Operations.Plus] = 
                new Operation(digit_regex + @"\+" + digit_regex, Functions.Add);
            operation_list[Operations.Minus] = 
                new Operation(digit_regex + @"\-" + digit_regex, Functions.Sub);
            operation_list[Operations.Mul] =
                new Operation(digit_regex + @"\*" + digit_regex, Functions.Mul);
            operation_list[Operations.Div] =
                new Operation(digit_regex + @"\/" + digit_regex, Functions.Div);
            operation_list[Operations.Pow] =
                new Operation(digit_regex + @"\^" + digit_regex, Functions.Exp);
            operation_list[Operations.Sqrt] =
                new Operation(digit_regex + @"\√" + digit_regex, Functions.Root);
        }

      


        /// <summary>
        /// Parses input string to separete calculations and solves them using the Math library
        /// </summary>
        /// <param name="input">Validated string to calculate</param>
        /// <returns>Returns result of the given calculation or NaN if it fails</returns>
        public static double Solve(string input)
        {
            input = ReplaceSigns(input);
            input = SolveBrackets(input);
            input = SolveOperation(input, Operations.NLog);
            input = SolveOperation(input, Operations.Fac);
            input = SolveOperation(input, Operations.Pow);
            input = SolveOperation(input, Operations.Sqrt);
            input = SolveOperation(input, Operations.Mul);
            input = SolveOperation(input, Operations.Div);
            input = SolveOperation(input, Operations.Plus);
            input = SolveOperation(input, Operations.Minus);

            input = ReplaceSigns(input);

            double result;
            if (!double.TryParse(input, out result))
                return double.NaN;
            else return result;
        }
        /// <summary>
        /// Validates if input string is in corrent format
        /// </summary>
        /// <param name="input">String to validate</param>
        /// <returns>Retruns true if string is valide, false if not</returns>
        public static bool Validate(string input)
        {
            Regex signs = new Regex(@"(\+|\-)(\+|\-)");
            var matches = signs.Match(input);
            if (matches.Success) return false;
            //takhle to pak nebude :)
            double result;
            try
            {
                result = Solve(input);
            }
            catch (Exception)
            {

                return false;
            }
            if (double.IsNaN(result))
                return false;
            else return true;
           
        }

        static string ReplaceSigns (string input)
        {
            string replacement = input;
            do
            {
                input = replacement;
                replacement = replacement.Replace("--", "+");
                replacement = replacement.Replace("++", "+");
                replacement = replacement.Replace("-+", "-");
                replacement = replacement.Replace("+-", "-");
            } while (replacement != input);
            return replacement;
        }

        /// <summary>
        /// Finds all apearences of specified operation and replaces then with result
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="oper">Operation to be replaced</param>
        /// <returns>string with operation replaced with results</returns>
        static string SolveOperation(string input, Operations oper)
        {

            MatchCollection matches;
            do
            {
                matches = operation_list[oper].regex.Matches(input);
                foreach (Match match in matches)
                {
                    double result=double.NaN;
                    if (operation_list[oper].type == Operation_type.Unary)
                    {
                        //regex pattern is written so x  group 1
                        double x = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                        //uses function from the math library to calculate result
                        result = operation_list[oper].unFunc(x);
                    }
                    else if (operation_list[oper].type == Operation_type.Binary)
                    {
                        //regex pattern is written so x and y is always in group 1 and 2
                        double x = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                        double y = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                        //uses function from the math library to calculate result
                        result = operation_list[oper].binFunc(x, y);
                    }
                    string replacement = result.ToString();
                    //this is to fix issue with calculations like 
                    //3-5*-2, which would result doubleo 300, instead of correct 3+10
                    if (result >= 0) replacement = "+" + replacement;

                    input = input.Replace(match.Value, replacement);
                }
                input = ReplaceSigns(input);
            } while (matches.Count != 0);
            return input;
        }
        /// <summary>
        /// Solves all brackets using Solve() method and replaces them with result 
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>string with all brackets replaced with Solve() output</returns>
        static string SolveBrackets(string input)
        {
            Regex regex = new Regex(@"\(((?:[0-9]|\+|ln|\!|\-|\√|\^|\*|\/)*)\)");
            MatchCollection matches;
            do
            {
                matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    double result = (double)Solve(match.Groups[1].Value);
                    input = input.Replace(match.Value, result.ToString());
                }
                input = ReplaceSigns(input);
            } while (matches.Count != 0);
            return input;
        }

    }
}
