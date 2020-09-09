using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidSort.ComparisonRules
{
	public interface IRuleComparable
	{
		int CompareByRule(Rule rule);
	}
}
