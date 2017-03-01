using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Tests
{
	[TestClass]
	public class Tests17_26
	{
		[TestMethod]
		public void BookExample()
		{
			IList<IList<int>> inputDocs = new List<IList<int>>() {
				null,									// 0
				null,									// 1
				null,									// 2
				new List<int> {14, 15, 100, 9, 3 },		// 3
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
			IDictionary<int, IList<int>> haveThisWord = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.ReadIntoMatches(inputDocs);
			var results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, inputDocs);
			Assert.AreEqual(3, results.Count, "Book Example has three instances with matching words. This did not.");
			Assert.AreEqual(0.1, results.Where(r => r.Item1 == 3 && r.Item2 == 9).First().Item3, "Book had this result. This did not.");
			Assert.AreEqual(0.25, results.Where(r => r.Item1 == 3 && r.Item2 == 6).First().Item3, "Book had this result. This did not.");
			Assert.AreEqual(1.0/7, results.Where(r => r.Item1 == 9 && r.Item2 == 14).First().Item3, "Book had this result. This did not.");
		}

		[TestMethod]
		public void Empty()
		{
			IList<IList<int>> input = null;
			var haveThisWord = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.ReadIntoMatches(input);
			var results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, input);
			Assert.AreEqual(default(IList<Tuple<int, int, double>>), results);

			input = new List<IList<int>>();
			haveThisWord = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.ReadIntoMatches(input);
			results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, input);
			Assert.AreEqual(default(IList<Tuple<int, int, double>>), results);

			input = new List<IList<int>> { null };
			haveThisWord = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.ReadIntoMatches(input);
			results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, input);
			Assert.AreEqual(default(IList<Tuple<int, int, double>>), results);
			
			haveThisWord = null;
			results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, input);
			Assert.AreEqual(default(IList<Tuple<int, int, double>>), results);

			haveThisWord = new Dictionary<int, IList<int>>();
			results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, input);
			Assert.AreEqual(default(IList<Tuple<int, int, double>>), results);

			haveThisWord = new Dictionary<int, IList<int>> { { -1, null } };
			results = _17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, input);
			Assert.AreEqual(default(IList<Tuple<int, int, double>>), results);
		}
	}
}
