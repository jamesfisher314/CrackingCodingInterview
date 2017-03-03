using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp_Tests
{
	[TestClass]
	public class TestSESCDistance
	{
		[TestMethod]
		public void SESCCanonicalEven()
		{
			IList<double> distances = new List<double> { 0.1, 8, 23.77, 3.1415926, 0.64, 17 };
			var mustVisit = 5;

			IDictionary<double, IList<IList<int>>> LegalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.IsTrue(LegalRoutes.Count > 2);
			double shouldBeMax = CalculateMaximum(distances);
			var isMax = Math.Round(LegalRoutes.Keys.Max(), 8);
			Assert.AreEqual(Math.Round(shouldBeMax, 8), isMax);
			Assert.AreEqual(130, LegalRoutes.Select(dIlIli => dIlIli.Value.Count).Sum());
		}

		[TestMethod]
		public void SESCCanonicalOdd()
		{
			IList<double> distances = new List<double> { 0.1, 8, 23.77, 3.1415926, 0.64, 10, 7 };
			var mustVisit = 5;

			IDictionary<double, IList<IList<int>>> LegalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.IsTrue(LegalRoutes.Count > 2);
			var shouldBeMax = CalculateMaximum(distances);
			var isMax = Math.Round(LegalRoutes.Keys.Max(), 8);
			Assert.AreEqual(Math.Round(shouldBeMax, 8), isMax);
			Assert.AreEqual(673, LegalRoutes.Select(dIlIli => dIlIli.Value.Count).Sum());
		}

		[TestMethod]
		public void SESCEmpty()
		{
			IList<double> distances = null;
			int mustVisit = 0;
			var legalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.AreEqual(default(IDictionary<double, IList<IList<int>>>), legalRoutes);

			mustVisit = 1;
			legalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.AreEqual(default(IDictionary<double, IList<IList<int>>>), legalRoutes);

			distances = new List<double>();
			mustVisit = 0;
			legalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.AreEqual(default(IDictionary<double, IList<IList<int>>>), legalRoutes);

			mustVisit = 1;
			legalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.AreEqual(default(IDictionary<double, IList<IList<int>>>), legalRoutes);
		}

		[TestMethod]
		public void SESCMustVisit1()
		{
			var distances = new List<double> { 1.0 };
			int mustVisit = distances.Count;
			var legalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);

			Assert.AreEqual(1, legalRoutes.Count);
			Assert.AreEqual(2 * distances[0], legalRoutes.Keys.First());
			Assert.AreEqual(1, legalRoutes[2 * distances[0]].First().First());
		}

		[TestMethod]
		public void SESCDistinctRoutes()
		{
			IList<Tuple<int, bool>> NumberAndAccuracy = new List<Tuple<int, bool>>();
			for (var i = 1; i < 11; i++)
			{
				var distances = WithNodes(i);
				NumberAndAccuracy.Add(ResultsOf(RunRace(distances), distances));
			}
			Assert.AreEqual("", JsonConvert.SerializeObject(NumberAndAccuracy));
		}

		private IList<double> WithNodes(int i)
		{
			Random rand = new Random();
			IList<double> distances = new List<double>();
			for (var m = 0; m < i; m++)
				distances.Add(int.MaxValue * rand.NextDouble());
			return distances;
		}

		private IDictionary<double, IList<IList<int>>> RunRace(IList<double> distances)
		{
			return SESCDistance.SESCDistance.LegalDistanceRoutes(distances, 0);
		}

		private Tuple<int, bool> ResultsOf(IDictionary<double, IList<IList<int>>> RouteDistance, IList<double> distances)
		{
			var combinations = RouteDistance.Select(dIlIli => dIlIli.Value.Count).Sum();
			var maxDistance = Math.Round(RouteDistance.Keys.Max(), 8);
			return new Tuple<int, bool>(combinations, maxDistance == CalculateMaximum(distances));
		}

		private static double CalculateMaximum(IList<double> distances)
		{
			var shouldBeMax = 0.0;
			var i = 0;
			for (; i < distances.Count / 2; i++)
				shouldBeMax += 2 * (i + 1) * (distances[i] + distances[distances.Count - i - 1]);
			if (!(distances.Count % 2 == 0))
				shouldBeMax += 2 * (i + 1) * distances[i];
			return Math.Round(shouldBeMax, 8);
		}
	}
}
