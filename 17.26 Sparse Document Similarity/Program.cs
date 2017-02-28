using System;
using System.Collections.Generic;

namespace _17._26_Sparse_Document_Similarity
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public void Similarity(Dictionary<int, List<int>> haveThisWord, List<List<int>> docs)
		{
			PrintHeader();
			for (var i = 0; i < haveThisWord.Keys.Length; i++)
			{
				var matches = haveThisWord[i];
				if (matches.Length < 2)
					continue;
				var matches = new Dictionary<int, Set<int>>();
				for (var m = 0; m < matches.Length; m++)
				{
					for (var n = m + 1; n < matches.Length; n++)
					{
						AddToMatches(ref matches, m, n);
					}
				}
			}
			foreach (var doc in matches.Keys)
			{
				foreach (var match in matches[doc])
					printSimilarity(docs, doc, match);
			}
		}

		public void PrintSimilarity(List<List<int>> docs, int doc, int match)
		{
			var total = docs[doc].Length + docs[match].Length;
			var equal = 0;
			foreach (var word in docs[doc])
				if (docs[match].Contains(word))
					equal++;
			Console.WriteLine(doc + ", " + match + "\+: " + (equal / (total - equal)));
		}
	}
}