using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Calculator
{
	class Mode
	{
		public static Mode LightMode = new Mode()
		{
			MainColor = "#00CC00",
			MinorColor = "#80FF04",
			Background = "#CCF8F8F8",
			Foreground = Brushes.Black,
			NumberBackground = "#AAB0B0B0",
			NumberForeground = Brushes.Black,
			Topbar = Brushes.White,
		};

		public static Mode DarkMode = new Mode()
		{
			MainColor = "#FFA500",
			MinorColor = "#ff0000",
			Background = "#CC000000",
			Foreground = Brushes.White,
			NumberBackground = "#BB111111",
			NumberForeground = Brushes.White,
			Topbar = Brushes.Black,
		};


		public string MainColor { get; set; }
		public string MinorColor { get; set; }
		public string Background { get; set; }
		public Brush Foreground { get; set; }
		public string NumberBackground { get; set; }
		public Brush NumberForeground { get; set; }
		public Brush Topbar { get; set; }

	}
}
