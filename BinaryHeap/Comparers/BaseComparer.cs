﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PyramidSort.BinaryHeap.Comparers
{
	public class BaseComparer : IComparer<Node>
	{
		public int Compare([AllowNull] Node x, [AllowNull] Node y)
		{
			return 0;
		}
	}
}
