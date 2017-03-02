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
			throw new NotImplementedException();
		}

		private static bool IsValidInput(IList<double> distances, int mustVisit)
		{
			if (distances == default(IList<double>))
				return false;
			return distances.Count > 0 && distances.Count >= mustVisit;
		}
	}
}
