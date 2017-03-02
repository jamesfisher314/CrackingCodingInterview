using System;
using System.Collections.Generic;
using System.Linq;

namespace SESCDistance
{
	public class SESCDistance
	{
		private static IDictionary<int, double> totalDistance = new Dictionary<int, double>();

		public static IDictionary<double, IList<IList<int>>> LegalDistanceRoutes(IList<double> distances, int mustVisit)
		{
			if (!IsValidInput(distances, mustVisit))
				return default(IDictionary<double, IList<IList<int>>>);

			IDictionary<double, IList<IList<int>>> lengthRoute = new Dictionary<double, IList<IList<int>>>();
			if (mustVisit <= 1)
				lengthRoute.Add(2 * distances[0], new List<IList<int>> { new List<int> { 1 } });
			bool outbound = true;
			bool visited = false;
			CalculateTotalDistances(distances);
			for (var i = 2; i <= distances.Count; i++)
			{
				var turns = new HashSet<int> { i };
				var route = new List<int> { i };
				turns.Add(i);
				Progress(ref lengthRoute, distances, turns, route.Append(i).ToList(), !outbound, visited, mustVisit, distances.Count);
				turns.Remove(i);
			}
			return lengthRoute;
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
			for (var i = route[route.Count - 1]; outbound ? i <= maxTurn : i > 0;)
			{
				if (turns.Contains(i))
					continue;

				var nextTurns = turns;
				nextTurns.Add(i);
				var nextRoute = route;
				nextRoute.Add(i);

				Progress(ref lengthRoute, distances, nextTurns, nextRoute, !outbound, visited ? visited : i >= mustVisit, mustVisit, maxTurn);

				if (outbound)
					i++;
				else
					i--;
			}
			if (outbound && visited)
				lengthRoute.Add(RouteLength(distances, route), route);
		}

		private static double RouteLength(IList<double> distances, IList<int> route)
		{
			var position = 0;
			var distance = 0.0;
			for (var i = 0; i < route.Count; i++)
			{
				var next = route[i];
				var stageDistance = totalDistance[next] - totalDistance[position];
				distance += stageDistance;
				position = next;
			}
			return distance;
		}

		private static bool IsValidInput(IList<double> distances, int mustVisit)
		{
			if (distances == default(IList<double>))
				return false;
			return distances.Count > 0 && distances.Count >= mustVisit;
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
	}
}
