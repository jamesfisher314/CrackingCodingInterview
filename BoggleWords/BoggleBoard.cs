using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleWords
{
	public class BoggleBoard
	{
		public readonly int Size;
		char[] board;

		public BoggleBoard(int size)
		{
			if (size < 2)
				throw new ArgumentException("Size must be at least two.", nameof(size));
			Size = size;
			board = new char[0];
		}

		public void Initialize(IEnumerable<char> chars)
		{
			if (chars == default(IEnumerable<char>) || !chars.Any())
				throw new ArgumentException("Must provide characters.", nameof(chars));
			var charInput = chars.ToArray();
			if (charInput.Length != Size * Size)
				throw new ArgumentException("Must provide " + nameof(Size) + " ^ 2 characters.");
			board = charInput;
		}

		public char GetChar(int x, int y)
		{
			if (board.Length == 0)
				throw new InvalidOperationException(nameof(board) + " must be initialized.");
			if (x >= Size || y >= Size)
				throw new IndexOutOfRangeException(nameof(x) + " and " + nameof(y) + " are not in the existing board.");

			var index = x * 3 + y;
			return board[index];
		}
	}
}
