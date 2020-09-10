using System;
using System.Collections.Generic;
using System.Text;
using PyramidSort.BinaryHeap;

namespace PyramidSort
{
	public class Sorter<T>
	{
		public static T[] SortByPyramid(T[] sortingArray, IComparer<T> comparer)
		{
			BinaryHeap<T> heap = new BinaryHeap<T>(comparer);
			heap.Built(sortingArray);
			for (int i = 0; i < sortingArray.Length; i++)
			{
				sortingArray[i] = heap.GetMax();
			}
			return sortingArray;
		}
	}
}
