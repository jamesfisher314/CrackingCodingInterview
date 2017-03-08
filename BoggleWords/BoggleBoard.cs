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
			Size = size;
		}

		public void Initialize(IEnumerable<char> chars)
		{
			board = chars.ToArray();
		}

		public char GetChar(int x, int y)
		{
			return board[x * 3 + y];
		}
	}
}
