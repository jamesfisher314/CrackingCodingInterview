using BoggleWords;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Tests
{
	[TestClass]
	public class TestBoggle
	{
		[TestMethod]
		public void BoggleAccessLetters()
		{
			var board = new BoggleBoard(3);
			var chars = new List<char> { 'h', 'e', 'l', 't', 'o', 'l', 'a', 'c', 'c' };
			board.Initialize(chars);
			for (var i = 0; i < chars.Count; i++)
			{
				Assert.AreEqual(chars[i], board.GetChar(i / 3, i % 3));
				Assert.AreEqual(chars[i], board.GetChar(new Point<int>(i / 3, i % 3)));
			}
		}

		[TestMethod]
		public void BoggleExceptions()
		{
			Assert.ThrowsException<ArgumentException>(() => new BoggleBoard(-1));
			Assert.ThrowsException<ArgumentException>(() => new BoggleBoard(0));
			Assert.ThrowsException<ArgumentException>(() => new BoggleBoard(1));

			var board = new BoggleBoard(2);

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

		[TestMethod]
		public void BoggleNeighbors()
		{
			var board = new BoggleBoard(3);
			var chars = new List<char> { 'h', 'e', 'l', 't', 'o', 'l', 'a', 'c', 'c' };
			board.Initialize(chars);

			for (var i = 0; i < board.Size * board.Size; i++)
			{
				var x = i / board.Size;
				var y = i % board.Size;
				var thisPoint = new Point<int>(x, y);
				IList<Point<int>> neighbors = board.NeighborsOf(thisPoint);

				var above = new Point<int>(x - 1, y);
				var below = new Point<int>(x + 1, y);
				var left = new Point<int>(x, y - 1);
				var right = new Point<int>(x, y + 1);

				foreach (var position in new List<Point<int>> { above, below, left, right })
				{
					var contained = board.Contains(position);
					if (position.X >= 0 && position.X < board.Size && position.Y >= 0 && position.Y < board.Size)
						Assert.IsTrue(contained);
					else
						Assert.IsFalse(contained);

					if (contained)
						Assert.IsTrue(neighbors.Contains(position));
					else
						Assert.IsFalse(neighbors.Contains(position));
				}
			}
		}

		[TestMethod]
		public void BoggleCombinations()
		{
			var twoBoard = new BoggleBoard(2);
			var chars = new List<char> { 'h', 'o', 'e', 'l' };
			twoBoard.Initialize(chars);

			var count = 0;
			var strings = new List<string>();
			twoBoard.ApplyAllCombinations((string word) => { count++; strings.Add(word); return word; });
			Assert.AreEqual(28, count);
			Assert.AreEqual(count, strings.Count);
			Assert.AreEqual(count, strings.Distinct().Count());

			var threeBoard = new BoggleBoard(3);
			chars = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
			threeBoard.Initialize(chars);

			count = 0;
			strings = new List<string>();
			threeBoard.ApplyAllCombinations((string word) => { count++; strings.Add(word); return word; });
			Assert.AreEqual(653, count);
			Assert.AreEqual(count, strings.Count);
			Assert.AreEqual(count, strings.Distinct().Count());

			var fourBoard = new BoggleBoard(4);
			chars = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };
			fourBoard.Initialize(chars);

			count = 0;
			strings = new List<string>();
			fourBoard.ApplyAllCombinations((string word) => { count++; strings.Add(word); return word; });
			Assert.AreEqual(28512, count);
			Assert.AreEqual(count, strings.Count);
			Assert.AreEqual(count, strings.Distinct().Count());

			var fiveBoard = new BoggleBoard(5);
			chars = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y' };
			fiveBoard.Initialize(chars);

			count = 0;
			strings = new List<string>();
			fiveBoard.ApplyAllCombinations((string word) => { count++; strings.Add(word); return word; });
			Assert.AreEqual(3060417, count);
			Assert.AreEqual(count, strings.Count);
			Assert.AreEqual(count, strings.Distinct().Count());
		}
	}

	
}
