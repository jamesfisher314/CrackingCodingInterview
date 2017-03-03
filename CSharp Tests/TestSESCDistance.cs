using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			var shouldBeMax = 0.0;
			var i = 0;
			for (; i < distances.Count / 2; i++)
				shouldBeMax += 2 * (i + 1) * (distances[i] + distances[distances.Count - i - 1]);
			var isMax = Math.Round(LegalRoutes.Keys.Max(), 8);
			Assert.AreEqual(Math.Round(shouldBeMax, 8), isMax);
			Assert.AreEqual(130, LegalRoutes.Select(dIlIli => dIlIli.Value.Count).Sum());
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
	}
}
