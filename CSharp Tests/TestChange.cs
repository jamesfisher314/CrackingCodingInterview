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
	}
}
