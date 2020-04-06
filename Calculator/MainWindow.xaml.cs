using MatbLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
		private bool darkMode = true;
		public bool DarkMode
		{
			get { return darkMode; }
			set
			{
				darkMode = value;
				if (darkMode)
					setMode(Mode.DarkMode);
				else
					setMode(Mode.LightMode);
			}
		}


		public MainWindow()
		{
			InitializeComponent();
			setMode(Mode.DarkMode);
			FocusManager.SetFocusedElement(this, numberTextBox);
		}

		private void settingsButton_Click(object sender, RoutedEventArgs e)
		{
			Settings settings = new Settings();
			settings.ShowDialog();
		}

		private void setMode(Mode mode)
		{
			App.Current.Resources["MainColor"] = (Color)ColorConverter.ConvertFromString(mode.MainColor);
			App.Current.Resources["MinorColor"] = (Color)ColorConverter.ConvertFromString(mode.MinorColor);
			this.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(mode.Background);
			App.Current.Resources["Foreground"] = mode.Foreground;
			numberTextBox.Background = (SolidColorBrush)new BrushConverter().ConvertFromString(mode.NumberBackground);
			numberTextBox.Foreground = mode.NumberForeground;
			topBar.Background = mode.Topbar;
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

		private void numberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex(@"(?:[0-9])|(?:[\(\)\.\+\-\*\/\√])");
			e.Handled = !regex.IsMatch(e.Text);
		}

		private void number_Click(object sender, RoutedEventArgs e)
		{
			int caretPosition = numberTextBox.CaretIndex+1;
			string insert = (sender as Button).Content.ToString();
			numberTextBox.Text = numberTextBox.Text.Insert(numberTextBox.CaretIndex, insert);
			FocusManager.SetFocusedElement(this, numberTextBox);
			numberTextBox.CaretIndex = caretPosition;
		}

		private void deleteAllButton_Click(object sender, RoutedEventArgs e)
		{
			numberTextBox.Text = "";
			FocusManager.SetFocusedElement(this, numberTextBox);
		}

		private void deleteButton_Click(object sender, RoutedEventArgs e)
		{
			int caretPosition = numberTextBox.CaretIndex - 1;
			if (caretPosition >= 0)
				numberTextBox.Text = numberTextBox.Text.Remove(caretPosition, 1);
			else
				caretPosition = 0;
			FocusManager.SetFocusedElement(this, numberTextBox);
			numberTextBox.CaretIndex = caretPosition;

		}

		private void equalsButton_Click(object sender, RoutedEventArgs e)
		{
			string problem = numberTextBox.Text;
			//Parser parser = new Parser();
			double result = Parser.Solve(problem);
			numberTextBox.Text = double.IsNaN(result) ? "ERROR BRUH!!" : result.ToString();
		}

		private void numberTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
                case Key.Enter:
					MessageBox.Show("yup");
                    break;
				case Key.I:
					MessageBox.Show("otevře settings");
					break;
				case Key.C:
					numberTextBox.Text = "";
					break;
			}
		}

		private void modeButton_Click(object sender, RoutedEventArgs e)
		{
			DarkMode = !DarkMode;
			modeButtonText.Text = darkMode ? "Dark" : "Light";
		}
	}
}
