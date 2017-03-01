using System;
using System.Collections.Generic;

namespace _17_26_Sparse_Document_Similarity
{
	public static class _17_26_Sparse_Document_Similarity
	{
		public static IList<Tuple<int, int, double>> Similarity(IDictionary<int, IList<int>> haveThisWord, IList<IList<int>> docs)
		{
			if (haveThisWord == null || docs == null || haveThisWord.Count < 1 || docs.Count < 1)
				return default(IList<Tuple<int, int, double>>);
			PrintHeader();
			IDictionary<int, ISet<int>> matches = new Dictionary<int, ISet<int>>();
			foreach (var word in haveThisWord.Keys)
			{
				if (!haveThisWord.ContainsKey(word))
					continue;
				var match = haveThisWord[word];
				if (match == null || match.Count < 2)
					continue;
				for (var m = 0; m < match.Count; m++)
				{
					for (var n = m + 1; n < match.Count; n++)
					{
						AddToMatches(ref matches, match[m], match[n]);
					}
				}
			}
			if (matches.Count < 1)
				return default(IList<Tuple<int, int, double>>);
			IList<Tuple<int, int, double>> results = new List<Tuple<int, int, double>>();
			foreach (var doc in matches.Keys)
			{
				foreach (var match in matches[doc])
					results.Add(new Tuple<int, int, double>(doc, match, Similarity(docs, doc, match)));
			}
			return results;
		}

		public static IDictionary<int, IList<int>> ReadIntoMatches(IList<IList<int>> inputDocs)
		{
			IDictionary<int, IList<int>> hasThisWord = new Dictionary<int, IList<int>>();
			if (inputDocs == null || inputDocs.Count == 0)
				return default(IDictionary<int, IList<int>>);
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
				hasThisWord.Add(word, new List<int> { i });
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

		public static double Similarity(IList<IList<int>> docs, int doc, int match)
		{
			var total = docs[doc].Count + docs[match].Count;
			var equal = 0;
			foreach (var word in docs[doc])
			{
				var matchWords = docs[match];
				if (matchWords.Contains(word))
					equal++;
			}
			var similar = (double)equal / (total - equal);
			return similar;
		}
	}
}