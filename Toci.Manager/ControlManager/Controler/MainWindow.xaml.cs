using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Controler
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public event EventHandler Holder;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_OnClick(object sender, RoutedEventArgs e)
		{
			Process[]my =  Process.GetProcesses();
			
			foreach (var item in my)
			{

				listBox.Items.Add(item.ProcessName +"-" + item.Id);
			}
		
		}

		private void listBox_MouseDown(object sender, MouseButtonEventArgs e)
		{

			var i = Process.GetProcessById(Convert.ToInt32(listBox.SelectedItems.ToString().Substring(listBox.SelectedItem.ToString().IndexOf("-"))));
			MessageBox.Show(i.ToString());
		}



		private void button1_Click(object sender, RoutedEventArgs e)
		{
			
			string temp = listBox.SelectedItem.ToString();
            var i = Process.GetProcessById(Convert.ToInt32(temp.Substring(temp.IndexOf("-")+1)));
			var h = i.Handle;

			MessageBox.Show(i.ToString());
		}
	}
}
