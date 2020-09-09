using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidSort.ComparisonRules.NodeComparisonRules
{
	public class ComparisonByStringFields : Rule
	{
		private string firstNodeString;
		private string secondNodeString;

		public ComparisonByStringFields(string first, string second)
		{
			firstNodeString = first;
			secondNodeString = second;
		}
		public override int ApplyTheRule()
		{
			// how will we compare the strings?
		}
	}
}
