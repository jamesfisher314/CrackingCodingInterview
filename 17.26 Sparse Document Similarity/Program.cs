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
			var matches = new Dictionary<int, ISet<int>>();
			for (var i = 0; i < haveThisWord.Keys.Count; i++)
			{
				var match = haveThisWord[i];
				if (match.Count < 2)
					continue;
				for (var m = 0; m < matches.Count; m++)
				{
					for (var n = m + 1; n < matches.Count; n++)
					{
						AddToMatches(ref matches, m, n);
					}
				}
			}
			foreach (var doc in matches.Keys)
			{
				foreach (var match in matches[doc])
					PrintSimilarity(docs, doc, match);
			}
		}

		private void AddToMatches(ref Dictionary<int, ISet<int>> matches, int m, int n)
		{
			throw new NotImplementedException();
		}

		private void PrintHeader()
		{
			Console.WriteLine("ID1, ID2 \t: SIMILARITY");
		}

		public void PrintSimilarity(List<List<int>> docs, int doc, int match)
		{
			var total = docs[doc].Count + docs[match].Count;
			var equal = 0;
			foreach (var word in docs[doc])
				if (docs[match].Contains(word))
					equal++;
			Console.WriteLine(doc + ", " + match + "\t: " + (equal / (total - equal)));
		}
	}
}