﻿using System;
using System.Collections.Generic;
using System.Text;
using PyramidSort.BinaryHeap;

namespace PyramidSort
{
	public class Sorter<T>
	{
		public T[] SortByPyramid(T[] sortingArray, IComparer<T> comparer)
		{
			BinaryHeap<T> heap = new BinaryHeap<T>(comparer);
			heap.Built(sortingArray);
			heap.Sort();
			return sortingArray;
		}
	}
}
