using System;
using System.Collections.Generic;
using System.Text;
using TestsGeneration;
using PyramidSort.ComparisonRules;

namespace PyramidSort.BinaryHeap
{
	public class Node : IGeneratable, IRuleComparable
	{
		public string FirstField { get; set; }
		public string SecondField { get; set; }

		public int ThirdField { get; set; }
		public int FourthField { get; set; }
		public int FifthField { get; set; }

		public int CompareByRule(Rule rule)
		{
			if (toCompare == null || rule == null)
			{
				throw new Exception("Invalid type in 'CompareTo()' method inside 'Node' class or rule was null");
			}
			else
			{
				int ruleResult = rule.ApplyTheRule();
				if (ruleResult > 0)
					return 1;
				else if (ruleResult < 0)
					return -1;
				else
					return 0;
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
