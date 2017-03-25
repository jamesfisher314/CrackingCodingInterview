using System;
using System.Collections.Generic;

namespace Misc
{
	public class Change
	{
		private static readonly IDictionary<int, IEnumerable<int>> CoinOptions = 
			new Dictionary<int, IEnumerable<int>> {
				{100, new List<int> {100, 50, 25, 10, 5, 1} },
				{ 50, new List<int> { 50, 25, 10, 5, 1} },
				{ 25, new List<int> { 25, 10, 5, 1 } },
				{ 10, new List<int> { 10, 5, 1} },
				{  5, new List<int> { 5, 1} },
				{  1, new List<int> { 1 } },
			};

		public static int CountOf(int cents, IEnumerable<int> coins = default(IEnumerable<int>))
		{
			if (cents < 0)
				throw new ArgumentOutOfRangeException(nameof(cents), "Use this method for positive values owed");
			if (cents <= 1)
				return cents;

			var total = 0;
			if (coins == default(IEnumerable<int>))
				coins = CoinOptions[25];

			foreach (var coin in coins)
			{
				if (coin <= cents)
				{
					total += CountOf(cents - coin, CoinOptions[coin]);
					if (coin == cents)
						total++;
				}
			}

			return total;
		}
	}
}
