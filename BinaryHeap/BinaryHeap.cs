﻿using System;
using System.Collections.Generic;
using System.Text;
using PyramidSort.ComparisonRules;

namespace PyramidSort.BinaryHeap
{
	public class BinaryHeap<T>
	{
		private T[] nodes;
		private const int MAX_SIZE = 10000;
		private int currentHeapSize;
		private IComparer<T> comparer;

		public BinaryHeap(IComparer<T> comparer)
		{
			this.comparer = comparer;
			currentHeapSize = 0;
			nodes = new T[MAX_SIZE];
		}

		public void Add(T nodeToAdd)
		{
			if (nodeToAdd == null || IsFull())
			{
				return;
			}
			nodes[currentHeapSize] = nodeToAdd;
			RestoreProperty(currentHeapSize);
			currentHeapSize++;
		}

		private bool IsFull()
		{
			return currentHeapSize >= MAX_SIZE;
		}

		private void RestoreProperty(int lastAddedNodeIndex)
		{
			int parent = (lastAddedNodeIndex - 1) / 2; // lastAddedNodeIndex == 8 => parent == 3 or if lastAddedNodeIndex == 7 => parent == 3
			int currentIndex = lastAddedNodeIndex;
			while (parent >= 0 && currentIndex > 0)
			{
				if (comparer.Compare(nodes[currentIndex], nodes[parent]) > 0)
				{
					Swap(currentIndex, parent);
				}
				currentIndex = parent;
				parent = (parent - 1) / 2;
			}
		}

		private void Swap(int firstIndex, int secondIndex)
		{
			T tmp = nodes[firstIndex];
			nodes[firstIndex] = nodes[secondIndex];
			nodes[secondIndex] = tmp;
		}

		public void Built(T[] baseCollection)
		{
			for (int i = 0; i < baseCollection.Length; i++)
			{
				Add(baseCollection[i]);
			}
		}

		public T GetMax()
		{
			T toReturn = nodes[0];
			nodes[0] = nodes[currentHeapSize - 1];
			currentHeapSize--;
			Heapyfi(0);
			return toReturn;
		}

		private void Heapyfi(int startIndex)
		{
			int leftChildIndex;
			int rightChildIndex;
			int largestNodeIndex;

			while (true)
			{
				leftChildIndex = startIndex * 2 + 1;
				rightChildIndex = startIndex * 2 + 2;
				largestNodeIndex = startIndex;
				if (leftChildIndex < currentHeapSize && comparer.Compare(nodes[leftChildIndex], nodes[largestNodeIndex]) > 0) 
				{
					largestNodeIndex = leftChildIndex;
				}
				if (rightChildIndex < currentHeapSize && comparer.Compare(nodes[rightChildIndex], nodes[largestNodeIndex]) > 0)
				{
					largestNodeIndex = rightChildIndex;
				}
				if (largestNodeIndex == startIndex)
				{
					break;
				}
				Swap(startIndex, largestNodeIndex);
				startIndex = largestNodeIndex;
			}
		}
	}
}
