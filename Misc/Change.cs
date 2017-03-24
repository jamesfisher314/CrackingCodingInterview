using System;

namespace Misc
{
	public class Change
	{
		public static int CountOf(int cents)
		{
			if (cents < 0)
				throw new ArgumentOutOfRangeException(nameof(cents), "Use this method for positive values owed");
			if (cents <= 1)
				return cents;

			return CountOf(cents - 1);
		}
	}
}
