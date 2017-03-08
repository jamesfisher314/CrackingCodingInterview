using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tests
{
	[TestClass]
	public class TestBoggle
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

		[TestMethod]
		public void BoggleExceptions()
		{
			Assert.ThrowsException<ArgumentException>(() => new BoggleWords.BoggleBoard(-1));
			Assert.ThrowsException<ArgumentException>(() => new BoggleWords.BoggleBoard(0));
			Assert.ThrowsException<ArgumentException>(() => new BoggleWords.BoggleBoard(1));

			var board = new BoggleWords.BoggleBoard(2);

			IList<char> chars = null;
			Assert.ThrowsException<ArgumentException>(() => board.Initialize(chars));

			chars = new List<char>();
			Assert.ThrowsException<ArgumentException>(() => board.Initialize(chars));

			Assert.ThrowsException<InvalidOperationException>(() => board.GetChar(0, 0));

			chars.Add('a');
			Assert.ThrowsException<ArgumentException>(() => board.Initialize(chars));
			Assert.ThrowsException<InvalidOperationException>(() => board.GetChar(0, 0));
			chars.Add('d');
			Assert.ThrowsException<ArgumentException>(() => board.Initialize(chars));
			chars.Add('d');
			Assert.ThrowsException<ArgumentException>(() => board.Initialize(chars));
			Assert.ThrowsException<InvalidOperationException>(() => board.GetChar(0, 0));
			chars.Add('d');
			board.Initialize(chars);
			Assert.AreEqual('a', board.GetChar(0, 0));
			chars.Add('a');
			Assert.ThrowsException<ArgumentException>(() => board.Initialize(chars));

			Assert.ThrowsException<IndexOutOfRangeException>(() => board.GetChar(-1, 0));
			Assert.ThrowsException<IndexOutOfRangeException>(() => board.GetChar(0, -1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => board.GetChar(board.Size, 0));
			Assert.ThrowsException<IndexOutOfRangeException>(() => board.GetChar(0, board.Size));
		}
	}
}
