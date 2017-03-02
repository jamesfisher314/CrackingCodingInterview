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
		public void SESCCanonical()
		{
			IList<double> distances = new List<double> { 0.1, 8, 23.77, 3.1415926, 0.64, 17 };
			var mustVisit = 5;

			IDictionary<double, IList<IList<int>>> LegalRoutes = SESCDistance.SESCDistance.LegalDistanceRoutes(distances, mustVisit);
			Assert.IsTrue(LegalRoutes.Count > 2);
			Assert.AreEqual(2 * (distances[0] + distances[5]) + 4 * (distances[1] + distances[4]) + 6 * (distances[2] + distances[3]), LegalRoutes.Keys.Max());
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
	}
}
