using System;
using System.Collections.Generic;
using System.Text;
using TestsGeneration;
using PyramidSort.ComparisonRules;

namespace PyramidSort.BinaryHeap
{
	public class Node : IGeneratable
	{
		public string FirstField { get; set; }
		public string SecondField { get; set; }

		public int ThirdField { get; set; }
		public int FourthField { get; set; }
		public int FifthField { get; set; }

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
