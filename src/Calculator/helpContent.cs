using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	class HelpContent
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string[] Case { get; set; }

		public static HelpContent Root = new HelpContent()
		{
			Title = "Nth Root",
			Description = "Nth root of a number x: ",
			Case = new string[] { "n√y", "(n√y)", "n√(y)", "-(n√y)" }
		};

		public static HelpContent Exponentation = new HelpContent()
		{
			Title = "Exponentation",
			Description = "Exponentation of a number x: ",
			Case = new string[] { "x^n", "(-x)^(-n)", "(x^y)", "(-x^y)" }
		};

		public static HelpContent Logarithm = new HelpContent()
		{
			Title = "Natural Logarithm",
			Description = "Natural logarithm of a number x: ",
			Case = new string[] { "lnx", "ln(x)", "-(lnx)", "-ln(x)" }
		};

		public static HelpContent Factorial = new HelpContent()
		{
			Title = "Factorial",
			Description = "Factorial of a number n: ",
			Case = new string[] { "x!", "(x)!", "", "" }
		};

		public static HelpContent Negation = new HelpContent()
		{
			Title = "Negation",
			Description = "Negation of a number x",
			Case = new string[] { "x=>-(x)", "-(x)=>x", "", "" }
		};
	}
}
