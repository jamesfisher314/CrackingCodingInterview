using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tests
{
	[TestClass]
	public class TestChange
	{
		[TestMethod]
		public void ChangeZero()
		{
			Assert.AreEqual(0, Misc.Change.CountOf(0));
		}

		[TestMethod]
		public void ChangeNegative()
		{
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => Misc.Change.CountOf(-1));
		}

		[TestMethod]
		public void ChangeSub5()
		{
			for (var i = 1; i < 5; i++)
				Assert.AreEqual(1, Misc.Change.CountOf(i));
		}

		[TestMethod]
		public void Change5to9()
		{
			for (var i = 5; i < 10; i++)
				Assert.AreEqual(2, Misc.Change.CountOf(i));
		}

		[TestMethod]
		public void Change10to14()
		{
			for (var i = 10; i < 15; i++)
			{
				Assert.AreEqual(4, Misc.Change.CountOf(i), "failed at " + i);
				Assert.AreEqual(3, Misc.Change.CountOf(i, new List<int> { 5, 1 }), "failed at " + i);
				Assert.AreEqual(1, Misc.Change.CountOf(i, new List<int> { 1 }), "failed at " + i);
			}
		}

		[TestMethod]
		public void Change15to19()
		{
			for (var i = 15; i < 19; i++)
			{
				Assert.AreEqual(6, Misc.Change.CountOf(i), "failed at " + i);
				Assert.AreEqual(4, Misc.Change.CountOf(i, new List<int> { 5, 1 }), "failed at " + i);
				Assert.AreEqual(1, Misc.Change.CountOf(i, new List<int> { 1 }), "failed at " + i);
			}
		}
	}
}
