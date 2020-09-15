using System;
using System.Collections.Generic;
using System.Text;
using TestsGeneration;
using System.IO;
using PyramidSort.InputOutput;

namespace PyramidSort.BinaryHeap
{
	public class Node : IGeneratable, IWriter
	{
		public string FirstField { get; set; }
		public string SecondField { get; set; }

		public int ThirdField { get; set; }
		public int FourthField { get; set; }
		public int FifthField { get; set; }

		public void Randomize()
		{
			Random random = new Random();
			ThirdField = random.Next();
			FourthField = random.Next();
			FifthField = random.Next();
			FirstField = StringExtension.CreateRandomString(FirstField, random.Next(1, GlobalConstants.STRING_MAX_LENGHT));
			SecondField = StringExtension.CreateRandomString(FirstField, random.Next(1, GlobalConstants.STRING_MAX_LENGHT));
		}

		public void WriteToFile(string fileName)
		{
			StreamWriter writer = new StreamWriter(fileName, true);
			writer.WriteLine("$***************************************\n\n");
			writer.WriteLine("FirstField (string): " + FirstField);
			writer.WriteLine("SecondField (string): " + SecondField);
			writer.WriteLine("ThirdField (number): " + ThirdField);
			writer.WriteLine("FourthField (number): " + FourthField);
			writer.WriteLine("FifthField (number): " + FifthField);
			writer.WriteLine("\n\n\n***************************************");
			writer.Close();
		}

		public static Node[] ReadFromFile(string fileName) 
		{
			string buffer;
			List<Node> nodes = new List<Node>();
			StreamReader reader = new StreamReader(fileName);
			while((buffer = reader.ReadLine()) != null)
			{
				if (buffer != "" && buffer[0] == '$')
				{
					nodes.Add(new Node());
					string[] words;
					for (int i = 0; i < 5; i++)
					{
						buffer = reader.ReadLine();
						if (buffer == "")
						{
							i--;
							continue;
						}
						words = buffer.Split(new char[] { ' ' });
						string willBeWritten = "";
						for (int j = 2; j < words.Length; j++)
						{
							string str = words[j];
							if(str == "")
							{
								str = " ";
							}
							willBeWritten += str;
						}
						switch (i)
						{
							case 0:
								nodes[nodes.Count - 1].FirstField = willBeWritten;
								break;
							case 1:
								nodes[nodes.Count - 1].SecondField = willBeWritten;
								break;
							case 2:
								nodes[nodes.Count - 1].ThirdField = Convert.ToInt32(willBeWritten);
								break;
							case 3:
								nodes[nodes.Count - 1].FourthField = Convert.ToInt32(willBeWritten);
								break;
							case 4:
								nodes[nodes.Count - 1].FifthField = Convert.ToInt32(willBeWritten);
								break;
						}
					}
				}
			}
			reader.Close();
			return nodes.ToArray();
		}
	}
}
