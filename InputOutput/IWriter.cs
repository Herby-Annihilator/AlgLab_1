using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidSort.InputOutput
{
	public interface IWriter
	{
		void WriteToFile(string fileName);
	}
}
