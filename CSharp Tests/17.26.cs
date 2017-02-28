using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
			_17_26_Sparse_Document_Similarity._17_26_Sparse_Document_Similarity.Similarity(haveThisWord, inputDocs);
		}
	}
}
