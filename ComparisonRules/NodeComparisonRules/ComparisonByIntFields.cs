using System;
using System.Collections.Generic;
using System.Text;
using PyramidSort.BinaryHeap;

namespace PyramidSort.ComparisonRules.NodeComparisonRules
{
	public class ComparisonByIntFields : Rule
	{
		private int firstNodeField;
		private int secondNodeField;

		public ComparisonByIntFields(int first, int second)
		{
			firstNodeField = first;
			secondNodeField = second;
		}
		public override int ApplyTheRule()
		{
			return firstNodeField - secondNodeField;
		}
	}
}
