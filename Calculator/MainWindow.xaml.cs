using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
	/// <summary>
	/// Interakční logika pro MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string validChars = "0123456789+-*/√";
		private string operations = "+-*/";
		private bool darkMode;
		public bool DarkMode
		{
			get { return darkMode; }
			set
			{
				darkMode = value;
				if (darkMode)
					setMode("#00CC00", "#80FF04", "#CCF8F8F8", Brushes.Black, "#AAB0B0B0", Brushes.Black, Brushes.White);
				else
					setMode("#FFA500", "#ff0000", "#CC000000", Brushes.White, "#BB111111", Brushes.White, Brushes.Black);
			}
		}


		public MainWindow()
		{
			InitializeComponent();
			App.Current.Resources["MinorColor"] = (Color)ColorConverter.ConvertFromString("#ff0000");
			App.Current.Resources["MainColor"] = (Color)ColorConverter.ConvertFromString("#FFA500");
			App.Current.Resources["Foreground"] = Brushes.White;
			FocusManager.SetFocusedElement(this, numberTextBox);
		}

		private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (numberTextBox.Text.Length > 0)
			{
				Validation();
			}
		}

		private void Validation()
		{
			if (!validChars.Contains(numberTextBox.Text.Substring(numberTextBox.Text.Length - 1).ToCharArray()[0]))
			{
				numberTextBox.Text = numberTextBox.Text.Substring(0, numberTextBox.Text.Length - 1);
				numberTextBox.CaretIndex = numberTextBox.Text.Length;
				MessageBox.Show("Nice Try", "Invalid");
			}
			else if (operations.Contains(numberTextBox.Text.Substring(numberTextBox.Text.Length - 1).ToCharArray()[0]) && operations.Contains(numberTextBox.Text.Substring(numberTextBox.Text.Length - 2).ToCharArray()[0]))
			{
				numberTextBox.Text = numberTextBox.Text.Substring(0, numberTextBox.Text.Length - 1);
				numberTextBox.CaretIndex = numberTextBox.Text.Length;
				MessageBox.Show("Nice Try", "Invalid");
			}
		}

		private void settingsButton_Click(object sender, RoutedEventArgs e)
		{
			DarkMode = !DarkMode;
		}

		private void setMode(string mainColor, string minorColor, string background, Brush foreground, string numberBackground, Brush numberForeground, Brush topbar)
		{
			App.Current.Resources["MainColor"] = (Color)ColorConverter.ConvertFromString(mainColor);
			App.Current.Resources["MinorColor"] = (Color)ColorConverter.ConvertFromString(minorColor);
			this.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(background);
			App.Current.Resources["Foreground"] = foreground;
			numberTextBox.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(numberBackground);
			numberTextBox.Foreground = numberForeground;
			topBar.Background = topbar;
		}

		private void closeButton_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void topBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				Application.Current.MainWindow.DragMove();
		}
	}
}
