using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PyramidSort.BinaryHeap.Comparers
{
	public class ThirdComparerDecorator : BaseComparerDecorator
	{
		public override int Compare([AllowNull] Node x, [AllowNull] Node y)
		{
			if (comparer.Compare(x, y) == 0)
			{
				return x.ThirdField.CompareTo(y.ThirdField);
			}
			return 0;
		}

		public ThirdComparerDecorator(IComparer<Node> comparer) : base(comparer)
		{

		}
	}
}
