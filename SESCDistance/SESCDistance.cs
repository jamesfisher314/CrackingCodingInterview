using System;
using System.Collections.Generic;

namespace SESCDistance
{
	public class SESCDistance
	{
		public static IDictionary<double, IList<IList<int>>> LegalDistanceRoutes(IList<double> distances, int mustVisit)
		{
			if (!IsValidInput(distances, mustVisit))
				return default(IDictionary<double, IList<IList<int>>>);

			IDictionary<double, IList<IList<int>>> lengthRoute = new Dictionary<double, IList<IList<int>>>();
			if (mustVisit <= 1)
				lengthRoute.Add(2 * distances[0], new List<IList<int>> { new List<int> { 1 } });
			return lengthRoute;
		}

		private static bool IsValidInput(IList<double> distances, int mustVisit)
		{
			if (distances == default(IList<double>))
				return false;
			return distances.Count > 0 && distances.Count >= mustVisit;
		}
	}
}
