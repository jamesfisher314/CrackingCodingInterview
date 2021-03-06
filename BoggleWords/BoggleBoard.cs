﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleWords
{
	public class BoggleBoard
	{
		public readonly int Size;
		char[] board;
		bool[] visits;

		public BoggleBoard(int size)
		{
			CatchInvalid(size);
			Size = size;
			board = new char[0];
			visits = new bool[0];
		}

		public void Initialize(IEnumerable<char> chars)
		{
			char[] charInput = CatchInvalid(chars);
			board = charInput;
			int totalSize = Size * Size;
			visits = new bool[totalSize];
			for (var i = 0; i < totalSize; i++)
				visits[i] = false;
		}

		public char GetChar(int x, int y)
		{
			CatchInvalid(x, y);
			var index = x * 3 + y;
			return board[index];
		}

		public char GetChar(Point<int> point)
		{
			return GetChar(point.X, point.Y);
		}

		public IList<Point<int>> NeighborsOf(Point<int> point)
		{
			var neighbors = new List<Point<int>>();
			if (point.X - 1 >= 0)
				neighbors.Add(new Point<int>(point.X - 1, point.Y));
			if (point.X + 1 < Size)
				neighbors.Add(new Point<int>(point.X + 1, point.Y));
			if (point.Y - 1 >= 0)
				neighbors.Add(new Point<int>(point.X, point.Y - 1));
			if (point.Y + 1 < Size)
				neighbors.Add(new Point<int>(point.X, point.Y + 1));
			return neighbors;
		}

		public bool Contains(Point<int> point)
		{
			return point.X >= 0 && point.X < Size && point.Y >= 0 && point.Y < Size;
		}

		public void ApplyAllCombinations(Func<string, string> operation)
		{
			for (var i = 0; i < Size * Size; i++)
			{
				Visit(i, "", operation);
			}
		}

		private void Visit(int i, string prefix, Func<string, string> operation)
		{
			if (visits[i])
				return;
			visits[i] = true;
			prefix = prefix + board[i];
			operation(prefix);
			
			foreach (var neighbor in NeighborsOf(new Point<int>(i / Size, i % Size)))
			{
				Visit(neighbor.X * Size + neighbor.Y, prefix, operation);
			}
			visits[i] = false;
		}

		#region Error handling

		private static void CatchInvalid(int size)
		{
			if (size < 2)
				throw new ArgumentException("Size must be at least two.", nameof(size));
		}

		private char[] CatchInvalid(IEnumerable<char> chars)
		{
			if (chars == default(IEnumerable<char>) || !chars.Any())
				throw new ArgumentException("Must provide characters.", nameof(chars));
			var charInput = chars.ToArray();
			if (charInput.Length != Size * Size)
				throw new ArgumentException("Must provide " + nameof(Size) + " ^ 2 characters.");

			foreach (var ch in chars)
			{
				if (!char.IsLetter(ch))
					throw new ArgumentException("Characters must be lower case alphabetical.");
			}
			return charInput;
		}

		private void CatchInvalid(int x, int y)
		{
			if (board.Length == 0)
				throw new InvalidOperationException(nameof(board) + " must be initialized.");
			if (x >= Size || y >= Size)
				throw new IndexOutOfRangeException(nameof(x) + " and " + nameof(y) + " are not in the existing board.");
		}
		#endregion Error handling
	}

	public struct Point<T> where T : IComparable<T>
	{
		public readonly T X;
		public readonly T Y;
		public Point(T x, T y)
		{
			X = x;
			Y = y;
		}
	}
}
