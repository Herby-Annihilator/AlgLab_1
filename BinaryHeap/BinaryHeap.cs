using System;
using System.Collections.Generic;
using System.Text;
using PyramidSort.ComparisonRules;

namespace PyramidSort.BinaryHeap
{
	public class BinaryHeap<T> where T : IRuleComparable
	{
		private T[] nodes;
		private const int MAX_SIZE = 10000;
		private int currentHeapSize;
		private Rule rule;

		public BinaryHeap()
		{
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
				if (nodes[currentIndex].CompareByRule(nodes[parent])) // substitute
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

		private void Heapyfi(int startIndex)
		{
			int leftChildIndex = startIndex * 2 + 1;
			int rightChildIndex = startIndex * 2 + 2;
			int largestNodeIndex = startIndex;

			while (true)
			{
				if (leftChildIndex < currentHeapSize && nodes[leftChildIndex] > nodes[largestNodeIndex])  // substitute
				{
					largestNodeIndex = leftChildIndex;
				}
				if (rightChildIndex < currentHeapSize && nodes[rightChildIndex] > nodes[largestNodeIndex]) //substitute
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
