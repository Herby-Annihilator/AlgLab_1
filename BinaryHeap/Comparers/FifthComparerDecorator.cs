using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PyramidSort.BinaryHeap.Comparers
{
	public class FifthComparerDecorator : BaseComparerDecorator
	{
		public override int Compare([AllowNull] Node x, [AllowNull] Node y)
		{
			if (comparer.Compare(x, y) == 0)
			{
				return x.FifthField.CompareTo(y.FifthField);
			}
			return 0;
		}

		public FifthComparerDecorator(IComparer<Node> comparer) : base(comparer)
		{

		}
	}
}
