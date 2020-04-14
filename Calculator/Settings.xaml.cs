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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculator
{
	/// <summary>
	/// Interakční logika pro Settings.xaml
	/// </summary>
	public partial class Settings : Window
	{
		public Settings()
		{
			InitializeComponent();
		}

		private void topBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}

		private void closeButton_Click(object sender, RoutedEventArgs e)
		{
			DoubleAnimation closingAnimation = new DoubleAnimation()
			{
				From = helpWindow.ActualHeight,
				To = 0,
				Duration = new Duration(TimeSpan.FromSeconds(1))
			};
			closingAnimation.Completed += closingAnimation_Completed;
			this.BeginAnimation(Window.HeightProperty, closingAnimation);
		}

		private void closingAnimation_Completed(object sender, EventArgs e)
		{
			this.Close();
		}

		private void functionButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
