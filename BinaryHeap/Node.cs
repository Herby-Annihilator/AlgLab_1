using System;
using System.Collections.Generic;
using System.Text;
using TestsGeneration;

namespace PyramidSort.BinaryHeap
{
	public class Node : IGeneratable, IComparable
	{
		public string FirstField { get; set; }
		public string SecondField { get; set; }

		public int ThirdField { get; set; }
		public int FourthField { get; set; }
		public int FifthField { get; set; }

		public int CompareTo(object obj)
		{
			Node toCompare = obj as Node;
			if (toCompare == null)
			{
				throw new Exception("Invalid type in 'CompareTo()' method inside 'Node' class");
			}
			else
			{

			}
		}

		public void Randomize()
		{
			Random random = new Random();
			ThirdField = random.Next();
			FourthField = random.Next();
			FifthField = random.Next();
			FirstField = StringExtension.CreateRandomString(FirstField, random.Next(1, GlobalConstants.STRING_MAX_LENGHT));
			SecondField = StringExtension.CreateRandomString(FirstField, random.Next(1, GlobalConstants.STRING_MAX_LENGHT));
		}
	}
}
