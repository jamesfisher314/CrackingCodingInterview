using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tests
{
	[TestClass]
	class TestBoggle
	{
		[TestMethod]
		public void BoggleAccessLetters()
		{
			var board = new BoggleWords.BoggleBoard(3);
			var chars = new List<char> { 'h', 'e', 'l', 't', 'o', 'l', 'a', 'c', 'c' };
			board.Initialize(chars);
			for (var i = 0; i < chars.Count; i++)
			{
				Assert.AreEqual(chars[i], board.GetChar(i / 3, i % 3));
			}
		}
	}
}
