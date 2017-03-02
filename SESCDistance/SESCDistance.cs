using System;
using System.Collections.Generic;
using System.Linq;

namespace SESCDistance
{
	public class SESCDistance
	{
		private static IDictionary<int, double> totalDistance;

		public static IDictionary<double, IList<IList<int>>> LegalDistanceRoutes(IList<double> distances, int mustVisit)
		{
			totalDistance = new Dictionary<int, double>();
			if (!IsValidInput(distances, mustVisit))
				return default(IDictionary<double, IList<IList<int>>>);

			IDictionary<double, IList<IList<int>>> lengthRoute = new Dictionary<double, IList<IList<int>>>();
			if (mustVisit <= 1)
				lengthRoute.Add(2 * distances[0], new List<IList<int>> { new List<int> { 1 } });
			bool outbound = true;
			CalculateTotalDistances(distances);
			for (var i = 2; i <= distances.Count; i++)
			{
				var turns = new HashSet<int> { i };
				var route = new List<int> { i };
				Progress(ref lengthRoute, distances, turns, route, !outbound, i >= mustVisit, mustVisit, distances.Count);
			}
			return lengthRoute;
		}

		private static void Progress(	ref IDictionary<double, 
										IList<IList<int>>> lengthRoute, 
										IList<double> distances, 
										HashSet<int> turns, 
										List<int> route, 
										bool outbound, 
										bool visited, 
										int mustVisit, 
										int maxTurn)
		{
			if (!outbound && visited)
				lengthRoute.Add(RouteLength(distances, route), route);
			for (var i = route[route.Count - 1]; outbound ? i <= maxTurn : i > 0;)
			{
				if (turns.Contains(i))
				{
					i = Crement(outbound, i);
					continue;
				}

				if (outbound ? i < route.Last() : i > route.Last())
					throw new Exception("Should not have allowed this turn");

				var nextTurns = turns.CopyOf();
				nextTurns.Add(i);
				var nextRoute = route.CopyOf();
				nextRoute.Add(i);

				Progress(ref lengthRoute, distances, nextTurns, nextRoute, !outbound, visited ? visited : i >= mustVisit, mustVisit, maxTurn);
				i = Crement(outbound, i);
			}
		}

		private static bool IsValidInput(IList<double> distances, int mustVisit)
		{
			if (distances == default(IList<double>))
				return false;
			return distances.Count > 0 && distances.Count >= mustVisit;
		}

		private static int Crement(bool outbound, int i)
		{
			if (outbound)
				i++;
			else
				i--;
			return i;
		}

		private static void CalculateTotalDistances(IList<double> distances)
		{
			var distance = 0.0;
			totalDistance.Add(0, 0);
			for (var i = 0; i < distances.Count;)
			{
				distance += distances[i];
				i++;
				totalDistance.Add(i, distance);
			}
		}

		private static double RouteLength(IList<double> distances, IList<int> route)
		{
			var position = 0;
			var distance = 0.0;
			for (var i = 0; i < route.Count; i++)
			{
				var next = route[i];
				var current = totalDistance[next];
				var past = totalDistance[position];
				var stageDistance = Math.Abs(current - past);
				distance += stageDistance;
				position = next;
			}
			distance += totalDistance[route.Last()];
			return distance;
		}
	}

	public static class SESCExtensions
	{
		public static void Add(this IDictionary<double, IList<IList<int>>> storage, double length, IList<int> route)
		{
			if (!storage.ContainsKey(length))
				storage.Add(length, new List<IList<int>> { route });
			else
				storage[length].Add(route);
		}

		public static HashSet<int> CopyOf(this HashSet<int> hash)
		{
			var result = new HashSet<int>();
			foreach (var i in hash)
				result.Add(i);
			return result;
		}

		public static List<int> CopyOf(this List<int> route)
		{
			var result = new List<int>();
			foreach (var i in route)
				result.Add(i);
			return result;
		}
	}
}
