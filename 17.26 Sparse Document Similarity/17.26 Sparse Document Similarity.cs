using System;
using System.Collections.Generic;

namespace _17._26_Sparse_Document_Similarity
{
	public static class _17_26_Sparse_Document_Similarity
	{
		static void MainMethod(string[] args)
		{
			IList<IList<int>> inputDocs = new List<IList<int>>() {
				null,									// 0
				null,									// 1
				null,									// 2
				new List<int> { 14, 15, 100, 9, 3 },	// 3
				new List<int>(),						// 4
				new List<int>{314159265},				// 5
				new List<int>{32, 1, 9, 3, 5 },			// 6
				new List<int>(),						// 7
				null,									// 8
				new List<int>{15, 29, 2, 6, 8, 7 },		// 9
				null,									//10
				null,									//11
				null,									//12
				null,									//13
				new List<int>{7, 10 }					//14
			};
			IDictionary<int, IList<int>> haveThisWord = ReadIntoMatches(inputDocs);
			Similarity(haveThisWord, inputDocs);
			Console.ReadLine();
		}

		public static void Similarity(IDictionary<int, IList<int>> haveThisWord, IList<IList<int>> docs)
		{
			PrintHeader();
			IDictionary<int, ISet<int>> matches = new Dictionary<int, ISet<int>>();
			for (var i = 0; i < haveThisWord.Keys.Count; i++)
			{
				var match = haveThisWord[i];
				if (match.Count < 2)
					continue;
				for (var m = 0; m < match.Count; m++)
				{
					for (var n = m + 1; n < match.Count; n++)
					{
						AddToMatches(ref matches, match[m], match[n]);
					}
				}
			}
			foreach (var doc in matches.Keys)
			{
				foreach (var match in matches[doc])
					PrintSimilarity(docs, doc, match);
			}
		}

		private static IDictionary<int, IList<int>> ReadIntoMatches(IList<IList<int>> inputDocs)
		{
			IDictionary<int, IList<int>> hasThisWord = new Dictionary<int, IList<int>>();
			for (var i = 0; i < inputDocs.Count; i++)
			{
				if (inputDocs[i] == null || inputDocs[i].Count == 0)
					continue;
				foreach (var word in inputDocs[i])
				{
					AddToMapDictionary(ref hasThisWord, word, i);
				}
			}
			return hasThisWord;
		}

		private static void AddToMapDictionary(ref IDictionary<int, IList<int>> hasThisWord, int word, int i)
		{
			if (!hasThisWord.ContainsKey(word))
				hasThisWord.Add(word, new List<int>(i));
			else
				hasThisWord[word].Add(i);
		}

		private static void AddToMatches(ref IDictionary<int, ISet<int>> matches, int m, int n)
		{
			if (!matches.ContainsKey(m))
				matches.Add(m, new HashSet<int> { n });
			else
				matches[m].Add(n);
		}

		private static void PrintHeader()
		{
			Console.WriteLine("ID1, ID2 \t: SIMILARITY");
		}

		public static void PrintSimilarity(IList<IList<int>> docs, int doc, int match)
		{
			var total = docs[doc].Count + docs[match].Count;
			var equal = 0;
			foreach (var word in docs[doc])
			{
				var matchWords = docs[match];
				if (matchWords.Contains(word))
					equal++;
			}
			Console.WriteLine(doc + ", " + match + "\t: " + (equal / (total - equal)));
		}
	}
}