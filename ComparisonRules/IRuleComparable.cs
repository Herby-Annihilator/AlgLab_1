using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidSort.ComparisonRules
{
	public interface IRuleComparable<T>
	{
		int CompareByRule(T first, T second);
	}
}
