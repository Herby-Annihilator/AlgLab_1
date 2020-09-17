using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
using PyramidSort.BinaryHeap;
using TestsGeneration;
using System.IO;
using PyramidSort.BinaryHeap.Comparers;

namespace PyramidSort
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Node[] nodes;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void buttonGenerate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (File.Exists("input.dat"))
				{
					File.Delete("input.dat");
				}
				int countOfNodes = Convert.ToInt32(textBoxNodesCount.Text);
				Generator<Node> generator = new Generator<Node>(countOfNodes);
				Node[] nodes = generator.Generate();
				for (int i = 0; i < nodes.Length; i++)
				{
					nodes[i].WriteToFile("input.dat");
				}
				textBlockResult.Text = "Данные сгенерированы успешно";
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message, "Warning - Exception!", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void buttonMyOwnSort_Click(object sender, RoutedEventArgs e)
		{
			Sorter<Node> sorter = new Sorter<Node>();
			nodes = Node.ReadFromFile("input.dat");
			StreamWriter writer = new StreamWriter("output.dat");
			writer.WriteLine("\r\n\r\nБыло\r\n");
			writer.Close();
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
			Stopwatch stopwatch = new Stopwatch();

			BaseComparerDecorator baseComparerDecorator = new BaseComparerDecorator(new BaseComparer());

			if (radioButtonFirstField.IsChecked == true)
			{
				baseComparerDecorator = new FirstFieldComparerDecorator(baseComparerDecorator);
			}
			else if (radioButtonSecondField.IsChecked == true)
			{
				baseComparerDecorator = new SecondFieldComparerDecorator(baseComparerDecorator);
			}
			else if (radioButtonThirdField.IsChecked == true)
			{
				baseComparerDecorator = new ThirdComparerDecorator(baseComparerDecorator);
			}
			else if (radioButtonFourthField.IsChecked == true)
			{
				baseComparerDecorator = new FourthFieldDecorator(baseComparerDecorator);
			}
			else if (radioButtonFifthField.IsChecked == true)
			{
				baseComparerDecorator = new FifthComparerDecorator(baseComparerDecorator);
			}


			stopwatch.Start();
			nodes = sorter.SortByPyramid(nodes, baseComparerDecorator);
			stopwatch.Stop();
			textBlockResult.Text = "Затраченное время = " + stopwatch.ElapsedMilliseconds.ToString() + " мс";

			writer = new StreamWriter("output.dat", true);
			writer.WriteLine("\r\n\r\nСтало\r\n");
			writer.Close();
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
		}

		private void buttonDefaultSort_Click(object sender, RoutedEventArgs e)
		{
			nodes = Node.ReadFromFile("input.dat");
			StreamWriter writer = new StreamWriter("output.dat");
			writer.WriteLine("\r\n\r\nБыло\r\n");
			writer.Close();
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
			Stopwatch stopwatch = new Stopwatch();
			BaseComparerDecorator baseComparerDecorator = new BaseComparerDecorator(new BaseComparer());

			if (radioButtonFirstField.IsChecked == true)
			{
				baseComparerDecorator = new FirstFieldComparerDecorator(baseComparerDecorator);
			}
			else if (radioButtonSecondField.IsChecked == true)
			{
				baseComparerDecorator = new SecondFieldComparerDecorator(baseComparerDecorator);
			}
			else if (radioButtonThirdField.IsChecked == true)
			{
				baseComparerDecorator = new ThirdComparerDecorator(baseComparerDecorator);
			}
			else if (radioButtonFourthField.IsChecked == true)
			{
				baseComparerDecorator = new FourthFieldDecorator(baseComparerDecorator);
			}
			else if (radioButtonFifthField.IsChecked == true)
			{
				baseComparerDecorator = new FifthComparerDecorator(baseComparerDecorator);
			}

			stopwatch.Start();
			Array.Sort(nodes, baseComparerDecorator);
			stopwatch.Stop();
			textBlockResult.Text = "Затраченное время = " + stopwatch.ElapsedMilliseconds.ToString() + " мс";

			writer = new StreamWriter("output.dat", true);
			writer.WriteLine("\r\n\r\nСтало\r\n");
			writer.Close();
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
		}

		private void buttonTwoFieldsSort_Click(object sender, RoutedEventArgs e)
		{
			Sorter<Node> sorter = new Sorter<Node>();
			nodes = Node.ReadFromFile("input.dat");
			StreamWriter writer = new StreamWriter("output.dat");
			writer.WriteLine("\r\n\r\nБыло\r\n");
			writer.Close();
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
			Stopwatch stopwatch = new Stopwatch();
			BaseComparerDecorator baseComparerDecorator = new BaseComparerDecorator(new BaseComparer());

			if (checkBoxFirstField.IsChecked == true)
			{
				baseComparerDecorator = new FirstFieldComparerDecorator(baseComparerDecorator);
			}
			if (checkBoxSecondField.IsChecked == true)
			{
				baseComparerDecorator = new SecondFieldComparerDecorator(baseComparerDecorator);
			}
			if (checkBoxThirdField.IsChecked == true)
			{
				baseComparerDecorator = new ThirdComparerDecorator(baseComparerDecorator);
			}
			if (checkBoxFourthField.IsChecked == true)
			{
				baseComparerDecorator = new FourthFieldDecorator(baseComparerDecorator);
			}
			if (checkBoxFifthField.IsChecked == true)
			{
				baseComparerDecorator = new FifthComparerDecorator(baseComparerDecorator);
			}

			stopwatch.Start();
			nodes = sorter.SortByPyramid(nodes, baseComparerDecorator);
			stopwatch.Stop();
			textBlockResult.Text = "Затраченное время = " + stopwatch.ElapsedMilliseconds.ToString() + " мс";
			writer = new StreamWriter("output.dat", true);
			writer.WriteLine("\r\n\r\nСтало\r\n");
			writer.Close();
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
		}
	}
}
