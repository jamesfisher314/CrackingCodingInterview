using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WordRectangle;

namespace CSharp_Tests
{
	[TestClass]
	public class Tests17_25
	{
		[TestMethod]
		public void T17_25Exceptions()
		{
			var side1 = 4;
			var side2 = 4;
			IList<string> rectangle = WordRectangle.WordRectangle.FormRectangle(side1, side2);
			Assert.AreEqual(4, rectangle.Count);
			for (var i = 0; i < side1; i++)
			{
				Assert.AreEqual(side2, rectangle[i].Length);
				Assert.Fail();
			}
		}
	}
}
