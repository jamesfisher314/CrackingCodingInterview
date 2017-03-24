using System;

namespace Misc
{
	public class Change
	{
		public static int CountOf(int cents)
		{
			if (cents < 0)
				throw new ArgumentOutOfRangeException(nameof(cents), "Use this method for positive values owed");
			return cents == 0 ? 0 : 1;
		}
	}
}
