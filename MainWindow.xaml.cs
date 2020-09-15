using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
			if (radioButtonFirstField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new FirstFieldComparer());
			}
			else if (radioButtonSecondField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new SecondFieldComparer());
			}
			else if (radioButtonThirdField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new ThirdFieldComparer());
			}
			else if (radioButtonFourthField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new FourthFieldComparer());
			}
			else if (radioButtonFifthField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new FifthFieldComparer());
			}
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
		}



		private class FirstFieldComparer : IComparer<Node>
		{
			public int Compare([AllowNull] Node x, [AllowNull] Node y)
			{
				return x.FirstField.CompareTo(y.FirstField);
			}
		}
		private class SecondFieldComparer : IComparer<Node>
		{
			public int Compare([AllowNull] Node x, [AllowNull] Node y)
			{
				return x.SecondField.CompareTo(y.SecondField);
			}
		}
		private class ThirdFieldComparer : IComparer<Node>
		{
			public int Compare([AllowNull] Node x, [AllowNull] Node y)
			{
				return x.ThirdField.CompareTo(y.ThirdField);
			}
		}
		private class FourthFieldComparer : IComparer<Node>
		{
			public int Compare([AllowNull] Node x, [AllowNull] Node y)
			{
				return x.FourthField.CompareTo(y.FourthField);
			}
		}
		private class FifthFieldComparer : IComparer<Node>
		{
			public int Compare([AllowNull] Node x, [AllowNull] Node y)
			{
				return x.FifthField.CompareTo(y.FifthField);
			}
		}

		private void buttonDefaultSort_Click(object sender, RoutedEventArgs e)
		{
			// her znaet
		}

		private void buttonTwoFieldsSort_Click(object sender, RoutedEventArgs e)
		{
			Sorter<Node> sorter = new Sorter<Node>();
			nodes = Node.ReadFromFile("input.dat");
			if (checkBoxFirstField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new FirstFieldComparer());
			}
			if (checkBoxSecondField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new SecondFieldComparer());
			}
			if (checkBoxThirdField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new ThirdFieldComparer());
			}
			if (checkBoxFourthField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new FourthFieldComparer());
			}
			if (checkBoxFifthField.IsChecked == true)
			{
				nodes = sorter.SortByPyramid(nodes, new FifthFieldComparer());
			}
			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i].WriteToFile("output.dat");
			}
		}
	}
}
